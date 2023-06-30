using Alquilandome.Data.Response;

namespace Alquilandome.Data.Request
{
    // Clase AlquilerDetalle
    public class AlquilerDetalleRequest
    {
        public int Id { get; set; }
        public int AlquilerId { get; set; }
        public int ArticuloId { get; set; }
        public string? Descripción { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioAlquiler { get; set; }
        public static DateTime FechaDeEntrega { get; set; } = DateTime.Now.AddDays(2);
        public decimal SubTotal => (Cantidad * PrecioAlquiler) * Dias;
        public int Dias { get; set; } = totalDays;

        static AlquilerRequest request { get; set; } = new AlquilerRequest();
        static DateTime startDate = request.Fecha;
        static int totalDays = (int)(FechaDeEntrega - startDate).TotalDays;
    }

}
