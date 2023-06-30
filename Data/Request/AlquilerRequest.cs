namespace Alquilandome.Data.Request
{
    public class AlquilerRequest
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public DateTime FechaDeEntrega { get; set; } = DateTime.Now.AddDays(2);
        public DateTime Fecha { get; set; } = DateTime.Now;

        public virtual ICollection<AlquilerDetalleRequest> Detalles { get; set; } 
        = new List<AlquilerDetalleRequest>();
        public decimal SubTotal => 
        Detalles != null ? 
        Detalles.Sum(d=>d.SubTotal)
        :
        0;
    }
}
