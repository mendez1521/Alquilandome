using Alquilandome.Data.Request;

namespace Alquilandome.Data.Response
{
    // Clase Artículo
    public class ArticuloResponse
    {
        public int Id { get; set; }
        public string Referencia { get; set; } = null!;
        public string Descripción { get; set; } = null!;
        public int Cantidad { get; set; }
        public decimal PrecioAlquiler { get; set; }

        public string CodigoDescripcion => $"({Referencia}) {Descripción}";

        public ArticuloRequest ToRequest()
        { 
            return new ArticuloRequest 
            { 
                Id = Id,
                Referencia = Referencia, 
                Descripción = Descripción, 
                Cantidad = Cantidad, 
                PrecioAlquiler = PrecioAlquiler
            }; 
        }
    }

}
