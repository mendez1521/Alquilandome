using Alquilandome.Data.Request;
using Alquilandome.Data.Response;

namespace Alquilandome.Data.entities
{
    // Clase AlquilerDetalle
    public class AlquilerDetalle
    {
        public int Id { get; set; }
        public int AlquilerId { get; set; }
        public int ArticuloId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioAlquiler { get; set; }

        public static AlquilerDetalle crear(AlquilerDetalleRequest AlquilerDEtalle)
        =>new AlquilerDetalle()
       {
           AlquilerId = AlquilerDEtalle.AlquilerId,
           ArticuloId = AlquilerDEtalle.ArticuloId,
           Cantidad = AlquilerDEtalle.Cantidad,
           PrecioAlquiler = AlquilerDEtalle.PrecioAlquiler,

       };
        public bool Modificar(AlquilerDetalleRequest AlquilerDEtalle)
        {
            var cambio = false;
            if (AlquilerId != AlquilerDEtalle.AlquilerId)
            {
                AlquilerId = AlquilerDEtalle.AlquilerId;
                cambio = true;
            }
            if (ArticuloId != AlquilerDEtalle.ArticuloId)
            {
                ArticuloId = AlquilerDEtalle.ArticuloId;
                cambio = true;
            }
            if (Cantidad != AlquilerDEtalle.Cantidad)
            {
                PrecioAlquiler = AlquilerDEtalle.PrecioAlquiler;
                cambio = true;
            }
            if (PrecioAlquiler != AlquilerDEtalle.PrecioAlquiler)
            {
                PrecioAlquiler = AlquilerDEtalle.PrecioAlquiler;
                cambio = true;
            }
            return cambio;

        }

        public AlquilerDetalleResponse toRespose()
            => new AlquilerDetalleResponse()
            {
                AlquilerId = AlquilerId,
                ArticuloId = ArticuloId,
                Cantidad = Cantidad,
                PrecioAlquiler = PrecioAlquiler,

            };
    }

}
