using System;
using Alquilandome.Data.Context;
using Alquilandome.Data.entities;
using Alquilandome.Data.Request;
using Alquilandome.Data.Response;
using Microsoft.EntityFrameworkCore;

namespace Alquilandome.Data.Services
{
    public interface IUsuarioServices
    {
        Task<Result<List<UsuarioResponse>>> Consultar(string filtro);
        Task<Result> Crear(UsuarioRequest request);
        Task<Result> Eliminar(UsuarioRequest request);
        Task<Result> Modificar(UsuarioRequest request);
    }

    public class UsuarioServices : IUsuarioServices
    {
        private readonly IMyDbContext dbContext;

        public UsuarioServices(IMyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Result> Crear(UsuarioRequest request)
        {
            try
            {
                var usuario = Usuario.Crear(request);
                dbContext.Usuarios.Add(usuario);
                await dbContext.SaveChangesAsync();
                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {
                return new Result() { Message = E.Message, Success = false };
            }
        }

        public async Task<Result> Modificar(UsuarioRequest request)
        {
            try
            {
                var usuario = await dbContext.Usuarios
                .FirstOrDefaultAsync(a => a.Id == request.Id);
                if (usuario == null)
                    return new Result() { Message = "Usuario no modificado...", Success = false };

                if (usuario.Modificar(request))
                    await dbContext.SaveChangesAsync();

                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {
                return new Result() { Message = E.Message, Success = false };
            }
        }
        public async Task<Result> Eliminar(UsuarioRequest request)
        {
            try
            {
                var Usuario = await dbContext.Usuarios
                .FirstOrDefaultAsync(a => a.Id == request.Id);
                if (Usuario == null)
                    return new Result() { Message = "Usuario no modificado...", Success = false };

                dbContext.Usuarios.Remove(Usuario);
                await dbContext.SaveChangesAsync();

                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {
                return new Result() { Message = E.Message, Success = false };
            }
        }

        public async Task<Result<List<UsuarioResponse>>> Consultar(string filtro)
        {
            try
            {
                var usuario = await dbContext.Usuarios
                    .Where(a =>
                    (a.Nombre + " "+ a.Nickname +" "+ a.Password + " " + a.Email + " " + a.Rol)
                    .ToLower()
                    .Contains(filtro.ToLower()
                    )
                    )
                    .Select(a => a.toResponse())
                    .ToListAsync();
                return new Result<List<UsuarioResponse>>()
                {
                    Message = "Ok",
                    Success = true,
                    Data = usuario
                };
            }
            catch (Exception E)
            {
                return new Result<List<UsuarioResponse>>
                {
                    Message = E.Message,
                    Success = false
                };
            }
        }
    }
}