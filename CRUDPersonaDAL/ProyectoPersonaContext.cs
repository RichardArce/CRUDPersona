using System;
using System.Collections.Generic;
using CRUDPersonaObjetos.Modelos;
using Microsoft.EntityFrameworkCore;

namespace CRUDPersonaDAL;

public partial class ProyectoPersonaContext : DbContext
{
    public ProyectoPersonaContext()
    {
    }

    public ProyectoPersonaContext(DbContextOptions<ProyectoPersonaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Persona> Personas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Persona>(entity =>
        {
            entity.ToTable("Persona");

            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.FechaRegistro)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_registro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
