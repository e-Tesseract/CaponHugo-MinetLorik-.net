using BusinessObjects.Entity;
using BusinessObjects.Enum;

namespace DataAccessLayer.Repository
{
    public class BookRepository
    {
        public IEnumerable<Book> GetAll()
        {
            return [
                new Book(1, "Harry Potter", TypeBook.Fantastique, 300, 10, new Author(1, "J.K.", "Rowling")),
                new Book(2, "Le tour du monde en 80 jours", TypeBook.Aventure, 200, 8, new Author(2, "Jules", "Verne")),
                new Book(3, "Le seigneur des anneaux", TypeBook.Fantastique, 500, 9, new Author(3, "J.R.R.", "Tolkien")),
                new Book(4, "Shrek", TypeBook.Aventure, 100, 7, new Author(4, "William" , "Steig")),
            ];
        }

        public Book Get(int id)
        {
            return new Book(1, "Book", TypeBook.Fantastique, 0, 0, new Author(1, "FirstNameAuthor", "LastNameAuthor"));
        }
    }
}
