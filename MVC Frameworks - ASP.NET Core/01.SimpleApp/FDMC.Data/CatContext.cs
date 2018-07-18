using FDMC.Models;
using Microsoft.EntityFrameworkCore;

namespace FDMC.Data
{
    public class CatContext : DbContext
    {
        public DbSet<Cat> Cats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DbContextConfiguration.ConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }
    }
}
