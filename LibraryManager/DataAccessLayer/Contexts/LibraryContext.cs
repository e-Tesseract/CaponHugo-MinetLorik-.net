using BusinessObjects.Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Contexts
{
    public class LibraryContext : DbContext
    {
        public DbSet<Library> Libraries { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        string DBpath = "../library.db";



    }
}

