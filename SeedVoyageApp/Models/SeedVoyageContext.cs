using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SeedVoyageApp.Models;

namespace SeedVoyageApp.Models
{
    public partial class SeedVoyageContext : DbContext
    {
        public SeedVoyageContext()
        {
        }

        public SeedVoyageContext(DbContextOptions<SeedVoyageContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Produce> Produce { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-ENKI8E7\\SQLEXPRESS;Database=SeedVoyage;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produce>(entity =>
            {
                entity.ToTable("produce");

                entity.Property(e => e.ProduceId).HasColumnName("produceId");

                entity.Property(e => e.GrowerEmail)
                    .IsRequired()
                    .HasColumnName("growerEmail")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ProduceImage)
                    .HasColumnName("produceImage")
                    .HasColumnType("varchar(16)");

                entity.Property(e => e.ProduceName)
                    .IsRequired()
                    .HasColumnName("produceName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Quantity).HasColumnName("quantity");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<SeedVoyageApp.Models.ProductsList> ProductsList { get; set; }
    }
}
