using FornecedoresApp.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace FornecedoresApp.Infrastructure
{
    public class FornecedoresDbContext(DbContextOptions<FornecedoresDbContext> options) : DbContext(options)
    {
        public DbSet<Fornecedor> Fornecedores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fornecedor>()
                .HasKey(f => f.Id);

            modelBuilder.Entity<Fornecedor>()
                .Property(f => f.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Fornecedor>()
                .Property(f => f.DataCadastro)
                .HasDefaultValueSql("GETDATE()");

            base.OnModelCreating(modelBuilder);
        }
    }
}
