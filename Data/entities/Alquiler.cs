using Alquilandome.Data.Request;
using Alquilandome.Data.Response;

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

        public static Alquiler  crear (AlquilerRequest Alquiler)
        =>new Alquiler()
        {
        ClienteId = Alquiler.ClienteId,
        FechaDeEntrega=Alquiler.FechaDeEntrega,
        Fecha=Alquiler.Fecha,
        Total=Alquiler.Total,

        };
        public bool Modificar(AlquilerRequest Alquiler)
        {
            var cambio = false;
            if(ClienteId != Alquiler.ClienteId)
            {
                ClienteId = Alquiler.ClienteId;
                cambio = true;
            }
            if (FechaDeEntrega != Alquiler.FechaDeEntrega)
            {
                FechaDeEntrega = Alquiler.FechaDeEntrega;
                cambio = true;
            }
            if (Fecha != Alquiler.Fecha)
            {
                Fecha = Alquiler.Fecha;
                cambio = true;
            }
            if (Total != Alquiler.Total)
            {
                Total = Alquiler.Total;
                cambio = true;
            }
            return cambio;

        }

        public AlquilerResponse toRespose()
            => new AlquilerResponse()
            {
                ClienteId = ClienteId,
                FechaDeEntrega = FechaDeEntrega,
                Fecha = Fecha,
                Total = Total,

            };


    }
    
}
