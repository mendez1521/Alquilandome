using Alquilandome.Data.Context;
using Microsoft.EntityFrameworkCore;
using Alquilandome.Data.Response;
using Alquilandome.Data.Request;
using Alquilandome.Data.entities;

namespace Alquilandome.Data.Services;

public interface IAlquilerServices
{
    Task<Result<List<AlquilerResponse>>> Consultar();
    Task<Result<AlquilerResponse>> Crear(AlquilerRequest request);
    Task<Result> Eliminar(AlquilerRequest request);
}

public class AlquilerServices : IAlquilerServices
{

    private readonly IMyDbContext dbContext;

    public AlquilerServices(IMyDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Result<AlquilerResponse>> Crear(AlquilerRequest request)
    {
        try
        {
            var alquiler = Alquiler.Crear(request);
            dbContext.Alquileres.Add(alquiler);
            await dbContext.SaveChangesAsync();
            return new Result<AlquilerResponse>()
            {
                Data = alquiler.ToResponse(),
                Success = true,
                Message = "Ok"
            };
        }
        catch (Exception E)
        {
            return new Result<AlquilerResponse>()
            {
                Data = null,
                Success = false,
                Message = E.Message
            };
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
    public async Task<Result<List<AlquilerResponse>>> Consultar()
    {
        try
        {
            var facturas = await dbContext.Alquileres
                .Include(f => f.cliente)
                .Include(f => f.Detalles)
                .ThenInclude(d => d.Articulo)
                .Select(f => f.ToResponse())
                .ToListAsync();
            return new Result<List<AlquilerResponse>>()
            {
                Data = facturas,
                Success = true,
                Message = "Ok"
            };
        }
        catch (Exception E)
        {
            return new Result<List<AlquilerResponse>>()
            {
                Data = null,
                Success = false,
                Message = E.Message
            };
        }
    }
}
