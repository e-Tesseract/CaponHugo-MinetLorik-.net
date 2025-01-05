using BusinessObjects.Entity;
using DataAccessLayer.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity
    {
        private readonly LibraryContext _libraryContext;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
            _dbSet = _libraryContext.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {

            return _dbSet.ToList();

        }

        public T Get(int id)
        {
            return _dbSet.First(entity => entity.Id == id);
        }

        public T Add(T entity)
        {
            _dbSet.Add(entity);
            _libraryContext.SaveChanges();
            return entity;
        }

        public T Delete(int id)
        {
            var entity = _dbSet.First(entity => entity.Id == id);
            _dbSet.Remove(entity);
            _libraryContext.SaveChanges();
            return entity;
        }
    }
}
