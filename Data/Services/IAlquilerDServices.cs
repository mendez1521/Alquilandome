using Alquilandome.Data.Request;

namespace Alquilandome.Data.Services
{
    public interface IAlquilerDServices
    {
        Task<Result<List<AlquilerDetalleRequest>>> Consultar(string filtro);
        Task<Result> Crear(AlquilerDetalleRequest request);
        Task<Result> Eliminar(AlquilerDetalleRequest request);
        Task<Result> Modificar(AlquilerDetalleRequest request);
    }
}