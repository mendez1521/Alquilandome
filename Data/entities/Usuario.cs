using Alquilandome.Data.Request;
using Alquilandome.Data.Response;

namespace Alquilandome.Data.entities;
    // Clase Usuario
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Nickname { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Rol { get; set; }

        public static Usuario Crear(UsuarioRequest usuario)
        => new Usuario()
        {
            Nombre = usuario.Nombre,
            Nickname = usuario.Nickname,
            Password = usuario.Password,
            Email = usuario.Email,
            Rol = usuario.Rol,
            
        };

        public bool Modificar(UsuarioRequest request)
        {
            var cambio = false;
            if (Nombre != request.Nombre)
            {
                Nombre = request.Nombre;
                cambio = true;
            }
            if (Nickname != request.Nickname)
            {
                Nickname = request.Nickname;
                cambio = true;
            }
            if (Password != request.Password)
            {
                Password = request.Password;
                cambio = true;
            }
            if (Email != request.Email)
            {
                Rol = request.Rol;
                cambio = true;
            }
            return cambio;


        }
        public UsuarioResponse toResponse()
            => new UsuarioResponse()
            {
                Nombre = Nombre,
                Nickname = Nickname,
                Password = Password,
                Email = Email,
                Rol = Rol,
            };
    }


