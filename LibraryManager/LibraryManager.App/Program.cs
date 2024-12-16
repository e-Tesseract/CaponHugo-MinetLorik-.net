using BusinessObjects.Entity;

namespace LibraryManager.App
{
    public class Program
    {
        private static void Main(string[] args)
        {
            // Create a list of books
            List<Book> books =
            [
                new Book("Harry Potter", "Fantastique"),
                new Book("Le tour du monde en 80 jours", "Aventure"),
                new Book("Le seigneur des anneaux", "Fantastique"),
                new Book("Shrek", "Aventure"),
            ];

            // Write all books in the console
            foreach (Book book in books)
            {
                Console.WriteLine(book.Name + " - " + book.Type);
            }

            Console.WriteLine();

            // LINQ Method to get all books of type "Aventure"
            var queAventure = books.Where(book => book.Type == "Aventure");

            // Write all books of type "Aventure" in the console
            foreach (Book book in queAventure)
            {
                Console.WriteLine(book.Name + " - " + book.Type);
            }
        }
    }
}
