using BusinessObjects.Entity;
using BusinessObjects.Enum;
using DataAccessLayer.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services.Services;

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
            return Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {
                    services.AddSingleton<IGenericRepository<Book>, BookRepository>();
                    services.AddSingleton<IGenericRepository<Author>, AuthorRepository>();
                    services.AddSingleton<IGenericRepository<Library>, LibraryRepository>();
                    services.AddSingleton<ICatalogManager, CatalogManager>();
                })
                .Build();
        }
    }
}
