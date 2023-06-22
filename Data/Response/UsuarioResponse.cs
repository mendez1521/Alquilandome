using Alquilandome.Data.Request;

namespace Alquilandome.Data.Response
{
    // Clase Usuario
    public class UsuarioResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; }

        public UsuarioRequest ToRequest()
        { 
            return new UsuarioRequest 
            { 
                Id = Id,
                Nombre = Nombre, 
                Nickname = Nickname, 
                Password = Password, 
                Email = Email,
                Rol = Rol
            }; 
        }
    }

}
