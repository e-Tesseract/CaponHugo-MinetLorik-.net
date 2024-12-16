// IBookRepository.cs
using BusinessObjects.Entity;

namespace DataAccessLayer.Repository
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAll();
        Book Get(int id);
    }
}