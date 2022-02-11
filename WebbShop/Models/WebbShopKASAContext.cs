using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebbShop.Models
{
    public partial class WebbShopKASAContext : DbContext
    {
        public WebbShopKASAContext()
        {
        }

        public WebbShopKASAContext(DbContextOptions<WebbShopKASAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Betalsätt> Betalsätts { get; set; }
        public virtual DbSet<Frakt> Frakts { get; set; }
        public virtual DbSet<Kategorier> Kategoriers { get; set; }
        public virtual DbSet<Kund> Kunds { get; set; }
        public virtual DbSet<Kundvagn> Kundvagns { get; set; }
        public virtual DbSet<Leverantör> Leverantörs { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Orderdetaljer> Orderdetaljers { get; set; }
        public virtual DbSet<Produkter> Produkters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=tcp:webbshopkasa.database.windows.net,1433;Initial Catalog=WebbShopKASA;Persist Security Info=False;User ID=kasa;Password=Newton123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Betalsätt>(entity =>
            {
                entity.ToTable("Betalsätt");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BetalningsAlternativ)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Frakt>(entity =>
            {
                entity.ToTable("Frakt");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FraktAlternativ)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Kategorier>(entity =>
            {
                entity.ToTable("Kategorier");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Namn)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Kund>(entity =>
            {
                entity.ToTable("Kund");

                entity.HasIndex(e => e.Telefonnummer, "UQ__Kund__017DA0D2047456E5")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Adress)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Efternamn)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Förnamn)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Kundvagn>(entity =>
            {
                entity.ToTable("Kundvagn");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ProduktId).HasColumnName("ProduktID");
            });

            modelBuilder.Entity<Leverantör>(entity =>
            {
                entity.ToTable("Leverantör");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Country)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Namn)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BetalsättsId).HasColumnName("BetalsättsID");

                entity.Property(e => e.KundId).HasColumnName("KundID");

                entity.Property(e => e.LeveransAdress)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Orderdatum).HasColumnType("date");

                
            });

            modelBuilder.Entity<Orderdetaljer>(entity =>
            {
                entity.ToTable("Orderdetaljer");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LeverantörId).HasColumnName("LeverantörID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ProduktId).HasColumnName("ProduktID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Orderdetaljers)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_Orderdetaljer.OrderID");
            });

            modelBuilder.Entity<Produkter>(entity =>
            {
                entity.ToTable("Produkter");

                entity.HasIndex(e => e.Namn, "UQ__Produkte__737584FD9C43CA5E")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LeverantörId).HasColumnName("LeverantörID");

                entity.Property(e => e.Namn)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ProduktInfo)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.Kategori)
                    .WithMany(p => p.Produkters)
                    .HasForeignKey(d => d.KategoriId)
                    .HasConstraintName("FK_Produkter.KategoriId");

                entity.HasOne(d => d.Leverantör)
                    .WithMany(p => p.Produkters)
                    .HasForeignKey(d => d.LeverantörId)
                    .HasConstraintName("FK_Produkter.LeverantörID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
