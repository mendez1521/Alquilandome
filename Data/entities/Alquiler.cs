namespace Alquilandome.Data.entities
{
    // Clase Alquiler
    public class Alquiler
    {
                                                                                                                         

        public int Id { get; set; }

        public int ClienteId { get; set; } 

        public DateTime FechaDeEntrega { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
    }

}
