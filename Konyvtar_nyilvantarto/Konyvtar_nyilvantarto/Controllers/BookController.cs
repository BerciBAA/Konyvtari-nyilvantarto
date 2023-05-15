using Konyvtar_nyilvantarto.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Konyvtar_nyilvantarto.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly BookService _BookService;

        public BookController(BookService BookService)
        {
            this._BookService = BookService;
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Book>> Get(Guid Id)
        {
            var Book = await _BookService.Get(Id);
            if (Book is null)
            {
                return NotFound();
            }
            return Ok(Book);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> Get() {
            IEnumerable<Book> Books = await _BookService.GetAll();
            return Ok(Books);
        }

        [HttpPost]
        public async Task<ActionResult> InsertPost([FromBody] Book Book)
        {
            var ExistingBook = await _BookService.Get(Book.Id);

            if (ExistingBook is not null) {
                return Conflict();
            }
            var InsertedBook = await _BookService.Insert(Book);
          
            return Ok(InsertedBook);
        }

        [HttpPut()]
        public async Task<ActionResult> UpdatePost(Guid Id, [FromBody] Book Book)
        {
            if (Book.Id == Id) {

                return BadRequest();
            }

            var ExistingBook = await _BookService.Get(Book.Id);


            if (ExistingBook is null)
            {
                return NotFound();

            }
            
            var UpdatedBook = await _BookService.Update(Book);
            return Ok(UpdatedBook);
        }


        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(Guid Id)
        {
            var ExistingBook = await _BookService.Get(Id);

            if (ExistingBook is null)
            {
                return NotFound();

            }

            await _BookService.Delete(ExistingBook.Id);
            return Ok();
        }
    }
}
