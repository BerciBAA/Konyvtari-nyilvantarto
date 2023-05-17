namespace Konyvtar_nyilvantarto
{
    public interface IBookRepository
    {
        Task<BookEntity> Get(Guid id);

        Task<IEnumerable<BookEntity>> GetAll();

        Task<BookEntity> Insert(BookEntity book);

        Task<BookEntity> Update(Guid id, BookEntity book);

        Task Delete(BookEntity book);
    }
}
