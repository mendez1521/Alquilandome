using Alquilandome.Data.Request;

namespace Alquilandome.Data.Services
{
    public interface IUsuarioServices
    {
        Task<Result<List<UsuarioRequest>>> Consultar(string filtro);
        Task<Result> Crear(UsuarioRequest request);
        Task<Result> Eliminar(UsuarioRequest request);
        Task<Result> Modificar(UsuarioRequest request);
    }
}