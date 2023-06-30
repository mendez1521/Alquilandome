using System.ComponentModel.DataAnnotations.Schema;
using Alquilandome.Data.Request;

namespace Alquilandome.Data.Response
{
    // Clase AlquilerDetalle
    public class AlquilerDetalleResponse
    {
        public int Id { get; set; }
        public int AlquilerId { get; set; }
        public ArticuloResponse Articulo { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioAlquiler { get; set; }
        public decimal Dias { get; set; } = totalDays;
        public static DateTime FechaDeEntrega { get; set; } = DateTime.Now.AddDays(2);

        [NotMapped]
        public decimal SubTotal => (Cantidad * PrecioAlquiler) * Dias;

        static AlquilerRequest request { get; set; } = new AlquilerRequest();
        static DateTime startDate = request.Fecha;
        static int totalDays = (int)(FechaDeEntrega - startDate).TotalDays;

    }

}
