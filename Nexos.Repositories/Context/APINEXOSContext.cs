using System;
using Microsoft.EntityFrameworkCore;
using Nexos.Entities.Models;


namespace Nexos.Repositories.Context
{
    public partial class APINEXOSContext : DbContext
    {
        public APINEXOSContext()
        {
        }

        public APINEXOSContext(DbContextOptions<APINEXOSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autore> Autores { get; set; }
        public virtual DbSet<Editoriale> Editoriales { get; set; }
        public virtual DbSet<Libro> Libros { get; set; }

 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Autore>(entity =>
            {
                entity.ToTable("AUTORES");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Ciudad)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CIUDAD");

                entity.Property(e => e.Correo)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CORREO");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA_NACIMIENTO");

                entity.Property(e => e.NombreCompleto)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE_COMPLETO");
            });

            modelBuilder.Entity<Editoriale>(entity =>
            {
                entity.ToTable("EDITORIALES");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Correo)
                    .HasMaxLength(255)
                    .IsUnicode(true)
                    .HasColumnName("CORREO");

                entity.Property(e => e.DirecionCorrespondencia)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DIRECION_CORRESPONDENCIA");

                entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("TELEFONO");

                entity.Property(e => e.LibrosRegistrado).HasColumnName("LIBROS_REGISTRADO");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(true)
                    .HasColumnName("NOMBRE");
            });

            modelBuilder.Entity<Libro>(entity =>
            {
                entity.ToTable("LIBROS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Anno).HasColumnName("ANNO");

                entity.Property(e => e.Generon)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("GENERON");

                entity.Property(e => e.IdAutor).HasColumnName("ID_AUTOR");

                entity.Property(e => e.IdEditorial).HasColumnName("ID_EDITORIAL");

                entity.Property(e => e.NumeroPagina).HasColumnName("NUMERO_PAGINA");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TITULO");

                entity.HasOne(d => d.IdAutorNavigation)
                    .WithMany(p => p.Libros)
                    .HasForeignKey(d => d.IdAutor)
                    .HasConstraintName("FK_AUTOR");

                entity.HasOne(d => d.IdEditorialNavigation)
                    .WithMany(p => p.Libros)
                    .HasForeignKey(d => d.IdEditorial)
                    .HasConstraintName("FK_EDITORIAL");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
