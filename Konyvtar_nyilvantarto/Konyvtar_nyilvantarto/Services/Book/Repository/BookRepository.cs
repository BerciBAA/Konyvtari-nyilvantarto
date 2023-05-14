namespace Konyvtar_nyilvantarto
{
    public class BookRepository : IBookRepository
    {
        private Dictionary<String,Book> _books = new();

        public void Delete(string accessionNumber)
        {
            _books.Remove(accessionNumber);
        }

        public Book Get(string accessionNumber)
        {
            return _books.TryGetValue(accessionNumber, out Book book) ? book : null;
        }

        public IEnumerable<Book> GetAll()
        {
            return _books.Values;
        }

        public void Insert(Book book)
        {
            if (!_books.ContainsKey(book.accessionNumber)) {
                _books[book.accessionNumber] = book;
            }
            
        }

        public void Update(Book book)
        {
            _books[book.accessionNumber] = book;
        }
    }
}
