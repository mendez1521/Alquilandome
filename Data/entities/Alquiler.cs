using System.ComponentModel.DataAnnotations.Schema;
using Alquilandome.Data.Request;
using Alquilandome.Data.Response;
using System.ComponentModel.DataAnnotations;

namespace Alquilandome.Data.entities
{
    // Clase Alquiler
    public class Alquiler
    {
                                                                                                                         
        [Key]
        public int Id { get; set; }

        public int ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public virtual Cliente Cliente { get; set;}

        public DateTime FechaDeEntrega { get; set; }

        public DateTime Fecha { get; set; }

        public decimal Total { get; set; }

        public virtual ICollection<AlquilerDetalle> Detalles {get; set;}

        public static Alquiler  Crear (AlquilerRequest Alquiler)
        =>new Alquiler()
        {
        ClienteId = Alquiler.ClienteId,
        FechaDeEntrega=Alquiler.FechaDeEntrega,
        Fecha=Alquiler.Fecha,
        Total=Alquiler.Total,
        Detalles = Alquiler.Detalles
        .Select(d=>AlquilerDetalle.Crear(d))
        .ToList()
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

        public AlquilerResponse ToResponse()
            => new AlquilerResponse()
            {
                ClienteId = ClienteId,
                Cliente = Cliente.ToResponse(),
                FechaDeEntrega = FechaDeEntrega,
                Fecha = Fecha,
                Total = Total,
                Detalles = Detalles.Select(d=>d.ToResponse()).ToList()
            };


    }
    
}
