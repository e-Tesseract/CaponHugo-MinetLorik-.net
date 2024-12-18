using BusinessObjects.Entity;
using BusinessObjects.Enum;
using DataAccessLayer.Contexts;
using DataAccessLayer.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LibraryManager.App
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var host = CreateHostBuilder();
            var catalogManager = host.Services.GetRequiredService<ICatalogManager>();

            // Write all books in the console
            Console.WriteLine("--- Method GetCatalog() ---");
            IEnumerable<Book> books = catalogManager.GetCatalog();
            foreach (Book book in books)
            {
                Console.WriteLine(book.Name + " - " + book.Type);
            }

            Console.WriteLine("\n--- Method GetCatalog(Type type) ---");

            IEnumerable<Book> adventureBooks = catalogManager.GetCatalog(TypeBook.Aventure);
            foreach (Book book in books)
            {
                Console.WriteLine(book.Name + " - " + book.Type);
            }

            Console.WriteLine("\n--- Method FindBook() ---");

            Book bookById = catalogManager.FindBook(1);
            Console.WriteLine(bookById.Name + " - " + bookById.Type);
        }

        private static IHost CreateHostBuilder()
        {
            string path = "";
            return Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {
                    services.AddSingleton<IGenericRepository<Book>, GenericRepository<Book>>();
                    services.AddSingleton<IGenericRepository<Author>, GenericRepository<Author>>();
                    services.AddSingleton<IGenericRepository<Library>, GenericRepository<Library>>();
                    services.AddSingleton<ICatalogManager, CatalogManager>();
                    services.AddDbContext<LibraryContext>(options =>
                      options.UseSqlite($"Data Source={path};")
                             .EnableSensitiveDataLogging(false)
                             .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.Warning)))
                      );
                })
                .Build();
        }
    }
}
