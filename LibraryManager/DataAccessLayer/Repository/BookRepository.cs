using BusinessObjects.Entity;
using DataAccessLayer.Contexts;

namespace DataAccessLayer.Repository
{
    public class BookRepository: IGenericRepository<Book>
    {
        private readonly LibraryContext _libraryContext;

        public BookRepository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        public IEnumerable<Book> GetAll()
        {
            return _libraryContext.Books;
        }

        public Book Get(int id)
        {
            return _libraryContext.Books.FirstOrDefault(book => book.Id == id);
        }

        public Book Add(Book book) 
        {
            _libraryContext.Books.Add(book);
            _libraryContext.SaveChanges();
            return book;
        }
    }
}
