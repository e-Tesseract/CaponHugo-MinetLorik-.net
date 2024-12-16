using BusinessObjects.Entity;

namespace DataAccessLayer.Repository
{
    public class LibraryRepository
    {
        public IEnumerable<Library> GetAll()
        {
            return [
                new Library(1, "Library", "Adress", []),
                new Library(2, "Library", "Adress", []),
            ];
        }

        public Library Get(int id)
        {
            return new Library(1, "Library", "Adress", []);
        }
    }
}
