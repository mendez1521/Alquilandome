using System;
using Alquilandome.Data.Context;
using Microsoft.EntityFrameworkCore;
using Alquilandome.Data.Response;
using Alquilandome.Data.Request;
using Alquilandome.Data.entities;
namespace Alquilandome.Data.Services
{
    public interface IArticuloServices
    {
        Task<Result<List<ArticuloResponse>>> Consultar(string filtro);
        Task<Result> Crear(ArticuloRequest request);
        Task<Result> Eliminar(ArticuloRequest request);
        Task<Result> Modificar(ArticuloRequest request);
    }

    public class ArticuloServices : IArticuloServices
    {
        private readonly IMyDbContext dbContext;

        public ArticuloServices(IMyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Result> Crear(ArticuloRequest request)
        {
            try
            {
                var articulo = Articulo.crear(request);
                dbContext.Articulos.Add(articulo);
                await dbContext.SaveChangesAsync();
                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {
                return new Result() { Message = E.Message, Success = false };
            }
        }

        public async Task<Result> Modificar(ArticuloRequest request)
        {
            try
            {
                var articulo = await dbContext.Articulos
                .FirstOrDefaultAsync(a => a.Id == request.Id);
                if (articulo == null)
                    return new Result() { Message = "Articulo no modificado...", Success = false };

                if (articulo.Modificar(request))
                    await dbContext.SaveChangesAsync();

                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {
                return new Result() { Message = E.Message, Success = false };
            }
        }
        public async Task<Result> Eliminar(ArticuloRequest request)
        {
            try
            {
                var Articulo = await dbContext.Articulos
                .FirstOrDefaultAsync(a => a.Id == request.Id);
                if (Articulo == null)
                    return new Result() { Message = "Articulo no modificado...", Success = false };

                dbContext.Articulos.Remove(Articulo);
                await dbContext.SaveChangesAsync();

                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {
                return new Result() { Message = E.Message, Success = false };
            }
        }

        public async Task<Result<List<ArticuloResponse>>> Consultar(string filtro)
        {
            try
            {
                var articulos = await dbContext.Articulos
                    .Where(a =>
                    (a.Referencia + " " + a.Descripción + " " + a.Cantidad + " " + a.PrecioAlquiler + " " + a.PrecioAlquiler)
                    .ToLower()
                    .Contains(filtro.ToLower()
                    )
                    )
                    .Select(a => a.ToResponse())
                    .ToListAsync();
                return new Result<List<ArticuloResponse>>()
                {
                    Message = "Ok",
                    Success = true,
                    Data = articulos
                };
            }
            catch (Exception E)
            {
                return new Result<List<ArticuloResponse>>
                {
                    Message = E.Message,
                    Success = false
                };
            }
        }

    }
}