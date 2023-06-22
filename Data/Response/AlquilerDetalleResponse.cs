using Alquilandome.Data.Request;

namespace Alquilandome.Data.Response
{
    // Clase AlquilerDetalle
    public class AlquilerDetalleResponse
    {
        public int Id { get; set; }
        public int AlquilerId { get; set; }
        public int ArticuloId { get; set; }
        public ArticuloResponse Articulo { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioAlquiler { get; set; }

        public AlquilerDetalleRequest ToRequest()
        { 
            return new AlquilerDetalleRequest 
            { 
                Id = Id,
                AlquilerId = AlquilerId, 
                ArticuloId = ArticuloId, 
                Cantidad = Cantidad, 
                PrecioAlquiler = PrecioAlquiler
            }; 
        }
    }

}
