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

        

        public async Task<BookDto> Get(Guid id)
        {
            var existedBook = await _bookRepository.Get(id);
            return _mapper.Map<BookEntity, BookDto>(existedBook);
        }

        public async Task<IEnumerable<BookDto>> GetAll()
        {
            var bookEntities = await _bookRepository.GetAll();
            return _mapper.Map<IEnumerable<BookEntity>, IEnumerable<BookDto>>(bookEntities);
        }

        public async Task<BookDto> Insert(BookDto book)
        {

            var bookEntity = _mapper.Map<BookDto, BookEntity>(book);
            var result = await _bookRepository.Insert(bookEntity);
            return _mapper.Map<BookEntity, BookDto>(result);
        }

        public async Task<BookDto> Update(Guid id, BookDto book)
        {
            var bookEntity = _mapper.Map<BookDto, BookEntity>(book);
            var existedBook = await _bookRepository.Get(id);
            if (existedBook is null) {
                return _mapper.Map<BookEntity, BookDto>(existedBook);
            }
            var result = await _bookRepository.Update(id, bookEntity);
            return _mapper.Map<BookEntity, BookDto>(result);
        }

        public async Task<bool> Delete(Guid id)
        {
            var existedBook = await _bookRepository.Get(id);
            if (existedBook is null) { 
                return false;
            }
            await _bookRepository.Delete(existedBook);
            return true;
        }
    }
}
