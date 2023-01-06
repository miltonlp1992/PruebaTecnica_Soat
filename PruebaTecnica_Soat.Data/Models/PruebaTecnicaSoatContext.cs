using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace PruebaTecnica_Soat.Data.Models
{
    public partial class PruebaTecnicaSoatContext : DbContext
    {
       
        public PruebaTecnicaSoatContext()
        {
            
        }        

        public PruebaTecnicaSoatContext(DbContextOptions<PruebaTecnicaSoatContext> options)
            : base(options)
        {
            
        }

        public virtual DbSet<Ciudad> Ciudads { get; set; }
        public virtual DbSet<Poliza> Polizas { get; set; }
        public virtual DbSet<Tomador> Tomadors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            if (!optionsBuilder.IsConfigured)
            {     
                optionsBuilder.UseSqlServer("Server=(local)\\SQL2012; Database=PruebaTecnicaSoat; Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Ciudad>(entity =>
            {
                entity.ToTable("Ciudad");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PermiteSoat)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Poliza>(entity =>
            {
                entity.ToTable("Poliza");

                entity.Property(e => e.FechaFin).HasColumnType("datetime");

                entity.Property(e => e.FechaInicio).HasColumnType("datetime");

                entity.Property(e => e.FechaVencPolizaActual).HasColumnType("datetime");

                entity.Property(e => e.Placa)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCiudadNavigation)
                    .WithMany(p => p.Polizas)
                    .HasForeignKey(d => d.IdCiudad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Poliza_Ciudad");

                entity.HasOne(d => d.IdTomadorNavigation)
                    .WithMany(p => p.Polizas)
                    .HasForeignKey(d => d.IdTomador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Poliza_Tomador");
            });

            modelBuilder.Entity<Tomador>(entity =>
            {
                entity.ToTable("Tomador");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NroDocumento)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
