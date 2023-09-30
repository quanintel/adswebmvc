using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace _2.AdsWeb.Entities.Entities;

public partial class AdswebContext : DbContext
{
    public AdswebContext()
    {
    }

    public AdswebContext(DbContextOptions<AdswebContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=localhost;uid=root;pwd=7850323;database=adsweb");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("category");

            entity.Property(e => e.Code).HasMaxLength(45);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(2000);
            entity.Property(e => e.IsDelete)
                .HasDefaultValueSql("b'0'")
                .HasColumnType("bit(1)");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("products");

            entity.HasIndex(e => e.CategoryId, "Category_Product_idx");

            entity.Property(e => e.Code).HasMaxLength(45);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(2000);
            entity.Property(e => e.ImgUrl).HasMaxLength(255);
            entity.Property(e => e.IsDelete)
                .HasDefaultValueSql("b'0'")
                .HasColumnType("bit(1)");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Url).HasMaxLength(255);

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("Category_Product");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
