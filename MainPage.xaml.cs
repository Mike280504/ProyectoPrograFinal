using Microsoft.Maui.Controls;
using MySql.Data.MySqlClient;

namespace ProyectoProgra
{
    public partial class MainPage : ContentPage
    {
        private string connectionString = "Server=databasepoe.cfko0iqhcsi0.us-east-1.rds.amazonaws.com;Database=proyectoprogra;User ID=admin;Password=POE$2024";

        public MainPage()
        {
            InitializeComponent();
        }

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            var email = EmailEntry.Text;
            var password = PasswordEntry.Text;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    await conn.OpenAsync();

                    // Validación del inicio de sesión
                    if (email == Constants.AdminEmail && password == Constants.AdminPassword)
                    {
                        await DisplayAlert("Bienvenido Admin", "¡Bienvenido, Administrador!", "OK");
                        await Navigation.PushAsync(new AdminPage());
                    }
                    else
                    {
                        var user = await App.Database.GetUserAsync(email);
                        if (user != null && user.Password == password)
                        {
                            await DisplayAlert("Bienvenido", $"¡Bienvenido, {user.FullName}!", "OK");
                            await Navigation.PushAsync(new SecondPage(email));
                        }
                        else
                        {
                            await DisplayAlert("Error", "El correo o contraseña son incorrectos.", "OK");
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                await DisplayAlert("Error de Conexión", $"No se pudo conectar a la base de datos: {ex.Message}", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Ocurrió un error: {ex.Message}", "OK");
            }
        }

        //kk

        async void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }
    }
}
