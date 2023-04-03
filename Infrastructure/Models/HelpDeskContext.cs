using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Api.Models;

public partial class HelpDeskContext : DbContext
{
    public HelpDeskContext()
    {
    }

    public HelpDeskContext(DbContextOptions<HelpDeskContext> options)
        : base(options)
    {
        //this.ChangeTracker.LazyLoadingEnabled = false;
        
    }

    public virtual DbSet<AppUser> AppUsers { get; set; }

    public virtual DbSet<Arrival> Arrivals { get; set; }

    public virtual DbSet<Caracteristic> Caracteristics { get; set; }

    public virtual DbSet<Categorie> Categories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCaracteristic> ProductCaracteristics { get; set; }

    public virtual DbSet<ProductSerial> ProductSerials { get; set; }

    public virtual DbSet<SubCategorie> SubCategories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=HelpDesk;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppUser>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__AppUser__B7C926381231245D");

            entity.ToTable("AppUser");

            entity.Property(e => e.DepartementUser).HasMaxLength(50);
            entity.Property(e => e.NameUser).HasMaxLength(50);
            entity.Property(e => e.PosteUser).HasMaxLength(50);
        });

        modelBuilder.Entity<Arrival>(entity =>
        {
            entity.HasKey(e => e.IdArrivals).HasName("PK__Arrivals__06FB9DAE9AD340C5");

            entity.Property(e => e.DateArrival).HasColumnType("datetime");
        });

        modelBuilder.Entity<Caracteristic>(entity =>
        {
            entity.HasKey(e => e.IdCaracteristic).HasName("PK__Caracter__6A708C7C8CFC6748");

            entity.ToTable("Caracteristic");

            entity.Property(e => e.NameCaracteristic).HasMaxLength(50);
        });

        modelBuilder.Entity<Categorie>(entity =>
        {
            entity.HasKey(e => e.IdCategorie).HasName("PK__Categori__A3C02A1C6CDB2330");

            entity.ToTable("Categorie");

            entity.Property(e => e.NameCategorie).HasMaxLength(100);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.IdProduct).HasName("PK__Product__2E8946D4018DC1BC");

            entity.ToTable("Product");

            entity.Property(e => e.Categorie).HasMaxLength(100);
            entity.Property(e => e.Marque).HasMaxLength(100);
            entity.Property(e => e.Model).HasMaxLength(100);

            entity.HasOne(d => d.IdSubCategorieNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdSubCategorie)
                .HasConstraintName("FK__Product__IdSubCa__2D27B809");

            entity.HasMany(d => d.IdArrivals).WithMany(p => p.IdProducts)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductArrival",
                    r => r.HasOne<Arrival>().WithMany()
                        .HasForeignKey("IdArrivals")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FkArrivals"),
                    l => l.HasOne<Product>().WithMany()
                        .HasForeignKey("IdProduct")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FkProduct"),
                    j =>
                    {
                        j.HasKey("IdProduct", "IdArrivals").HasName("PkAssociative");
                        j.ToTable("ProductArrivals");
                    });
        });

        modelBuilder.Entity<ProductCaracteristic>(entity =>
        {
            entity.HasKey(e => new { e.IdProduct, e.IdCaracteristic }).HasName("PK__ProductC__F82E4E1378221297");

            entity.ToTable("ProductCaracteristic");

            entity.Property(e => e.Value).HasMaxLength(50);

            entity.HasOne(d => d.IdCaracteristicNavigation).WithMany(p => p.ProductCaracteristics)
                .HasForeignKey(d => d.IdCaracteristic)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductCa__IdCar__33D4B598");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.ProductCaracteristics)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductCa__IdPro__34C8D9D1");
        });

        modelBuilder.Entity<ProductSerial>(entity =>
        {
            entity.HasKey(e => e.IdNumProduct);

            entity.Property(e => e.NumMatricule).HasMaxLength(70);
            entity.Property(e => e.NumSerie).HasMaxLength(70);

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.ProductSerials)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("IdProduct");
        });

        modelBuilder.Entity<SubCategorie>(entity =>
        {
            entity.HasKey(e => e.IdSubCategorie).HasName("PK__SubCateg__0A1EFFE9FBA2E0C4");

            entity.ToTable("SubCategorie");

            entity.Property(e => e.NameSubCategorie).HasMaxLength(100);

            entity.HasOne(d => d.IdCategorieNavigation).WithMany(p => p.SubCategories)
                .HasForeignKey(d => d.IdCategorie)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SubCatego__IdCat__29572725");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
