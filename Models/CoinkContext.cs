using System;
using System.Collections.Generic;
using App_Coink.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace App_DVP.Models
{
    public partial class CoinkContext : DbContext
    {
        public CoinkContext()
        {
        }

        public CoinkContext(DbContextOptions<CoinkContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EntidadPersona> EntidadPersonas { get; set; } = null!;
        public virtual DbSet<PaisUsuario> PaisUsuarios { get; set; } = null!;
        public virtual DbSet<DepartamentoUsuario> DepartamentoUsuarios { get; set; } = null!;
        public virtual DbSet<MunicipioUsuario> MunicipioUsuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(local)\\SQLEXPRESS; DataBase=Coink; Trusted_Connection=True; TrustServerCertificate=True;");
            }*/
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EntidadPersona>(entity =>
            {
                entity.HasKey(e => e.Identificador)
                    .HasName("PK__EntidadP__F2374EB19545C644");
            
                entity.Property(e => e.Nombres)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(101)
                    .IsUnicode(false);

                entity.Property(e => e.Pais)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Departamento)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Municipio)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PaisUsuario>(entity =>
            {
                entity.HasKey(e => e.Identificador)
                    .HasName("PK__EntidadU__F2374EB11DCCF629");

                entity.ToTable("PaisUsuario");

                entity.Property(e => e.Pais)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id_Usuario)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DepartamentoUsuario>(entity =>
            {
                entity.HasKey(e => e.Identificador)
                    .HasName("PK__EntidadU__F2374EB11DCCF629");

                entity.ToTable("DepartamentoUsuario");

                entity.Property(e => e.Departamento)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id_Usuario)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MunicipioUsuario>(entity =>
            {
                entity.HasKey(e => e.Identificador)
                    .HasName("PK__EntidadU__F2374EB11DCCF629");

                entity.ToTable("MunicipioUsuario");

                entity.Property(e => e.Municipio)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id_Usuario)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
