using BusinessObjects.Entity;

namespace DataAccessLayer.Repository
{
    public class AuthorRepository
    {
        public IEnumerable<Author> GetAll()
        {
            return [
                new Author(1, "J.K.", "Rowling"),
                new Author(2, "Jules","Verne"),
                new Author(3, "J.R.R.", "Tolkien"),
                new Author(4, "William", "Steig")
            ];
        }

        public Author Get(int id)
        {
            return new Author(1, "FirstNameAuthor", "LastNameAuthor");
        }


    }
}
