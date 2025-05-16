using System.IO;
using Microsoft.EntityFrameworkCore;
using MotoSecurityX.Domain;

namespace MotoSecurityX.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Moto> Motos { get; set; }
        public DbSet<Patio> Patios { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Moto>(entity =>
            {
                entity.ToTable("MOTO");

                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("ID_MOTO");
                entity.Property(e => e.Placa).HasColumnName("PLACA");
                entity.Property(e => e.Modelo).HasColumnName("MODELO");
                entity.Property(e => e.Situacao).HasColumnName("SITUACAO");
            });

            modelBuilder.Entity<Patio>(entity =>
            {
                entity.ToTable("PATIO");

                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("ID_PATIO");
                entity.Property(e => e.Nome_local).HasColumnName("NOME_LOCAL");
            });
        }
    }
}
