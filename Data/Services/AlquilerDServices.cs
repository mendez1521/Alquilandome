using Alquilandome.Data.Context;
using Alquilandome.Data.entities;
using Alquilandome.Data.Request;

namespace Alquilandome.Data.Services
{
    


    public class AlquilerDServices : IAlquilerDServices
    {
        private readonly IMyDbContext dbContext;

        public AlquilerDServices(IMyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Result> Crear(AlquilerDetalleRequest request)
        {
            try
            {
                var alquilerDetalle = AlquilerDetalle.Crear(request);
                dbContext.AlquileresDetalles.Add(alquilerDetalle);
                await dbContext.SaveChangesAsync();
                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {
                return new Result() { Message = E.Message, Success = false };
            }
        }

        public async Task<Result> Modificar(AlquilerDetalleRequest request)
        {
            try
            {
                var alquilerDetalle = await dbContext.AlquileresDetalles
                .FirstOrDefaultAsync(a => a.Id == request.Id);
                if (alquilerDetalle == null)
                    return new Result() { Message = "Alquiler no modificado...", Success = false };

                if (alquilerDetalle.Modificar(request))
                    await dbContext.SaveChangesAsync();

                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {
                return new Result() { Message = E.Message, Success = false };
            }
        }
        public async Task<Result> Eliminar(AlquilerDetalleRequest request)
        {
            try
            {
                var alquilerDetalle = await dbContext.AlquileresDetalles
                .FirstOrDefaultAsync(a => a.Id == request.Id);
                if (alquilerDetalle == null)
                    return new Result() { Message = "Alquiler no modificado...", Success = false };

                dbContext.AlquileresDetalles.Remove(alquilerDetalle);
                await dbContext.SaveChangesAsync();

                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {
                return new Result() { Message = E.Message, Success = false };
            }
        }

        public async Task<Result<List<AlquilerDetalleRequest>>> Consultar(string filtro)
        {
            try
            {
                var AlquilerDetalle = await dbContext.AlquileresDetalles
                    .Where(a =>
                    (a.Alquiler + " " + a.Articulo + " " + a.Cantidad + " " + a.PrecioAlquiler + " " + a.Recibido)
                    .Tolower()
                    .Contains(filtro.ToLower()
                    )
                    )
                    .Select(a => a.ToResponce())
                    .ToListAsync();
                return new Result<List<AlquilerDetalleRequest>>()
                {
                    Message = "Ok",
                    Success = true,
                    Data = AlquilerDetalle
                };
            }
            catch (Exception E)
            {
                return new Result<List<AlquilerDetalleRequest>>
                {
                    Message = E.Message,
                    Success = false
                };
            }
        }

    }
}