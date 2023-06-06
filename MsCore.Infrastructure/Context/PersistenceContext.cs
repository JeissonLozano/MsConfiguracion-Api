using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MsCore.Domain.Entities;

namespace MsCore.Infrastructure.Context
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

            modelBuilder.Entity<Zona>();

            modelBuilder.Entity<Equipo>()
                .HasOne(x => x.TipoEquipo)
                .WithMany(x => x.Equipos)
                .HasForeignKey(x => x.IdTipoEquipo)
                .IsRequired(false);

            base.OnModelCreating(modelBuilder);
        }

    }
}
