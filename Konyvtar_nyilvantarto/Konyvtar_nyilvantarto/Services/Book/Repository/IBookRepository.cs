namespace Konyvtar_nyilvantarto
{
    public interface IBookRepository
    {
        Book Get(string accessionNumber);

        IEnumerable<Book> GetAll();

        void Insert(Book book);

        void Update(Book book);

        void Delete(string accessionNumber);
    }
}
