using BusinessObjects.Entity;
using BusinessObjects.Enum;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Services.Services;

namespace LibraryManager.App
{
    public class Program
    {
        private static void Main(string[] args)
        {
            CatalogManager catalogManager = new();

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

        private static IHost CreateHostBuilder(IConfigurationBuilder configuration)
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {
                    // Configuration des services
                })
                .Build();
        }
    }
}
