using Alquilandome.Data.Context;
using Microsoft.EntityFrameworkCore;
using Alquilandome.Data.Response;
using Alquilandome.Data.Request;
using Alquilandome.Data.entities;

namespace Alquilandome.Data.Services;

public interface IAlquilerServices
{
    Task<Result<List<AlquilerResponse>>> Consultar(string filtro);
    Task<Result> Crear(AlquilerRequest request);
    Task<Result> Eliminar(AlquilerRequest request);
    Task<Result> Modificar(AlquilerRequest request);
}

public class AlquilerServices : IAlquilerServices
{

    private readonly IMyDbContext dbContext;

    public AlquilerServices(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Result> Crear(AlquilerRequest request)
    {
        try
        {
            var alquiler = Alquiler.Crear(request);
            dbContext.Alquileres.Add(alquiler);
            await dbContext.SaveChangesAsync();
            return new Result() { Message = "Ok", Success = true };
        }
        catch (Exception E)
        {
            return new Result() { Message = E.Message, Success = false };
        }
    }
    public async Task<Result> Modificar(AlquilerRequest request)
    {
        try
        {
            var alquiler = await dbContext.Alquileres
            .FirstOrDefaultAsync(a => a.Id == request.Id);
            if (alquiler == null)
                return new Result() { Message = "Articulo no modificado...", Success = false };

            if (alquiler.Modificar(request))
                await dbContext.SaveChangesAsync();

            return new Result() { Message = "Ok", Success = true };
        }
        catch (Exception E)
        {
            return new Result() { Message = E.Message, Success = false };
        }
    }
    public async Task<Result> Eliminar(AlquilerRequest request)
    {
        try
        {
            var alquiler = await dbContext.Alquileres
            .Include(a => a.Detalles)
            .FirstOrDefaultAsync(a => a.Id == request.Id);
            if (alquiler == null)
                return new Result() { Message = "El alquiler no se encontró...", Success = false };
            dbContext.Alquileres.Remove(alquiler);
            await dbContext.SaveChangesAsync();
            return new Result() { Message = "Ok", Success = true };
        }
        catch (Exception E)
        {
            return new Result() { Message = E.Message, Success = false };
        }
    }
    public async Task<Result<List<AlquilerResponse>>> Consultar(string filtro)
    {
        try
        {
            var alquileres = await dbContext.Alquileres
            .Include(a => a.Cliente)
            .Include(a => a.Detalles)
            .ThenInclude(d => d.Articulo)
            .Where(a => a.Cliente.Nombre.ToLower().Contains(filtro.ToLower()))
            .Select(a => a.ToResponse())
            .ToListAsync();

            return new Result<List<AlquilerResponse>>() { Message = "Ok", Success = true, Data = alquileres };
        }
        catch (Exception E)
        {
            return new Result<List<AlquilerResponse>>() { Message = E.Message, Success = false, Data = null };
        }
    }
}
