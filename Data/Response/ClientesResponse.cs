using Alquilandome.Data.Request;

namespace Alquilandome.Data.Response
{

    // Clase Cliente
    public class ClienteResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Cedula { get; set; }  = null!;
        public string Telefono { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string? Correo { get; set; }
        public string Sexo { get; set; } = null!;

        public ClienteRequest ToRequest()
        {  
            return new ClienteRequest 
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

}
