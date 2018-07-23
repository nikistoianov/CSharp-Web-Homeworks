
using HTTPServer.ByTheCakeApplication.Models;

namespace HTTPServer.ByTheCakeApplication.Data
{

    using Microsoft.EntityFrameworkCore;

    public class ByTheCakeContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<ProductOrder> ProductOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductOrder>()
                .HasKey(po => new { po.ProductId, po.OrderId });

            modelBuilder.Entity<ProductOrder>()
                .HasOne(po => po.Order)
                .WithMany(o => o.Products)
                .HasForeignKey(po => po.OrderId);

            modelBuilder.Entity<ProductOrder>()
                .HasOne(po => po.Product)
                .WithMany(p => p.Orders)
                .HasForeignKey(po => po.ProductId);
            
            base.OnModelCreating(modelBuilder);
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string connString = "Data Source=(LocalDb)\\MSSQLLocalDB;Database=ByTheCakeDb;Integrated Security=True";

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connString);
            }

            base.OnConfiguring(optionsBuilder);
        }
    }
}
