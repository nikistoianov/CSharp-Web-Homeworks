using BookLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Data
{
    public class BookLibraryContext : DbContext
    {
        public BookLibraryContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Borrower> Borrowers { get; set; }
        public DbSet<BorrowerBook> BorrowedBooks { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<BorrowerMovie> BorrowedMovies { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<BorrowerBook>()
            //    .HasKey(x => new { x.BookId, x.BorrowerId });

            modelBuilder.Entity<User>()
                .HasIndex(x => x.UserName)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}
