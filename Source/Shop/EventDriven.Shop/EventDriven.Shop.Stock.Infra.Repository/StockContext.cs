using EventDriven.Shop.Stock.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace EventDriven.Shop.Stock.Infra.Repository
{
    public class StockContext : DbContext
    {
        public StockContext(DbContextOptions<StockContext> options) : base(options)
        {

        }
        public DbSet<Estoque> Estoques { get; set; }

        public DbSet<Produto> Produtos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estoque>(entity =>
            {

                entity.HasKey(c => c.Id);
                entity.Property(p => p.QuantidadeDisponivel)
                    .HasColumnType("int");
                entity.HasOne(p => p.Produto)
                    .WithOne()
                    .HasForeignKey<Produto>(p => p.Id);

            });
            

            modelBuilder.Entity<Produto>().ToTable("Produto");
        }
    }
}
