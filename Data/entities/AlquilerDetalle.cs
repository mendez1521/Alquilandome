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
        public int ArticuloId { get; set; }
        public int Cantidad { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecioAlquiler { get; set; }

        public static AlquilerDetalle Crear(AlquilerDetalleRequest request)
        => new()
        {
            ArticuloId = request.ArticuloId,
            Cantidad = request.Cantidad,
            PrecioAlquiler = request.PrecioAlquiler,
        };


        #region Relaciones
        [ForeignKey(nameof(AlquilerId))]
        public virtual Alquiler Alquiler { get; set; }
        [ForeignKey(nameof(ArticuloId))]
        public virtual Articulo Articulo { get; set; }
        #endregion

        [NotMapped]
        public decimal SubTotal => Cantidad * PrecioAlquiler;
        public AlquilerDetalleResponse ToResponse()
            => new AlquilerDetalleResponse()
            {
                AlquilerId = AlquilerId,
                Articulo = Articulo.ToResponse(),
                Cantidad = Cantidad,
                PrecioAlquiler = PrecioAlquiler,
            };
    }

}
