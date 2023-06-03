using Alquilandome.Data.Context;
using Microsoft.EntityFrameworkCore;
using Alquilandome.Data.Response;


namespace Alquilandome.Data.Services;

public class AlquierServices
{
    
    private readonly IMyDbContext dbContext;

    public AlquierServices(IMyDbContext dbContext){
        this.dbContext = dbContext;
    }

    public async Task<Result> Crear(AlquilerRequest request)
    {
        try
        {
            var alquiler = Alquiler.Crear(request);
            dbContext.Alquileres.Add(alquiler);
            await dbContext.SaveChangesAsync();
            return new Result(){ Message = "Ok", Success = true };
        }
        catch(Exception E){
            return new Result(){ Message = E.Message, Success = false };
        }
    }
    public async Task<Result> Eliminar(AlquilerRequest request)
    {
        try
        {
            var alquiler = dbContext.Alquileres
            .Include(a=>a.Detalles)
            .FirstOrDefaultAsync(a=>a.Id == request.Id);
            if(alquiler==null)
                return new Result(){ Message = "El alquiler no se encontró...", Success = false };
            dbContext.Alquileres.Remove(alquiler);
            await dbContext.SaveChangesAsync();
            return new Result(){ Message = "Ok", Success = true };
        }
        catch(Exception E){
            return new Result(){ Message = E.Message, Success = false };
        }
    }
    public async Task<Result<List<AlquilerResponse>>> Consultar(string filtro)
    {
        try
        {
            var alquileres = await dbContext.Alquileres
            .Include(a=>a.Cliente)
            .Include(a=>a.Detalles)
            .ThenInclude(d=>d.Articulo)
            .Where(a=>a.Cliente.Nombre.ToLower().Container(filtro.ToLower()))
            .Select(a=>a.ToResponse())
            .ToListAsync();

            return new Result<List<AlquilerResponse>>(){ Message = "Ok", Success = true, Data = alquileres };
        }
        catch(Exception E){
            return new Result<List<AlquilerResponse>>(){ Message = E.Message, Success = false, Data = null };
        }
    }
}

public class Result
{
    public bool Success{ get; set; }
    public string? Message{ get; set; }

}
public class Result<T>
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public T? Data { get; set; }

}