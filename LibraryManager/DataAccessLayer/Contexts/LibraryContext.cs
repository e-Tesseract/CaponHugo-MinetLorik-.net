using BusinessObjects.Entity;
using BusinessObjects.Enum;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Contexts
{
    public class LibraryContext : DbContext
    {
        public DbSet<Library> Libraries { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        public LibraryContext(DbContextOptions<LibraryContext> options): base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Book>()
                .Property(e => e.Type)
                .HasConversion(
                    v => v.ToString(),
                    v => (TypeBook)Enum.Parse(typeof(TypeBook), v));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
