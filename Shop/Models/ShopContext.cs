using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Shop.Models
{
    public partial class ShopContext : DbContext
    {
        public ShopContext()
        {
        }

        public ShopContext(DbContextOptions<ShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<List> List { get; set; }
        public virtual DbSet<ListProducts> ListProducts { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<ProductsPhotos> ProductsPhotos { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-MP6OO9J\\SQLEXPRESS;Database=Shop;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.UserId });

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cart_Products");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cart_users");
            });

            modelBuilder.Entity<List>(entity =>
            {
                entity.ToTable("list");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.List)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_list_users");
            });

            modelBuilder.Entity<ListProducts>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.ListId });

                entity.ToTable("list_products");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.ListId).HasColumnName("list_id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.HasOne(d => d.List)
                    .WithMany(p => p.ListProducts)
                    .HasForeignKey(d => d.ListId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_list_products_list");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ListProducts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_list_products_Products");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Count).HasColumnName("count");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Products_users");
            });

            modelBuilder.Entity<ProductsPhotos>(entity =>
            {
                entity.ToTable("products_photos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Photo).HasColumnName("photo");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductsPhotos)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_products_photos_Products");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Login).HasColumnName("login");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Password).HasColumnName("password");

                entity.Property(e => e.Photo).HasColumnName("photo");

                entity.Property(e => e.Surname).HasColumnName("surname");
            });
        }
    }
}
