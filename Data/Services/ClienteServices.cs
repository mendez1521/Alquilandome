using System;
using Alquilandome.Data.Context;
using Microsoft.EntityFrameworkCore;
using Alquilandome.Data.Response;
using Alquilandome.Data.Request;
using Alquilandome.Data.entities;
namespace Alquilandome.Data.Services
{
    


    public class ClienteServices : IClienteServices
    {
        private readonly IMyDbContext dbContext;

        public ClienteServices(IMyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Result> Crear(ClienteRequest request)
        {
            try
            {
                var cliente = Cliente.crear(request);
                dbContext.Clientes.Add(cliente);
                await dbContext.SaveChangesAsync();
                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {
                return new Result() { Message = E.Message, Success = false };
            }
        }

        public async Task<Result> Modificar(ClienteRequest request)
        {
            try
            {
                var Cliente = await dbContext.Clientes
                .FirstOrDefaultAsync(a => a.Id == request.Id);
                if (Cliente == null)
                    return new Result() { Message = "Cliente no modificado...", Success = false };

                if (Cliente.Modificar(request))
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
                var Cliente = await dbContext.Clientes
                .FirstOrDefaultAsync(a => a.Id == request.Id);
                if (Cliente == null)
                    return new Result() { Message = "Cliente no modificado...", Success = false };

                dbContext.Clientes.Remove(Cliente);
                await dbContext.SaveChangesAsync();

                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {
                return new Result() { Message = E.Message, Success = false };
            }
        }

        public async Task<Result<List<ClienteRequest>>> Consultar(string filtro)
        {
            try
            {
                var Cliente = await dbContext.Clientes
                    .Where(a =>
                    (a.Nombre + " " + a.Cedula + " " + a.Telefono + " " + a.Direccion + " " + a.Correo + " " + a.Sexo)
                    .Tolower()
                    .Contains(filtro.ToLower()
                    )
                    )
                    .Select(a => a.ToResponce())
                    .ToListAsync();
                return new Result<List<ClienteRequest>>()
                {
                    Message = "Ok",
                    Success = true,
                    Data = Cliente
                };
            }
            catch (Exception E)
            {
                return new Result<List<ClienteRequest>>
                {
                    Message = E.Message,
                    Success = false
                };
            }
        }

    }
}