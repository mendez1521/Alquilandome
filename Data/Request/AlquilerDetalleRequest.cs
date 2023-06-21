using Alquilandome.Data.Response;

namespace Alquilandome.Data.Request
{
    // Clase AlquilerDetalle
    public class AlquilerDetalleRequest
    {
        public int Id { get; set; }
        public int AlquilerId { get; set; }
        public int ArticuloId { get; set; }
        public ArticuloRequest Articulo { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioAlquiler { get; set; }
    }

}
