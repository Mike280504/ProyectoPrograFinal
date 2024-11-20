using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using ProyectoProgra.Models;
using System.Linq;
using MySql.Data.MySqlClient;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ProyectoProgra
{
    public partial class AdminPage : ContentPage, INotifyPropertyChanged
    {
        private ObservableCollection<UserReport> reports;
        private ObservableCollection<UserReport> filteredReports;
        private string connectionString = "Server=databasepoe.cfko0iqhcsi0.us-east-1.rds.amazonaws.com;Database=proyectoprogra;User ID=admin;Password=POE$2024";

        private UserReport _selectedReport;
        public UserReport SelectedReport
        {
            get => _selectedReport;
            set
            {
                _selectedReport = value;
                OnPropertyChanged();
            }
        }

        public AdminPage()
        {
            InitializeComponent();
            BindingContext = this;
            reports = new ObservableCollection<UserReport>();
            LoadReports();
        }

        private async void LoadReports()
        {
            var reportList = await App.Database.GetReportsAsync();
            reports = new ObservableCollection<UserReport>(reportList);
            filteredReports = new ObservableCollection<UserReport>(reports);
            ReportsCollectionView.ItemsSource = filteredReports;
        }

        private void OnStatusPickerChanged(object sender, EventArgs e)
        {
            var selectedStatus = StatusPicker.SelectedItem?.ToString();

            if (selectedStatus == "Todos")
            {
                filteredReports = new ObservableCollection<UserReport>(reports);
            }
            else
            {
                filteredReports = new ObservableCollection<UserReport>(reports.Where(r => r.Estado_reporte == selectedStatus));
            }

            ReportsCollectionView.ItemsSource = filteredReports;
        }

        private void OnReportSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null && e.CurrentSelection.Count > 0)
            {
                SelectedReport = e.CurrentSelection[0] as UserReport;
            }
        }

        private async void OnUpdateButtonClicked(object sender, EventArgs e)
        {
            if (SelectedReport != null)
            {
                // Verificar los valores de SelectedReport antes de la actualización
              //Console.WriteLine($"SelectedReport.Id: {SelectedReport.Id}");
                Console.WriteLine($"SelectedReport.Estado_reporte: {SelectedReport.Estado_reporte}");

                using (var connection = new MySqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    var query = "UPDATE reporte SET Estado_reporte = @Estado_reporte  WHERE Descripcion = @Descripcion";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Estado_reporte", SelectedReport.Estado_reporte);
                        command.Parameters.AddWithValue("@Descripcion", SelectedReport.Descripcion);

                        try
                        {
                            int rowsAffected = await command.ExecuteNonQueryAsync();
                            Console.WriteLine($"Rows affected: {rowsAffected}");

                            if (rowsAffected > 0)
                            {
                                await DisplayAlert("Éxito", "El estado del reporte ha sido actualizado en la base de datos.", "OK");
                            }
                            else
                            {
                                Console.WriteLine($"Error: No se afectaron filas en la base de datos. SelectedReport.Id: {SelectedReport.Id}");
                                await DisplayAlert("Error", "No se pudo actualizar el estado del reporte en la base de datos.", "OK");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Excepción: {ex.Message}");
                            await DisplayAlert("Error", "Ocurrió un error al intentar actualizar el estado del reporte en la base de datos.", "OK");
                        }
                    }
                }
                await App.Database.UpdateReportAsync(SelectedReport);
            }
            else
            {
                await DisplayAlert("Error", "Por favor selecciona un reporte para actualizar.", "OK");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
