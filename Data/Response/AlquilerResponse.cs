namespace Alquilandome.Data.Response
{
    public class AlquilerResponse
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public ClienteResponse Cliente {get; set;}
        public DateTime FechaDeEntrega { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public List<AlquilerDetalleResponse> Detalles {get; set;}
    }
}
