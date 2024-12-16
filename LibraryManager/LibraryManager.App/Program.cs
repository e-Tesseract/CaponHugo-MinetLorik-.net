using BusinessObjects.Entity;
using DataAccessLayer.Repository;
using BusinessObjects.Enum;

namespace LibraryManager.App
{
    public class Program
    {
        private static void Main(string[] args)
        {
            BookRepository bookRepository = new();

            // Write all books in the console
            IEnumerable<Book> books = bookRepository.GetAll();
            foreach (Book book in books)
            {
                Console.WriteLine(book.Name + " - " + book.Type);
            }

            Console.WriteLine();

            // LINQ Method to get all books of type "Aventure"
            var queAventure = books.Where(book => book.Type == TypeBook.Aventure);

            // Write all books of type "Aventure" in the console
            foreach (Book book in queAventure)
            {
                Console.WriteLine(book.Name + " - " + book.Type);
            }
        }
    }
}
