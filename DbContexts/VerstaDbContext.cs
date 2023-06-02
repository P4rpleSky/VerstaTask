using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using VerstaTask.Models;

namespace VerstaTask.DbContexts;

public partial class VerstaDbContext : DbContext
{
    public VerstaDbContext()
    { }

    public VerstaDbContext(DbContextOptions<VerstaDbContext> options)
        : base(options)
    { }

    public virtual DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("orders_pkey");

            entity.ToTable("orders");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CargoWeight)
                .HasPrecision(6, 3)
                .HasColumnName("cargo_weight");
            entity.Property(e => e.PickupDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("pickup_date");
            entity.Property(e => e.RecipientAddress)
                .HasMaxLength(64)
                .HasColumnName("recipient_address");
            entity.Property(e => e.RecipientCity)
                .HasMaxLength(32)
                .HasColumnName("recipient_city");
            entity.Property(e => e.SenderAddress)
                .HasMaxLength(64)
                .HasColumnName("sender_address");
            entity.Property(e => e.SenderCity)
                .HasMaxLength(32)
                .HasColumnName("sender_city");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
