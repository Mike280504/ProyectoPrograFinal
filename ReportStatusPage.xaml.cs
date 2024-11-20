using Microsoft.Maui.Controls;
using System.Collections.Generic;
using ProyectoProgra.Models;

namespace ProyectoProgra
{
    public partial class ReportStatusPage : ContentPage
    {
        private List<UserReport> reportList;
        private string connectionString = "server=databasepoe.cfko0iqhcsi0.us-east-1.rds.amazonaws.com;userid=admin;password=POE$2024;database=proyectoprogra;";

        public ReportStatusPage(List<UserReport> reports)
        {
            InitializeComponent();
            reportList = reports;
            ReportsCollectionView.ItemsSource = reportList;
        }
    }
}
