using System;
using Alquilandome.Data.Context;
using Microsoft.EntityFrameworkCore;
using Alquilandome.Data.Response;
using Alquilandome.Data.Request;
using Alquilandome.Data.entities;
namespace Alquilandome.Data.Services
{
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
                var Articulo = await dbContext.Articulos
                .FirstOrDefaultAsync(a => a.Id == request.Id);
                if (Articulo == null)
                    return new Result() { Message = "Articulo no modificado...", Success = false };

                if (Articulo.Modificar(request))
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

        public async Task<Result<List<ArticuloRequest>>> Consultar(string filtro)
        {
            try
            {
                var Articulo = await dbContext.Articulos
                    .Where(a =>
                    (a.Referencia + " " + a.Descripcion + " " + a.Cantidad + " " + a.PrecioAlquiler + " " + a.PrecioAlquiler)
                    .Tolower()
                    .Contains(filtro.ToLower()
                    )
                    )
                    .Select(a => a.ToResponce())
                    .ToListAsync();
                return new Result<List<ArticuloRequest>>()
                {
                    Message = "Ok",
                    Success = true,
                    Data = Articulo
                };
            }
            catch (Exception E)
            {
                return new Result<List<ArticuloRequest>>
                {
                    Message = E.Message,
                    Success = false
                };
            }
        }

    }
}