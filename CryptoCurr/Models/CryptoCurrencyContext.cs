using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CryptoCurr.Models
{
    public partial class CryptoCurrencyContext : DbContext
    {
        public CryptoCurrencyContext()
        {
        }

        public CryptoCurrencyContext(DbContextOptions<CryptoCurrencyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Currency> Currencies { get; set; } = null!;
        public virtual DbSet<History> Histories { get; set; } = null!;
        public virtual DbSet<Market> Markets { get; set; } = null!;
        public virtual DbSet<Price> Prices { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-B6DS7BT\\SQLEXPRESS;Database=CryptoCurrency1;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>(entity =>
            {
                entity.HasIndex(e => e.PriceId, "IX_Currencies_PriceId");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(20);

                entity.Property(e => e.Symbol).HasMaxLength(5);

                entity.HasOne(d => d.Price)
                    .WithMany(p => p.Currencies)
                    .HasForeignKey(d => d.PriceId);
            });

            modelBuilder.Entity<History>(entity =>
            {
                entity.HasIndex(e => e.CryptoCurrencyId, "IX_Histories_CryptoCurrencyId");

                entity.HasOne(d => d.CryptoCurrency)
                    .WithMany(p => p.Histories)
                    .HasForeignKey(d => d.CryptoCurrencyId);
            });

            modelBuilder.Entity<Market>(entity =>
            {
                entity.HasIndex(e => e.CryptoCurrencyId, "IX_Markets_CryptoCurrencyId");

                entity.HasIndex(e => e.PriceId, "IX_Markets_PriceId");

                entity.Property(e => e.Name).HasMaxLength(25);

                entity.HasOne(d => d.CryptoCurrency)
                    .WithMany(p => p.Markets)
                    .HasForeignKey(d => d.CryptoCurrencyId);

                entity.HasOne(d => d.Price)
                    .WithMany(p => p.Markets)
                    .HasForeignKey(d => d.PriceId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
