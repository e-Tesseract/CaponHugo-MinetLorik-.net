using BusinessObjects.Enum;

namespace BusinessObjects.Entity
{
    public class Book: IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Pages { get; set; }
        public TypeBook Type { get; set; }
        public int Rate { get; set; }
        public Author Author { get; set; }

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
