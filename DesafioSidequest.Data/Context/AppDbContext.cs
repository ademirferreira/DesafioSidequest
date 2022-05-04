using System.Security.Cryptography.X509Certificates;
using DesafioSidequest.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioSidequest.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options){}

        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().HasKey(c => c.Id);

            modelBuilder.Entity<Cliente>()
                .Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(400)");

            modelBuilder.Entity<Cliente>()
                .Property(c => c.Documento)
                .IsRequired()
                .HasColumnType("varchar(11)");

            modelBuilder.Entity<Cliente>()
                .Property(c => c.Telefone)
                .IsRequired()
                .HasColumnType("varchar(15)");

            modelBuilder.Entity<Cliente>()
                .Property(c => c.Email)
                .IsRequired()
                .HasColumnType("varchar(200)");
        }
    }
}