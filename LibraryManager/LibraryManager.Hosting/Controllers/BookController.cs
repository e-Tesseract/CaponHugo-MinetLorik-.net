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

        // GET: books
        [HttpGet]
        public IActionResult GetBooks()
        {
            var catalog = _catalogManager.GetCatalog();
            return Ok(catalog);
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
            return Ok(book);
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
            return Ok(catalog);
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
            return Ok(topRatedBook);
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
