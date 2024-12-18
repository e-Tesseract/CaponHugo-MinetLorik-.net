using BusinessObjects.Entity;
using BusinessObjects.Enum;

namespace Services.Services
{
    public interface ICatalogManager
    {
        public IEnumerable<Book> GetCatalog();
        public IEnumerable<Book> GetCatalog(TypeBook type);
        public Book FindBook(int id);

        public Book AddBook(Book book);

        public Book GetTopRatedBook();

        public Book DeleteBook(int id);
    }
}
