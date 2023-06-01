using Alquilandome.Data.Request;
using Alquilandome.Data.Response;

namespace Alquilandome.Data.entities
{
    // Clase Usuario
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; }

        public static UsuarioRequest crear(UsuarioRequest UsuarioRequest)
  => new UsuarioRequest()
  {
      Nombre = UsuarioRequest.Nombre,
      Nickname = UsuarioRequest.Nickname,
      Password = UsuarioRequest.Password,
      Email = UsuarioRequest.Email,
      Rol = UsuarioRequest.Rol,
     
  };

        public bool Modificar(UsuarioRequest UsuarioRequest)
        {
            var cambio = false;
            if (Nombre != UsuarioRequest.Nombre)
            {
                Nombre = UsuarioRequest.Nombre;
                cambio = true;
            }
            if (Nickname != UsuarioRequest.Nickname)
            {
                Nickname = UsuarioRequest.Nickname;
                cambio = true;
            }
            if (Password != UsuarioRequest.Password)
            {
                Password = UsuarioRequest.Password;
                cambio = true;
            }
            if (Email != UsuarioRequest.Email)
            {
                Rol = UsuarioRequest.Rol;
                cambio = true;
            }
            return cambio;


        }
        public UsuarioResponse toRespose()
            => new UsuarioResponse()
            {
                Nombre = Nombre,
                Nickname = Nickname,
                Password = Password,
                Email = Email,
                Rol = Rol,
            };
    }

}
