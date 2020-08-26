using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SmartAutos.Models;

namespace SmartAutos.Database
{
    public partial class SmartAutosContext : DbContext
    {
        public SmartAutosContext()
        {
        }

        public SmartAutosContext(DbContextOptions<SmartAutosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Colour> Colour { get; set; }
        public virtual DbSet<Manufacturer> Manufacturer { get; set; }
        public virtual DbSet<Model> Model { get; set; }
        public virtual DbSet<Vehicle> Vehicle { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=SmartAutos;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Colour>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Model>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.Model)
                    .HasForeignKey(d => d.ManufacturerId)
                    .HasConstraintName("FK__Model__Manufactu__0519C6AF");
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.Property(e => e.Registration)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.HasOne(d => d.ColourNavigation)
                    .WithMany(p => p.Vehicle)
                    .HasForeignKey(d => d.Colour)
                    .HasConstraintName("FK__Vehicle__Colour__0EA330E9");

                entity.HasOne(d => d.ModelNavigation)
                    .WithMany(p => p.Vehicle)
                    .HasForeignKey(d => d.Model)
                    .HasConstraintName("FK__Vehicle__Model__0DAF0CB0");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<SmartAutos.Models.VehicleViewModel> VehicleViewModel { get; set; }
    }
}
