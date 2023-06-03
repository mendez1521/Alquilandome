using Alquilandome.Data.entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace Alquilandome.Data.Context

{
    public class MyDbContext : DbContext, IMyDbContext
    {
        private readonly IConfiguration configuration;

        public MyDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public DbSet<Alquiler> Alquileres { get; set; }
        public DbSet<AlquilerDetalle> AlquileresDetalles { get; set; }
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: configuration.GetConnectionString(name: "MSSQL"));
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }

}
