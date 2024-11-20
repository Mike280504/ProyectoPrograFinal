using System.Collections.Generic;
using System.Linq;

namespace ProyectoProgra2
{
    public class UserService
    {
        private List<User> registeredUsers = new List<User>();

        public void RegisterUser(User user)
        {
            registeredUsers.Add(user);
        }

        public bool IsValidUser(string email, string password)
        {
            return registeredUsers.Any(user => user.Email == email && user.Password == password);
        }
    }

    public class User
    {
        public string FullName { get; set; } = string.Empty; // Inicializar con un valor predeterminado
        public string Email { get; set; } = string.Empty; // Inicializar con un valor predeterminado
        public string Password { get; set; } = string.Empty; // Inicializar con un valor predeterminado
        public System.DateTime BirthDate { get; set; }
    }
}