using BusinessObjects.Entity;
using BusinessObjects.Enum;
using DataAccessLayer.Repository;
using Moq;
using Services.Services;

namespace Services.Test
{
    public class CatalogServiceTest
    {
        private readonly Mock<IGenericRepository<Book>> _mockBookRepository;
        private readonly CatalogManager _catalogManager;

        public CatalogServiceTest()
        {
            _mockBookRepository = new Mock<IGenericRepository<Book>>();
            _catalogManager = new CatalogManager(_mockBookRepository.Object);
        }

        [Fact]
        public void GetCatalog_ShouldReturnCatalog_WhenBooksExist()
        {
            var books = new List<Book> {
                new(1, "404", TypeBook.Horreur, 404, 0, new Author(1, "Not", "Found")),
                new(2, "FunnyNumberWYSI", TypeBook.Humour, 727, 5, new Author(2, "Dean", "Herbert")),
            };

            _mockBookRepository.Setup(c => c.GetAll()).Returns(books);
            var res = _catalogManager.GetCatalog();

            Assert.NotEmpty(res);
            Assert.Contains(books[0], res);
            Assert.Contains(books[1], res);
        }

        [Fact]
        public void GetCatalog_ShouldReturnCatalogOfOneType_WhenTypeIsSpecified()
        {
            var books = new List<Book> {
                new(1, "404", TypeBook.Horreur, 404, 0, new Author(1, "Not", "Found")),
                new(2, "FunnyNumberWYSI", TypeBook.Humour, 727, 5, new Author(2, "Dean", "Herbert")),
            };

            _mockBookRepository.Setup(c => c.GetAll()).Returns(books);
            var res = _catalogManager.GetCatalog(TypeBook.Humour);

            Assert.NotEmpty(res);
            Assert.Single(res);
            Assert.Equal(TypeBook.Humour, res.First().Type);
            Assert.Equal("FunnyNumberWYSI", res.First().Name);
        }

        [Fact]
        public void FindBook_ShouldReturnBook_WhenBookExists()
        {
            var book = new Book(1, "OneBook", TypeBook.Horreur, 404, 0, new Author(1, "Papers", "Pen"));

            _mockBookRepository.Setup(c => c.Get(1)).Returns(book);
            var res = _catalogManager.FindBook(1);

            Assert.NotNull(res);
            Assert.Equal(1, res.Id);
            Assert.Equal("OneBook", res.Name);
            Assert.Equal(TypeBook.Horreur, res.Type);
        }

        [Fact]
        public void GetCatalog_ShouldReturnEmptyCatalog_WhenNoBooksExist()
        {
            _mockBookRepository.Setup(c => c.GetAll()).Returns([]);
            var res = _catalogManager.GetCatalog();

            Assert.Empty(res);
        }

        [Fact]
        public void FindBook_ShouldReturnNull_WhenBookNotFound()
        {
            _mockBookRepository.Setup(c => c.Get(It.IsAny<int>())).Returns(value: null);
            var res = _catalogManager.FindBook(99);

            Assert.Null(res);
        }
    }
}