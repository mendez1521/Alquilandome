using System;
using Alquilandome.Data.Context;
using Microsoft.EntityFrameworkCore;
using Alquilandome.Data.Response;
using Alquilandome.Data.Request;
using Alquilandome.Data.entities;
namespace Alquilandome.Data.Services
{
    public class Resul
{
    public bool Success{ get; set; }
    public string? Message{ get; set; }

}
    

    public class AlticuloServices
    {
        private readonly IMyDbContext dbContext;

        public AlticuloServices(IMyDbContext dbContext) {
            this.dbContext = dbContext;
        }
        public async Task<Result> Crear(ArticuloRequest request)
    {
        try
        {
            var Alticulo = Articulo.Crear(request);
            dbContext.Articulos.Add(Alticulo);
            await dbContext.SaveChangesAsync();
            return new Result(){ Message = "Ok", Success = true };
        }
        catch(Exception E){
            return new Result(){ Message = E.Message, Success = false };
        }
    }

        private async Task<Result> Modificar( ArticuloRequest request)
        {
            try
            {
                var alticulo = await dbContext.Articulos
                .FirstOrDefaultAsync(a => a.Id== request.Id);
                if (alticulo == null)
                    return new Result() { Message = "Alticulo no modificado...", Success = false };

                alticulo.Modificar(request);
                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {
                return new Result() { Message = E.Message, Success = false };
            }
        }

    }
}