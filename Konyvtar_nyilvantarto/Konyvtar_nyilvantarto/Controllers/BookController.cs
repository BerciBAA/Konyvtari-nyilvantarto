using Microsoft.AspNetCore.Mvc;

namespace Konyvtar_nyilvantarto.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository BookRepository)
        {
            this._bookRepository = BookRepository;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get() {
            IEnumerable<Book> books = _bookRepository.GetAll();
            return Ok(books);
        }

        [HttpGet("{accessionNumber}")]
        public ActionResult<Book> Get(string accessionNumber)
        {
            var book = _bookRepository.Get(accessionNumber);
            if (book is null) {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public ActionResult InsertPost([FromBody] Book book)
        {
            var existingBook = _bookRepository.Get(book.accessionNumber);

            if (existingBook is not null) {
                return Conflict();
            }
            _bookRepository.Insert(book);

            return Ok();
        }

        [HttpPut()]
        public ActionResult UpdatePost(String accessionNumber, [FromBody] Book book)
        {
            if (accessionNumber != book.accessionNumber) {
                return BadRequest();

            }

            var existingBook = _bookRepository.Get(book.accessionNumber);


            if (existingBook is null)
            {
                return NotFound();

            }

            _bookRepository.Update(book);

            return Ok();
        }


        [HttpDelete("{accessionNumber}")]
        public ActionResult Delete(string accessionNumber)
        {
            var existingBook = _bookRepository.Get(accessionNumber);

            if (existingBook is null)
            {
                return NotFound();

            }

            _bookRepository.Delete(accessionNumber);
            return Ok();
        }
    }
}
