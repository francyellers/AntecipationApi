using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntecipationApi.Models
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options)
            : base(options)
        { }

        public DbSet<Solicitation> Solicitations { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Solicitation)
                .WithMany(s => s.Transactions)
                .HasForeignKey(t => t.SolicitationId)
                .HasPrincipalKey(s => s.SolicitationId);

            modelBuilder.Entity<Transaction>()
                .HasKey(t => t.TransactionId);

            modelBuilder.Entity<Transaction>()
                .Property(t => t.TransactionId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Transaction>()
               .Property(t => t.TransactionValue)
               .HasColumnType("decimal(9, 2)");

            modelBuilder.Entity<Transaction>()
               .Property(t => t.ValueTransfer)
               .HasColumnType("decimal(9, 2)");

            modelBuilder.Entity<Solicitation>()
                .HasKey(s => s.SolicitationId);

            modelBuilder.Entity<Solicitation>()
                .Property(s => s.SolicitationId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Solicitation>()
                .Property(s => s.TotalValueTransactions)
                .HasColumnType("decimal(9, 2)");

            modelBuilder.Entity<Solicitation>()
                .Property(s => s.TotalValueTransfer)
                .HasColumnType("decimal(9, 2)");
        }
    }
}