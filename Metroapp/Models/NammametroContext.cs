using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Metroapp.Models;

public partial class NammametroContext : DbContext
{
    public NammametroContext()
    {
    }

    public NammametroContext(DbContextOptions<NammametroContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Metrocard> Metrocards { get; set; }

    public virtual DbSet<Passenger> Passengers { get; set; }

    public virtual DbSet<Station> Stations { get; set; }

    public virtual DbSet<VwCardDetail> VwCardDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=DB53AA7BC4785FA ;database=Nammametro;integrated security=true;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__Booking__5DE3A5B168774156");

            entity.ToTable("Booking");

            entity.Property(e => e.BookingId).HasColumnName("booking_id");
            entity.Property(e => e.DestinationStn).HasColumnName("destination_stn");
            entity.Property(e => e.Fare).HasColumnName("fare");
            entity.Property(e => e.SourceStn).HasColumnName("source_stn");

            entity.HasOne(d => d.DestinationStnNavigation).WithMany(p => p.BookingDestinationStnNavigations)
                .HasForeignKey(d => d.DestinationStn)
                .HasConstraintName("FK__Booking__destina__4E88ABD4");

            entity.HasOne(d => d.SourceStnNavigation).WithMany(p => p.BookingSourceStnNavigations)
                .HasForeignKey(d => d.SourceStn)
                .HasConstraintName("FK__Booking__source___4D94879B");
        });

        modelBuilder.Entity<Metrocard>(entity =>
        {
            entity.HasKey(e => e.CardId).HasName("PK__metrocar__BDF201DD70168D88");

            entity.ToTable("metrocard");

            entity.Property(e => e.CardId).HasColumnName("card_id");
            entity.Property(e => e.PhoneNo).HasColumnName("phone_no");
            entity.Property(e => e.WalletBalance)
                .HasDefaultValueSql("((200))")
                .HasColumnName("wallet_balance");

            entity.HasOne(d => d.PhoneNoNavigation).WithMany(p => p.Metrocards)
                .HasForeignKey(d => d.PhoneNo)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("phone_foreignkey");
        });

        modelBuilder.Entity<Passenger>(entity =>
        {
            entity.HasKey(e => e.PhoneNo).HasName("PK__Passenge__E6BE36DD20A02A30");

            entity.ToTable("Passenger", tb => tb.HasTrigger("trgNewPassenger"));

            entity.Property(e => e.PhoneNo)
                .ValueGeneratedNever()
                .HasColumnName("phone_no");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Station>(entity =>
        {
            entity.HasKey(e => e.StationId).HasName("PK__Station__44B370E992F81ECC");

            entity.ToTable("Station");

            entity.Property(e => e.StationId)
                .ValueGeneratedNever()
                .HasColumnName("station_id");
            entity.Property(e => e.StationName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("station_name");
        });

        modelBuilder.Entity<VwCardDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwCardDetails");

            entity.Property(e => e.CardId).HasColumnName("card_id");
            entity.Property(e => e.PhoneNo).HasColumnName("phone_no");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");
            entity.Property(e => e.WalletBalance).HasColumnName("wallet_balance");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
