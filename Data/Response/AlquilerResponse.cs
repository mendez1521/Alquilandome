using System.ComponentModel.DataAnnotations.Schema;
using Alquilandome.Data.Request;

namespace Alquilandome.Data.Response
{
    public class AlquilerResponse
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public DateTime FechaDeEntrega { get; set; } = DateTime.Now.AddDays(2);
        public DateTime Fecha { get; set; } = DateTime.Now;
        public ClienteResponse Cliente {get; set;}
        public virtual ICollection<AlquilerDetalleResponse> Detalles { get; set; }

        [NotMapped]
        public decimal SubTotal =>
            Detalles != null ? //IF
            Detalles.Sum(d => d.SubTotal) //Verdadero
            :
            0;//Falso
        }
}
