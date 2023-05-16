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
    }

}
