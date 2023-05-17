using AutoMapper;
using Konyvtar_nyilvantarto.Services.Book.Model;

namespace Konyvtar_nyilvantarto
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper) {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task Delete(Guid Id)
        {
            await _bookRepository.Delete(Id);
        }

        public async Task<BookEntity> Get(Guid Id)
        {
            return await _bookRepository.Get(Id);
        }

        public async Task<IEnumerable<BookEntity>> GetAll()
        {
            return await _bookRepository.GetAll();
        }

        public async Task<BookDto> Insert(BookDto book)
        {

            var bookEntity = _mapper.Map<BookDto, BookEntity>(book);
            var result = await _bookRepository.Insert(bookEntity);
            return _mapper.Map<BookEntity, BookDto>(result);
        }

        public async Task<BookEntity> Update(BookEntity Book)
        {
            return await _bookRepository.Update(Book);
        }
    }
}
