using System;
using System.Collections.Generic;
using CRUDPersonaObjetos.Modelos;
using Microsoft.EntityFrameworkCore;

namespace CRUDPersonaDAL;

public partial class ProyectoPersonaContext : DbContext
{
    public ProyectoPersonaContext(DbContextOptions<ProyectoPersonaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Persona> Persona { get; set; }

    public virtual DbSet<Provincia> Provincia { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Persona>(entity =>
        {
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.FechaRegistro)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_registro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.ProvinciaIdfk).HasColumnName("ProvinciaIDFK");

            entity.HasOne(d => d.ProvinciaIdfkNavigation).WithMany(p => p.Persona)
                .HasForeignKey(d => d.ProvinciaIdfk)
                .HasConstraintName("FK_Persona_Provincia");
        });

        modelBuilder.Entity<Provincia>(entity =>
        {
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
