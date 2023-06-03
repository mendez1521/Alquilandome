namespace Alquilandome.Data.Request
{

    // Clase Cliente
    public class ClienteRequest
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string? Correo { get; set; }
        public string Sexo { get; set; }
    }

}
