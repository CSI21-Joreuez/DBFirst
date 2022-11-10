using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DBFirst.Data.Modelo
{
    public partial class BDFirstContext : DbContext
    {
        public BDFirstContext()
        {
        }

        public BDFirstContext(DbContextOptions<BDFirstContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Empleado> Empleados { get; set; } = null!;
        public virtual DbSet<NivelAcceso> NivelAccesos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=BDFirst;User Id=postgres;Password=pr0f3s0r");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.ToTable("empleados");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Edad).HasColumnName("edad");

                entity.Property(e => e.Email)
                    .HasMaxLength(2)
                    .HasColumnName("email");

                entity.Property(e => e.Nombre).HasColumnName("nombre");
            });

            modelBuilder.Entity<NivelAcceso>(entity =>
            {
                entity.ToTable("nivelAccesos");

                entity.HasIndex(e => e.Empleadoid1, "IX_nivelAccesos_Empleadoid");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EmpleadoId).HasColumnName("empleadoId");

                entity.Property(e => e.Empleadoid1).HasColumnName("Empleadoid");

                entity.Property(e => e.GradoAcceso).HasColumnName("gradoAcceso");

                entity.HasOne(d => d.Empleadoid1Navigation)
                    .WithMany(p => p.NivelAccesos)
                    .HasForeignKey(d => d.Empleadoid1);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
