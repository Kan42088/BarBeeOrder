using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BarBeeOrder.Models
{
    public partial class BarBeeOrderContext : DbContext
    {
        public BarBeeOrderContext()
        {
        }

        public BarBeeOrderContext(DbContextOptions<BarBeeOrderContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Attribute> Attributes { get; set; }
        public virtual DbSet<AttributePrice> AttributePrices { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Page> Pages { get; set; }
        public virtual DbSet<PaymentId> PaymentIds { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<ShippingUnit> ShippingUnits { get; set; }
        public virtual DbSet<TransactionStatus> TransactionStatuses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Scaffold-DbContext "Server=;Database=BarBeeOrder;Trusted_Connection=True;uid=;pwd=;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Force
            // dotnet dotnet-ef dbcontext scaffold "Server=;Database=BarBeeOrder;Intergrated Security=true;uid=;pwd=;" Microsoft.EntityFrameworkCore.SqlServer --output-dir Models -Force
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-H7E9QG7;Initial Catalog=BarBeeOrder;Persist Security Info=True;User ID=vuong;Password=123a123a");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Fullname).HasMaxLength(250);

                entity.Property(e => e.LastLogin).HasColumnType("datetime");

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.RollId).HasColumnName("RollID");

                entity.HasOne(d => d.Roll)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.RollId)
                    .HasConstraintName("FK_Account_Role");
            });

            modelBuilder.Entity<Attribute>(entity =>
            {
                entity.ToTable("Attribute");

                entity.Property(e => e.AttributeId).HasColumnName("AttributeID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<AttributePrice>(entity =>
            {
                entity.ToTable("AttributePrice");

                entity.Property(e => e.AttributePriceId).HasColumnName("AttributePriceID");

                entity.Property(e => e.AttributeId).HasColumnName("AttributeID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Attribute)
                    .WithMany(p => p.AttributePrices)
                    .HasForeignKey(d => d.AttributeId)
                    .HasConstraintName("FK_AttributePrice_Attribute");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.AttributePrices)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_AttributePrice_Product");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Cover).HasMaxLength(500);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Ordering)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.ParrentId).HasColumnName("ParrentID");

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Address).HasMaxLength(250);

                entity.Property(e => e.Avatar).HasMaxLength(250);

                entity.Property(e => e.Birtday).HasColumnType("datetime");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Fullname).HasMaxLength(250);

                entity.Property(e => e.LastLogin).HasColumnType("datetime");

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasMaxLength(12)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Note).HasMaxLength(500);

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.PaymentDate).HasColumnType("datetime");

                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");

                entity.Property(e => e.Suid).HasColumnName("SUID");

                entity.Property(e => e.TransactionStatusId).HasColumnName("TransactionStatusID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Order_Customer");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.PaymentId)
                    .HasConstraintName("FK_Order_PaymentID");

                entity.HasOne(d => d.Su)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Suid)
                    .HasConstraintName("FK_Order_ShippingUnit");

                entity.HasOne(d => d.TransactionStatus)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.TransactionStatusId)
                    .HasConstraintName("FK_Order_TransactionStatus");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("OrderDetail");

                entity.Property(e => e.OrderDetailId).HasColumnName("OrderDetailID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ShippingDate).HasColumnType("datetime");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_OrderDetail_Order");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_OrderDetail_Product");
            });

            modelBuilder.Entity<Page>(entity =>
            {
                entity.ToTable("Page");

                entity.Property(e => e.PageId).HasColumnName("PageID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.PageName).HasMaxLength(250);

                entity.Property(e => e.Tittle).HasMaxLength(250);
            });

            modelBuilder.Entity<PaymentId>(entity =>
            {
                entity.HasKey(e => e.PaymentId1);

                entity.ToTable("PaymentID");

                entity.Property(e => e.PaymentId1).HasColumnName("PaymentID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("Post");

                entity.Property(e => e.PostId).HasColumnName("PostID");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CreatedDate)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.ShortContent).HasMaxLength(250);

                entity.Property(e => e.Tittle).HasMaxLength(250);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_Post_Account");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ProductName).HasMaxLength(250);

                entity.Property(e => e.ShortDescription).HasMaxLength(250);

                entity.Property(e => e.Tittle).HasMaxLength(250);

                entity.Property(e => e.Video).HasMaxLength(250);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Product_Category");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.RoleName).HasMaxLength(50);
            });

            modelBuilder.Entity<ShippingUnit>(entity =>
            {
                entity.HasKey(e => e.Suid);

                entity.ToTable("ShippingUnit");

                entity.Property(e => e.Suid).HasColumnName("SUID");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.Phone).HasMaxLength(12);
            });

            modelBuilder.Entity<TransactionStatus>(entity =>
            {
                entity.ToTable("TransactionStatus");

                entity.Property(e => e.TransactionStatusId).HasColumnName("TransactionStatusID");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Status).HasMaxLength(150);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
