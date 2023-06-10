using Alquilandome.Data.Context;
using Alquilandome.Data.entities;
using Alquilandome.Data.Request;

namespace Alquilandome.Data.Services
{
    public class Result
    {
        public bool Success { get; set; }
        public string? Message { get; set; }

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
                var Usuario = Usuario.Crear(request);
                dbContext.Usuarios.Add(Usuario);
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
                var Usuario = await dbContext.Usuarios
                .FirstOrDefaultAsync(a => a.Id == request.Id);
                if (Usuario == null)
                    return new Result() { Message = "Usuario no modificado...", Success = false };

                if (Usuario.Modificar(request))
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

        public async Task<Result<List<UsuarioRequest>>> Consultar(string filtro)
        {
            try
            {
                var Usuario = await dbContext.Usuarios
                    .Where(a =>
                    (a.Nombre + " " + a.Nickname + " " + a.Password + " " + a.Email + " " + a.Rol)
                    .Tolower()
                    .Contains(filtro.ToLower()
                    )
                    )
                    .Select(a => a.ToResponce())
                    .ToListAsync();
                return new Result<List<UsuarioRequest>>()
                {
                    Message = "Ok",
                    Success = true,
                    Data = Usuario
                };
            }
            catch (Exception E)
            {
                return new Result<List<UsuarioRequest>>
                {
                    Message = E.Message,
                    Success = false
                };
            }
        }

    }
}