using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects.Entity
{
    [Table("library")]
    public class Library: IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public string Adress { get; set; }
        
        public IEnumerable<Book> Books { get; set; }

        public Library()
        {
        }
        public Library(int id, string name, string adress, IEnumerable<Book> books)
        {
            Id = id;
            Name = name;
            Adress = adress;
            Books = books;
        }
    }
}
