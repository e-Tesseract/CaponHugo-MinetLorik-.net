using BusinessObjects.Entity;
using BusinessObjects.Enum;
using Microsoft.AspNetCore.Mvc;
using Services.Services;


namespace LibraryManager.Hosting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly ICatalogManager _catalogManager;

        public BookController(ICatalogManager catalogManager)
        {
            _catalogManager = catalogManager;
        }

        private static BookDto ConvertToBookDto(Book book)
        {
            return new BookDto(book.Id, book.Name, book.Type, book.Pages, book.Author);
        }

        // GET: books
        [HttpGet]
        public IActionResult GetBooks()
        {
            var catalog = _catalogManager.GetCatalog();
            var catalogDtos = catalog.Select(ConvertToBookDto);
            return Ok(catalogDtos);
        }

        // GET : book/{id}
        [HttpGet]
        [Route("book/{id}")]
        public IActionResult GetBook(int id)
        {
            var book = _catalogManager.FindBook(id);
            if (book == null)
            {
                return NotFound();
            }
            var bookDto = ConvertToBookDto(book);
            return Ok(bookDto);
        }

        // GET : books/{type}
        [HttpGet]
        [Route("books/{type}")]
        public IActionResult GetBooksByType(TypeBook type)
        {
            var catalog = _catalogManager.GetCatalog(type);
            if (catalog == null)
            {
                return NotFound();
            }
            var catalogDtos = catalog.Select(ConvertToBookDto);
            return Ok(catalogDtos);
        }

        // POST : book/add
        [HttpPost]
        [Route("book/add")]
        public IActionResult AddBook([FromBody] Book book)
        {
            var newBook = _catalogManager.AddBook(book);
            return CreatedAtAction(nameof(GetBook), new { id = newBook.Id }, newBook);
        }

        // GET : book/topRatedBook
        [HttpGet]
        [Route("book/topRatedBook")]
        public IActionResult GetTopRatedBook()
        {
            var topRatedBook = _catalogManager.GetTopRatedBook();
            var bookDto = ConvertToBookDto(topRatedBook);
            return Ok(bookDto);
        }

        // POST : book/delete
        [HttpPost]
        [Route("book/delete")]
        public IActionResult DeleteBook([FromBody] int id)
        {
            var book = _catalogManager.DeleteBook(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }
    }
}
