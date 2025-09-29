using Microsoft.EntityFrameworkCore;
using MotoSecurityX.Domain;

namespace MotoSecurityX.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // DbSets
        public DbSet<Moto> Motos { get; set; }
        public DbSet<Patio> Patios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração da tabela Motos
            modelBuilder.Entity<Moto>(entity =>
            {
                entity.ToTable("motos");
                entity.HasKey(e => e.Id);

                // Mapear para colunas em MAIÚSCULO (como está no banco)
                entity.Property(e => e.Id)
                    .HasColumnName("ID");

                entity.Property(e => e.Placa)
                    .HasColumnName("PLACA")
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Modelo)
                    .HasColumnName("MODELO")
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Situacao)
                    .HasColumnName("SITUACAO")
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasIndex(e => e.Placa).IsUnique();
            });

            // Configuração da tabela Patios
            modelBuilder.Entity<Patio>(entity =>
            {
                entity.ToTable("patios");
                entity.HasKey(e => e.Id);

                // Mapear para colunas em MAIÚSCULO (como está no banco)
                entity.Property(e => e.Id)
                    .HasColumnName("ID");

                entity.Property(e => e.Nome_local)
                    .HasColumnName("NOME_LOCAL")
                    .IsRequired()
                    .HasMaxLength(255);
            });
        }
    }
}