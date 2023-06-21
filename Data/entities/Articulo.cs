using Alquilandome.Data.Request;
using Alquilandome.Data.Response;

namespace Alquilandome.Data.entities
{
    // Clase Artículo
    public class Articulo
    {
        public int Id { get; set; }
        public string Referencia { get; set; }
        public string Descripción { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioAlquiler { get; set; }

        public static ArticuloRequest crear(ArticuloRequest ArticuloRequest)
       => new ArticuloRequest()
       {
           Referencia = ArticuloRequest.Referencia,
           Descripción = ArticuloRequest.Descripción,
           Cantidad = ArticuloRequest.Cantidad,
           PrecioAlquiler = ArticuloRequest.PrecioAlquiler,

       };
        public bool Modificar(ArticuloRequest ArticuloRequest)
        {
            var cambio = false;
            if (Referencia != ArticuloRequest.Referencia)
            {
                Referencia = ArticuloRequest.Referencia;
                cambio = true;
            }
            if (Descripción != ArticuloRequest.Descripción)
            {
                Descripción = ArticuloRequest.Descripción;
                cambio = true;
            }
            if (Cantidad != ArticuloRequest.Cantidad)
            {
                PrecioAlquiler = ArticuloRequest.PrecioAlquiler;
                cambio = true;
            }
            if (PrecioAlquiler != ArticuloRequest.PrecioAlquiler)
            {
                PrecioAlquiler = ArticuloRequest.PrecioAlquiler;
                cambio = true;
            }
            return cambio;

        }
        public ArticuloResponse ToResponse()
            => new ArticuloResponse()
            {
                Id = Id,
                Referencia = Referencia,
                Descripción = Descripción,
                Cantidad = Cantidad,
                PrecioAlquiler = PrecioAlquiler,
            };
        public ArticuloRequest ToRequest()
            => new ArticuloRequest()
            {
                Id = Id,
                Referencia = Referencia,
                Descripción = Descripción,
                Cantidad = Cantidad,
                PrecioAlquiler = PrecioAlquiler,
            };
    }

}
