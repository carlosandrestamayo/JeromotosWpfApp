using JeromotosWpfApp.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace JeromotosWpfApp.Persistence
{
    public class JeromotosDbContext : DbContext
    {
        public DbSet<Marca> Marcas { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            string folder = Path.Combine(
                AppContext.BaseDirectory,
                "Datos");

            Directory.CreateDirectory(folder);

            string databasePath = Path.Combine(
                folder,
                "jeromotos.db");

            optionsBuilder.UseSqlite(
                $"Data Source={databasePath}");
        }

        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Marca>(entity =>
            {
                entity.ToTable("Marcas");

                entity.HasKey(m => m.Id);

                entity.Property(m => m.Nombre)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(m => m.Activo)
                    .IsRequired();
            });
        }
    }
}