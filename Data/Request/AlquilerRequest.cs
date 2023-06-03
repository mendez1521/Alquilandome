namespace Alquilandome.Data.Request
{
    public class AlquilerRequest
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public DateTime FechaDeEntrega { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public List<AlquilerDetalleRequest> Detalles {get; set;}
    }
}
