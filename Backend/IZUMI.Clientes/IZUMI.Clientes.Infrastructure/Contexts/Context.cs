using IZUMI.Clientes.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace IZUMI.Clientes.Infrastructure.Contexts
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {}

        public DbSet<ClienteModel> ClienteModels { get; set; }
        public DbSet<PlanModel> PlanModels { get; set; }
        public DbSet<TipoDocumentoModel> TipoDocumentoModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClienteModel>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.NumeroDocumento)
                      .HasMaxLength(20)
                      .IsRequired();

                entity.Property(e => e.PrimerNombre)
                      .HasMaxLength(100)
                      .IsRequired();

                entity.Property(e => e.Email)
                      .HasMaxLength(150)
                      .IsRequired();

                entity.HasIndex(e => e.NumeroDocumento).IsUnique();
                entity.HasIndex(e => e.Email).IsUnique();

                entity.HasOne(e => e.TipoDocumento)
                      .WithMany()
                      .HasForeignKey(e => e.TipoDocumentoId);

                entity.HasOne(e => e.Plan)
                      .WithMany()
                      .HasForeignKey(e => e.PlanId);
            });

            modelBuilder.Entity<PlanModel>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nombre).HasMaxLength(100).IsRequired();
            });

            modelBuilder.Entity<TipoDocumentoModel>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nombre).HasMaxLength(50).IsRequired();
            });
        }
    }
}
