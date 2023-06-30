using Alquilandome.Data.Request;
using Alquilandome.Data.Response;

namespace Alquilandome.Data.entities
{
    // Clase Artículo
    public class Articulo
    {
        public int Id { get; set; }
        public string Referencia { get; set; } = null!;
        public string Descripción { get; set; } = null!;
        public int Cantidad { get; set; }
        public decimal PrecioAlquiler { get; set; }

        public static Articulo crear(ArticuloRequest articulo)
       => new Articulo()
       {
           Referencia = articulo.Referencia,
           Descripción = articulo.Descripción,
           Cantidad = articulo.Cantidad,
           PrecioAlquiler = articulo.PrecioAlquiler,

       };
        public bool Modificar(ArticuloRequest articulo)
        {
            var cambio = false;
            if (Referencia != articulo.Referencia)
            {
                Referencia = articulo.Referencia;
                cambio = true;
            }
            if (Descripción != articulo.Descripción)
            {
                Descripción = articulo.Descripción;
                cambio = true;
            }
            if (Cantidad != articulo.Cantidad)
            {
                PrecioAlquiler = articulo.PrecioAlquiler;
                cambio = true;
            }
            if (PrecioAlquiler != articulo.PrecioAlquiler)
            {
                PrecioAlquiler = articulo.PrecioAlquiler;
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
    }

}
