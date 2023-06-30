using System.ComponentModel.DataAnnotations.Schema;
using Alquilandome.Data.Request;
using Alquilandome.Data.Response;
using System.ComponentModel.DataAnnotations;

namespace Alquilandome.Data.entities
{
    // Clase Alquiler
    public class Alquiler
    {
        public Alquiler()
        {
            //Contacto = new Contacto();
            Detalles = new List<AlquilerDetalle>();
        }                                                                                                               
        [Key]
        public int Id { get; set; }
 
        public int ClienteId { get; set; }

        public DateTime FechaDeEntrega { get; set; }

        public DateTime Fecha { get; set; }

        public decimal Total { get; set; }

        public virtual ICollection<AlquilerDetalle> Detalles {get; set;}

        public static Alquiler Crear(AlquilerRequest request)
        => new()
        {
            ClienteId = request.ClienteId,
            Fecha = DateTime.Now,
            FechaDeEntrega = request.FechaDeEntrega,
            Detalles = request.Detalles
            .Select(detalle=>AlquilerDetalle.Crear(detalle))
            .ToList()
        };
    #region Relaciones
    [ForeignKey(nameof(ClienteId))]
    public virtual Cliente cliente { get; set; }
    #endregion

    [NotMapped]
    public decimal SubTotal =>
        Detalles != null ? //IF
        Detalles.Sum(d => d.SubTotal) //Verdadero
        :
        0;//Falso
        public AlquilerResponse ToResponse()
            => new AlquilerResponse()
            {
                ClienteId = ClienteId,
                Cliente = cliente.ToResponse(),
                FechaDeEntrega = FechaDeEntrega,
                Fecha = Fecha,
                Detalles = Detalles.Select(d=>d.ToResponse()).ToList()
            };


    }
    
}
