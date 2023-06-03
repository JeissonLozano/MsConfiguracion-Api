using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MsConfiguracion.Domain.Entities;

namespace MsConfiguracion.Infrastructure.Context
{
    public class PersistenceContext : DbContext
    {
        private readonly IConfiguration _config;

        public PersistenceContext(DbContextOptions<PersistenceContext> options, IConfiguration config) : base(options)
        {
            _config = config;
        }

        public async Task CommitAsync()
        {
            await SaveChangesAsync().ConfigureAwait(false);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                return;
            }

            modelBuilder.HasDefaultSchema(_config["SchemaName"]);
            modelBuilder.Entity<TipoEquipo>()
                .HasOne(Equipos => Equipos.Equipo)
                .WithOne(TipoEquipo => TipoEquipo.TipoEquipo)
                .HasForeignKey<Equipo>(TipoEquipo => TipoEquipo.IdTipoEquipo);

            modelBuilder.Entity<Zona>();

            modelBuilder.Entity<Equipo>();

            base.OnModelCreating(modelBuilder);
        }

    }
}
