using BusinessObjects.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects.Entity
{
    [Table("book")]
    public class Book: IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Pages { get; set; }

        public TypeBook Type { get; set; }

        public int Rate { get; set; }

        [ForeignKey("AuthorId")]
        public Author Author { get; set; }

        [Column("id_author")]
        public int AuthorId { get; set; }

        public IEnumerable<Library> Libraries { get; set; }

        public Book()
        {
        }

        public Book(int id, string name, TypeBook type, int page, int rate, Author author)
        {
            Id = id;
            Name = name;
            Type = type;
            Pages = page;
            Rate = rate;
            Author = author;
        }
    }
}
