using SQLite;

namespace ProyectoProgra.Models
{
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
    }
}
