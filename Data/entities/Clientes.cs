using Alquilandome.Data.Request;
using Alquilandome.Data.Response;

namespace Alquilandome.Data.entities
{

    // Clase Cliente
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Cedula { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string? Correo { get; set; }
        public string Sexo { get; set; } = null!;

        public static Cliente Crear(ClienteRequest cliente)
     => new Cliente()
     {
         Nombre = cliente.Nombre,
         Cedula = cliente.Cedula,
         Telefono = cliente.Telefono,
         Direccion = cliente.Direccion,
         Correo = cliente.Correo,
         Sexo = cliente.Sexo
     };
        public bool Modificar(ClienteRequest ClienteRequest)
        {
            var cambio = false;
            if (Nombre != ClienteRequest.Nombre)
            {
                Nombre = ClienteRequest.Nombre;
                cambio = true;
            }
            if (Cedula != ClienteRequest.Cedula)
            {
                Cedula = ClienteRequest.Cedula;
                cambio = true;
            }
            if (Telefono != ClienteRequest.Telefono)
            {
                Direccion = ClienteRequest.Direccion;
                cambio = true;
            }
            if (Correo != ClienteRequest.Correo)
            {
                Correo = ClienteRequest.Correo;
                cambio = true;
            }
            if (Sexo != ClienteRequest.Sexo)
            {
                Sexo = ClienteRequest.Sexo;
                cambio = true;
            }
            return cambio;

        }
        public ClienteResponse ToResponse()
            => new ClienteResponse()
            {
                Id = Id,
                Nombre = Nombre,
                Cedula = Cedula,
                Telefono = Telefono,
                Direccion = Direccion,
                Correo = Correo,
                Sexo = Sexo
            };
    }

}
