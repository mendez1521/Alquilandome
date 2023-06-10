using Alquilandome.Data.Request;

namespace Alquilandome.Data.Services
{
    public interface IClienteServices
    {
        Task<Result<List<ClienteRequest>>> Consultar(string filtro);
        Task<Result> Crear(ClienteRequest request);
        Task<Result> Eliminar(ArticuloRequest request);
        Task<Result> Modificar(ClienteRequest request);
    }
}