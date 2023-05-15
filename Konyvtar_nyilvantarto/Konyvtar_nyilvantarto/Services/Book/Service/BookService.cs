namespace Konyvtar_nyilvantarto
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _BookRepository;

        public BookService(IBookRepository BookRepository) {
            this._BookRepository = BookRepository;
        }

        public async Task Delete(Guid Id)
        {
            await _BookRepository.Delete(Id);
        }

        public async Task<Book> Get(Guid Id)
        {
            return await _BookRepository.Get(Id);
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _BookRepository.GetAll();
        }

        public async Task<Book> Insert(Book Book)
        {
            return await _BookRepository.Insert(Book);
        }

        public async Task<Book> Update(Book Book)
        {
            return await _BookRepository.Update(Book);
        }
    }
}
