using Konyvtar_nyilvantarto.Services.Book.Model;

namespace Konyvtar_nyilvantarto
{
    public interface IBookService
    {
        Task<BookDto> Get(Guid id);

        Task<IEnumerable<BookDto>> GetAll();

        Task<BookDto> Insert(BookDto book);

        Task<BookDto> Update(Guid id, BookDto book);

        Task<bool> Delete(Guid id);
    }
}
