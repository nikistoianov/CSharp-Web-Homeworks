namespace CHUSHKA.Data
{
    using CHUSHKA.Models;
    using Microsoft.EntityFrameworkCore;

    public class ChushkaContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductType> ProductTypes { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = "Data Source=(LocalDb)\\MSSQLLocalDB;Database=Chushka_niki_st;Integrated Security=True";
                optionsBuilder.UseSqlServer(connectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }

    }
}
