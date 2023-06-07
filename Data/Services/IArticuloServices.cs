using Alquilandome.Data.Request;

namespace Alquilandome.Data.Services
{
    public interface IArticuloServices
    {
        Task<Result<List<ArticuloRequest>>> Consultar(string filtro);
        Task<Result> Crear(ArticuloRequest request);
        Task<Result> Eliminar(ArticuloRequest request);
        Task<Result> Modificar(ArticuloRequest request);
    }
}