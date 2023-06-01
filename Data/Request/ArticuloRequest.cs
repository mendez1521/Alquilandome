namespace Alquilandome.Data.Request
{
    // Clase ArticuloRequest
    public class ArticuloRequest
    {
        public int Id { get; set; }
        public string Referencia { get; set; }
        public string Descripción { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioAlquiler { get; set; }
    }

}
