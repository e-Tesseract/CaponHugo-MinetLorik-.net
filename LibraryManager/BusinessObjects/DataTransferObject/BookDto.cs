using BusinessObjects.Enum;

namespace BusinessObjects.Entity
{
    public class BookDto : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Pages { get; set; }
        public TypeBook Type { get; set; }
        public Author Author { get; set; }
        public IEnumerable<Library> Libraries { get; set; }

        public BookDto()
        {
        }

        public BookDto(int id, string name, TypeBook type, int page, Author author)
        {
            Id = id;
            Name = name;
            Type = type;
            Pages = page;
            Author = author;
        }
    }
}
