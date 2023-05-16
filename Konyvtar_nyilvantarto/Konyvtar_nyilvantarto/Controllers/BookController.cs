using AutoMapper;
using FluentValidation;
using Konyvtar_nyilvantarto.Contexts;
using Konyvtar_nyilvantarto.Contracts.Book;
using Konyvtar_nyilvantarto.Services.Book.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Konyvtar_nyilvantarto.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private IValidator<CreateBookRequest> _validatorForCreateReq;
        private IMapper _mapper;
        private readonly IBookService _bookService;
       
        public BookController(IBookService bookService, IMapper mapper, IValidator<CreateBookRequest> validatorForCreateReq)
        {
            _validatorForCreateReq = validatorForCreateReq;
            _bookService = bookService;
            _mapper = mapper;
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<BookEntity>> Get(Guid Id)
        {
            var Book = await _bookService.Get(Id);
            if (Book is null)
            {
                return NotFound();
            }
            return Ok(Book);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookEntity>>> Get() {
            IEnumerable<BookEntity> Books = await _bookService.GetAll();
            return Ok(Books);
        }

        [HttpPost]
        public async Task<ActionResult> InsertPost([FromBody] CreateBookRequest Book)
        {
            var validationResult = _validatorForCreateReq.Validate(Book);

            if (!validationResult.IsValid) { 
                return BadRequest(validationResult.Errors);
            }
            var bookDto = _mapper.Map<CreateBookRequest, BookDto>(Book);
            var InsertedBook = await _bookService.Insert(bookDto);
            if (InsertedBook is null) {
                return Conflict();
            }
            var result = _mapper.Map<BookDto, BookResponse>(InsertedBook);
            return Created($"/book/{InsertedBook.Id}",InsertedBook);
        }

        [HttpPut()]
        public async Task<ActionResult> UpdatePost(Guid Id, BookEntity Book)
        {

            if (Book.Id != Id) {

                return BadRequest();
            }

            var ExistingBook = await _bookService.Get(Book.Id);


            if (ExistingBook is null)
            {
                return NotFound();

            }
            
            var UpdatedBook = await _bookService.Update(Book);
            return Ok(UpdatedBook);
        }


        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(Guid Id)
        {
            var ExistingBook = await _bookService.Get(Id);

            if (ExistingBook is null)
            {
                return NotFound();

            }

            await _bookService.Delete(ExistingBook.Id);
            return Ok();
        }
    }
}
