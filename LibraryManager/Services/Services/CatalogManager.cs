using BusinessObjects.Entity;
using BusinessObjects.Enum;
using DataAccessLayer.Repository;

namespace Services.Services
{
    public class CatalogManager : ICatalogManager
    {
        private readonly IGenericRepository<Book> _bookRepository;

        public CatalogManager(IGenericRepository<Book> bookReposiroty)
        {
            _bookRepository = bookReposiroty;
        }

        public IEnumerable<Book> GetCatalog()
        {
            return _bookRepository.GetAll();
        }

        public IEnumerable<Book> GetCatalog(TypeBook type)
        {
            return _bookRepository.GetAll().Where(book => book.Type == type);
        }

        public Book FindBook(int id)
        {
            return _bookRepository.Get(id);
        }

        public Book AddBook(Book book)
        {
            return _bookRepository.Add(book);
        }

        public Book GetTopRatedBook()
        {
            return _bookRepository.GetAll().OrderByDescending(book => book.Rate).FirstOrDefault();
        }

        public Book DeleteBook(int id)
        {
            return _bookRepository.Delete(id);
        }

    }
}
