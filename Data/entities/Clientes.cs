using Alquilandome.Data.Request;
using Alquilandome.Data.Response;

namespace Alquilandome.Data.entities
{

    // Clase Cliente
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public string Sexo { get; set; }

        public static ClienteRequest crear(ClienteRequest ClienteRequest)
     => new ClienteRequest()
     {
         Nombre = ClienteRequest.Nombre,
         Cedula = ClienteRequest.Cedula,
         Telefono = ClienteRequest.Telefono,
         Direccion = ClienteRequest.Direccion,
         Correo = ClienteRequest.Correo,
         Sexo = ClienteRequest.Sexo,
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
        public ClienteResponse toRespose()
            => new ClienteResponse()
            {
                Nombre = Nombre,
                Cedula = Cedula,
                Telefono = Telefono,
                Direccion = Direccion,
                Correo = Correo,
                Sexo = Sexo,
            };
    }

}
