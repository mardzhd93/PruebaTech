using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebApiPermisos.Models
{
    public partial class ForTechContext : DbContext
    {
        public ForTechContext()
        {
        }

        public ForTechContext(DbContextOptions<ForTechContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Permiso> Permisos { get; set; }
        public virtual DbSet<TipoPermiso> TipoPermisos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=MIGUELANGEL;Initial Catalog=ForTech;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Permiso>(entity =>
            {
                entity.ToTable("Permiso");

                entity.Property(e => e.ApellidosEmpleado)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaPermiso).HasColumnType("datetime");

                entity.Property(e => e.NombreEmpleado)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                //entity.HasOne(d => d.TipoPermisoNavigation)
                //    .WithMany(p => p.Permisos)
                //    .HasForeignKey(d => d.TipoPermiso)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_TipoPermiso");
            });

            modelBuilder.Entity<TipoPermiso>(entity =>
            {
                entity.ToTable("TipoPermiso");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
