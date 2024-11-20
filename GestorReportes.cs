using System.Collections.Generic;
using ProyectoProgra.Models;

namespace ProyectoProgra
{
    public class GestorReportes
    {
        private List<UserReport> reportes;

        public GestorReportes()
        {
            reportes = new List<UserReport>();
        }

        public void AgregarReporte(UserReport reporte)
        {
            reportes.Add(reporte);
        }

        public List<UserReport> ObtenerReportes()
        {
            return reportes;
        }
    }
}
