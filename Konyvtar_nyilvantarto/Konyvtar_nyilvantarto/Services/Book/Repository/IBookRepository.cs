namespace Konyvtar_nyilvantarto
{
    public interface IBookRepository
    {
        Task<BookEntity> Get(Guid Id);

        Task<IEnumerable<BookEntity>> GetAll();

        Task<BookEntity> Insert(BookEntity Book);

        Task<BookEntity> Update(BookEntity Book);

        Task Delete(Guid Id);
    }
}
