using SQLite;

namespace ProyectoProgra.Models
{
    public class UserDatos
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }  // Clave primaria autoincremental para SQLite
        public string FullName { get; set; } = string.Empty;  // Nombre completo del usuario
        public string Email { get; set; } = string.Empty;     // Correo electrónico del usuario
        public string Password { get; set; } = string.Empty;  // Contraseña del usuario
        public DateTime BirthDate { get; set; }               // Fecha de nacimiento del usuario
    }
}
