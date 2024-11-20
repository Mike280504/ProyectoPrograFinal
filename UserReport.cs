using SQLite;

namespace ProyectoProgra.Models
{
    public class UserReport
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Correo { get; set; }
        public string TipoProblema { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public string Municipio { get; set; }
        public string Colonia { get; set; }
        public string Calle { get; set; }
        public string NumeroExterior { get; set; }
        public string Estado_reporte { get; set; }
    }
}
