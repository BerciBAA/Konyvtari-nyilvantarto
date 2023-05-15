namespace Konyvtar_nyilvantarto
{
    public interface IBookRepository
    {
        Task<Book> Get(Guid Id);

        Task<IEnumerable<Book>> GetAll();

        Task<Book> Insert(Book Book);

        Task<Book> Update(Book Book);

        Task Delete(Guid Id);
    }
}
