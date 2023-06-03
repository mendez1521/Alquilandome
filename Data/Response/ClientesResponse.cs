namespace Alquilandome.Data.Response
{

    // Clase Cliente
    public class ClienteResponse
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
