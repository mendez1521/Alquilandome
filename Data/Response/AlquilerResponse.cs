using Alquilandome.Data.Request;

namespace Alquilandome.Data.Response
{
    public class AlquilerResponse
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public ClienteResponse Cliente {get; set;}
        public DateTime FechaDeEntrega { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public List<AlquilerDetalleResponse> Detalles {get; set;}

         public AlquilerRequest ToRequest()
        { 
            return new AlquilerRequest 
            { 
                Id = Id,
                ClienteId = ClienteId, 
                FechaDeEntrega = FechaDeEntrega, 
                Fecha = Fecha, 
                Total = Total
            }; 
        }
    }
}
