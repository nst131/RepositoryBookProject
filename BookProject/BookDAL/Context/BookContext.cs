using BookDAL.Configuration;
using Microsoft.EntityFrameworkCore;

namespace BookDAL.Context
{
    public class BookContext : DbContext, IBookContext
    {
       public BookContext(DbContextOptions<BookContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("Server =.\\SQLEXPRESS; Database = BookDatabase; Trusted_Connection = True; MultipleActiveResultSets = True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());
        }
    }
}
