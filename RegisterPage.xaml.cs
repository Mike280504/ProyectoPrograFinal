using Microsoft.Maui.Controls;
using ProyectoProgra.Models;
using System;

namespace ProyectoProgra
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        async void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            var fullName = FullNameEntry.Text;
            var email = EmailEntry.Text;
            var password = PasswordEntry.Text;
            var birthDate = BirthDatePicker.Date;

            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                await DisplayAlert("Error", "Por favor completa todos los campos.", "OK");
                return;
            }

            var newUser = new Usuario
            {
                FullName = fullName,
                Email = email,
                Password = password,
                BirthDate = birthDate
            };

            try
            {
                Console.WriteLine("Iniciando guardado en SQLite...");
                int sqliteResult = await App.Database.SaveUserAsync(newUser); // Guardar en SQLite
                Console.WriteLine($"Guardado en SQLite completado con resultado: {sqliteResult}");

                Console.WriteLine("Iniciando guardado en MySQL...");
                await App.Database.SaveUserToMySqlAsync(newUser); // Guardar en MySQL
                Console.WriteLine("Guardado en MySQL completado.");

                await DisplayAlert("Registro Completo", "El usuario se ha registrado exitosamente.", "OK");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error durante el registro: {ex.Message}");
                await DisplayAlert("Error", "Ocurrió un error durante el registro del usuario.", "OK");
            }

            await Navigation.PopAsync();
        }
    }
}
