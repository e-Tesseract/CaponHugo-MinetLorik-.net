public class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");

        List<Book> books =
        [
            new Book("Harry Potter", "Fantastique"),
            new Book("Le tour du monde en 80 jours", "Aventure"),
            new Book("Le seigneur des anneaux", "Fantastique"),
        ];

        foreach (Book book in books)
        {
            Console.WriteLine(book.Name + " - " + book.Type);
        }
    }
}
