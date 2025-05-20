using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Transferencia.Dominio.Entidades;


namespace Transferencia.Infraestructura.Data;

public partial class BddtransfContext : DbContext
{
    public BddtransfContext()
    {
    }

    public BddtransfContext(DbContextOptions<BddtransfContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Billetera> Billeteras { get; set; }

    public virtual DbSet<Movimiento> Movimientos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Billetera>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("PK__Billeter__3214EC0741BD0ED5")
                .HasFillFactor(90);

            entity.ToTable("Billetera");

            entity.Property(e => e.Id).HasComment("Identificador unico, numero entero autoincrmental");
            entity.Property(e => e.Balance)
                .HasComment("Saldo de la billetera")
                .HasColumnType("decimal(18, 0)");
            entity.Property(e => e.CreateAt)
                .HasComment("Fecha de Apertura de la billetera")
                .HasColumnType("datetime");
            entity.Property(e => e.Documentid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("Documento de identidad de la persona propietaria de la billetera");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("Nombre del propietario de la billetera");
            entity.Property(e => e.UpdateAt)
                .HasComment("Fecha de ultima actualizacion de la billetera")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Movimiento>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("PK__Movimien__3214EC079B2E278A")
                .HasFillFactor(90);

            entity.ToTable("Movimiento");

            entity.Property(e => e.Id).HasComment("Identificador unico del movimiento");
            entity.Property(e => e.Amount)
                .HasComment("Monto de la transaccion")
                .HasColumnType("decimal(18, 0)");
            entity.Property(e => e.CreateAt)
                .HasComment("Fecha de la transaccion")
                .HasColumnType("datetime");
            entity.Property(e => e.Type)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("Tipo de Transaccion Debito/Credito");
            entity.Property(e => e.WalletId).HasComment("Identificador de la billetera");

            entity.HasOne(d => d.Wallet).WithMany(p => p.Movimientos)
                .HasForeignKey(d => d.WalletId)
                .HasConstraintName("FK__Movimient__Walle__5CD6CB2B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
