using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NSK 
{
	public   class NorthwindContext : DbContext
	{
		public NorthwindContext()
		{

		}

		public NorthwindContext(DbContextOptions<NorthwindContext> options) : base(options)
		{

		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Category>(entity =>
			{
				entity.HasKey(e => e.Id)
					.HasName("PK_Categories");

				entity.HasIndex(e => e.Name)
					.HasName("CategoryName");

				entity.Property(e => e.Id)
					.HasColumnName("CategoryID");

				entity.Property(e => e.Name)
				.HasColumnName("CategoryName")
					.IsRequired()
					.HasMaxLength(15);

				entity.Property(e => e.Description).HasColumnType("ntext");

				entity.Property(e => e.Picture).HasColumnType("image");

			});

		 

		 
		 
		 
		 
		 

			modelBuilder.Entity<Product>(entity =>
			{
				entity.HasKey(e => e.Id)
					.HasName("PK_Products");

				entity.HasIndex(e => e.CategoryId)
					.HasName("CategoryID");

				entity.HasIndex(e => e.Name)
					.HasName("ProductName");

				entity.HasIndex(e => e.SupplierId)
					.HasName("SuppliersProducts");

				entity.Property(e => e.Id)
					.HasColumnName("ProductID");

				entity.Property(e => e.CategoryId)
					.HasColumnName("CategoryID");

				entity.Property(e => e.IsDiscontinued)
					.HasColumnName("Discontinued")
					.HasDefaultValueSql("0");

				entity.Property(e => e.Name)
					.HasColumnName("ProductName")
					.IsRequired()
					.HasMaxLength(40);

				entity.Property(e => e.QuantityPerUnit).HasMaxLength(20);

				entity.Property(e => e.ReorderLevel).HasDefaultValueSql("0");

				entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

				entity.Property(e => e.UnitPrice)
					.HasColumnType("money")
					.HasDefaultValueSql("0");

				entity.Property(e => e.UnitsInStock).HasDefaultValueSql("0");

				entity.Property(e => e.UnitsOnOrder).HasDefaultValueSql("0");

				entity.HasOne(d => d.Category)
					.WithMany(p => p.Products)
					.HasForeignKey(d => d.CategoryId)
					.HasConstraintName("FK_Products_Categories");

				entity.HasOne(d => d.Supplier)
					.WithMany(p => p.Products)
					.HasForeignKey(d => d.SupplierId)
					.HasConstraintName("FK_Products_Suppliers");
			});

		 
		 

			modelBuilder.Entity<Supplier>(entity =>
			{
				entity.HasKey(e => e.Id)
					.HasName("PK_Suppliers");

				entity.HasIndex(e => e.CompanyName)
					.HasName("CompanyName");

				entity.HasIndex(e => e.PostalCode)
					.HasName("PostalCode");

				entity.Property(e => e.Id).HasColumnName("SupplierID");

				entity.Property(e => e.Address).HasMaxLength(60);

				entity.Property(e => e.City).HasMaxLength(15);

				entity.Property(e => e.CompanyName)
					.IsRequired()
					.HasMaxLength(40);

				entity.Property(e => e.ContactName).HasMaxLength(30);

				entity.Property(e => e.ContactTitle).HasMaxLength(30);

				entity.Property(e => e.Country).HasMaxLength(15);

				entity.Property(e => e.Fax).HasMaxLength(24);

				entity.Property(e => e.HomePage).HasColumnType("ntext");

				entity.Property(e => e.Phone).HasMaxLength(24);

				entity.Property(e => e.PostalCode).HasMaxLength(10);

				entity.Property(e => e.Region).HasMaxLength(15);
			});

		 
		}

		public virtual DbSet<Category> Categories { get; set; }
	 
		public virtual DbSet<Product> Products { get; set; }
	 
		public virtual DbSet<Supplier> Suppliers { get; set; }
	 
	}
}