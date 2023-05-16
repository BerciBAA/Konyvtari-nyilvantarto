using Konyvtar_nyilvantarto.Services.Book.Model;

namespace Konyvtar_nyilvantarto
{
    public interface IBookService
    {
        Task<BookEntity> Get(Guid Id);

        Task<IEnumerable<BookEntity>> GetAll();

        Task<BookDto> Insert(BookDto Book);

        Task<BookEntity> Update(BookEntity Book);

        Task Delete(Guid Id);
    }
}
