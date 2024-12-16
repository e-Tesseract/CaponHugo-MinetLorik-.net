// IAuthorRepository.cs
using BusinessObjects.Entity;

namespace DataAccessLayer.Repository
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> GetAll();
        Author Get(int id);
    }
}