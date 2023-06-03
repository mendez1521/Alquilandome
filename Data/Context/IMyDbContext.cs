using Alquilandome.Data.entities;
using Microsoft.EntityFrameworkCore;

namespace Alquilandome.Data.Context
{
    public interface IMyDbContext
    {
       public DbSet<Alquiler> Alquileres { get; set; }
        public DbSet<AlquilerDetalle> AlquileresDetalles { get; set; }
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}