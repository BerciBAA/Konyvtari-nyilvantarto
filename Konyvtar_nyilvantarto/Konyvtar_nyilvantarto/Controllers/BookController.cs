using AutoMapper;
using FluentValidation;
using Konyvtar_nyilvantarto.Contracts.Book;
using Konyvtar_nyilvantarto.Services.Book.Model;
using LibaryRegister.Contracts.Book;
using Microsoft.AspNetCore.Mvc;

namespace Konyvtar_nyilvantarto.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private IValidator<BookRequest> _validatorForCreateReq;
        private IMapper _mapper;
        private readonly IBookService _bookService;
       
        public BookController(IBookService bookService, IMapper mapper, IValidator<BookRequest> validatorForCreateReq)
        {
            _validatorForCreateReq = validatorForCreateReq;
            _bookService = bookService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookResponse>> Get(Guid id)
        {
            var book = await _bookService.Get(id);
            if (book is null)
            {
                return NotFound();
            }
            var result = _mapper.Map<BookDto, BookResponse>(book);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookResponse>>> Get() {
            var bookDtos = await _bookService.GetAll();
            var result = _mapper.Map<IEnumerable<BookDto>, IEnumerable<BookResponse>>(bookDtos);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> InsertPost([FromBody] BookRequest book)
        {
            var validationResult = _validatorForCreateReq.Validate(book);

            if (!validationResult.IsValid) { 
                return BadRequest(validationResult.Errors);
            }

            var bookDto = _mapper.Map<BookRequest, BookDto>(book);
            var insertedBook = await _bookService.Insert(bookDto);

            if (insertedBook is null) {
                return Conflict();
            }
            return Created($"/book/{insertedBook.Id}",insertedBook);
        }

        [HttpPut()]
        public async Task<IActionResult> UpdatePut(Guid id, [FromBody] BookRequest book)
        {
            var validationResult = _validatorForCreateReq.Validate(book);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var bookDto = _mapper.Map<BookRequest, BookDto>(book);
            var updatedBook = await _bookService.Update(id, bookDto);
            if (updatedBook is null)
            {
                return NotFound();
            }
            return Ok(updatedBook);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var isDeleted = await _bookService.Delete(id);
            if (!isDeleted)
            {
                return NotFound();

            }
            return Ok();
        }
    }
}
