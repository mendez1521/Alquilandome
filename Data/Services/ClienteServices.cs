using System;
using Alquilandome.Data.Context;
using Microsoft.EntityFrameworkCore;
using Alquilandome.Data.Response;
using Alquilandome.Data.Request;
using Alquilandome.Data.entities;
namespace Alquilandome.Data.Services
{
    public interface IClienteServices
    {
        Task<Result<List<ClienteResponse>>> Consultar(string filtro);
        Task<Result> Crear(ClienteRequest request);
        Task<Result> Eliminar(ClienteRequest request);
        Task<Result> Modificar(ClienteRequest request);
    }

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
                var cliente = Cliente.Crear(request);
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
                var cliente = await dbContext.Clientes
                    .FirstOrDefaultAsync(c => c.Id == request.Id);

                if (cliente == null)
                    return new Result() { Message = "Cliente no encontrado", Success = false };

                if (cliente.Modificar(request))
                    await dbContext.SaveChangesAsync();

                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {
                return new Result() { Message = E.Message, Success = false };
            }
        }

        public async Task<Result> Eliminar(ClienteRequest request)
        {
            try
            {
                var cliente = await dbContext.Clientes
                    .FirstOrDefaultAsync(c => c.Id == request.Id);

                if (cliente == null)
                    return new Result() { Message = "Cliente no encontrado", Success = false };

                dbContext.Clientes.Remove(cliente);
                await dbContext.SaveChangesAsync();

                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {
                return new Result() { Message = E.Message, Success = false };
            }
        }

        public async Task<Result<List<ClienteResponse>>> Consultar(string filtro)
        {
            try
            {
                var clientes = await dbContext.Clientes
                    .Where(c => (c.Nombre + " " + c.Cedula + " " + c.Telefono + " " + c.Direccion + " " + c.Correo + " " + c.Sexo)
                        .ToLower()
                        .Contains(filtro.ToLower()))
                    .Select(c => c.ToResponse())
                    .ToListAsync();

                return new Result<List<ClienteResponse>>()
                {
                    Message = "Ok",
                    Success = true,
                    Data = clientes
                };
            }
            catch (Exception E)
            {
                return new Result<List<ClienteResponse>>()
                {
                    Message = E.Message,
                    Success = false
                };
            }
        }
    }
}