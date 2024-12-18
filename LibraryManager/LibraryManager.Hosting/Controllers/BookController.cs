using BusinessObjects.Enum;
using Microsoft.AspNetCore.Mvc;
using Services.Services;


namespace LibraryManager.Hosting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly CatalogManager _catalogManager;

        public BookController(CatalogManager catalogManager)
        {
            _catalogManager = catalogManager;
        }

        // GET: books
        [HttpGet]
        [Route("books")]

        public IActionResult GetBooks()
        {
            var catalog = _catalogManager.GetCatalog();
            return Ok(catalog);
        }

        // GET : book/{id}
        [HttpGet]
        [Route("{id}")]
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
        [Route("{type}")]
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
      

    }
}
