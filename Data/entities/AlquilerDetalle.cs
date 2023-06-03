using Alquilandome.Data.Request;
using Alquilandome.Data.Response;
using Microsoft.AspNetCore.ResponseCaching;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alquilandome.Data.entities
{
    // Clase AlquilerDetalle
    public class AlquilerDetalle
    {
        [Key]
        public int Id { get; set; }
        public int AlquilerId { get; set; }
        
        [ForeignKey("AlquilerId")]
        public virtual Alquiler Alquiler { get; set; }

        public int ArticuloId { get; set; }
        
        [ForeignKey("ArticuloId")]
        public virtual Articulo Articulo { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioAlquiler { get; set; }
        public bool Recibido { get; set; }

        public static AlquilerDetalle Crear(AlquilerDetalleRequest AlquilerDEtalle)
        =>new AlquilerDetalle()
       {
           AlquilerId = AlquilerDEtalle.AlquilerId,
           ArticuloId = AlquilerDEtalle.ArticuloId,
           Cantidad = AlquilerDEtalle.Cantidad,
           PrecioAlquiler = AlquilerDEtalle.PrecioAlquiler,

       };
        public AlquilerDetalleResponse ToResponse()
            => new AlquilerDetalleResponse()
            {
                AlquilerId = AlquilerId,
                ArticuloId = ArticuloId,
                Articulo = Articulo.ToResponse(),
                Cantidad = Cantidad,
                PrecioAlquiler = PrecioAlquiler,

            };
    }

}
