using Alquilandome.Data.entities;
using Microsoft.EntityFrameworkCore;

namespace Alquilandome.Data.Context
{
    public interface IMyDbContext
    {
       public DbSet<Alquiler> Alquiler { get; set; }
        public DbSet<AlquilerDetalleRequest> AlquilerDetalle { get; set; }
        public DbSet<Articulo> Articulo { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}