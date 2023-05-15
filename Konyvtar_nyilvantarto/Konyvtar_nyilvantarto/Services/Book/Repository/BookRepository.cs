using Konyvtar_nyilvantarto.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Konyvtar_nyilvantarto
{
    public class BookRepository : IBookRepository
    {
        
        private LibraryContext _LibraryContext;

        public BookRepository(LibraryContext LibraryContext) {
            this._LibraryContext = LibraryContext;
        }

        public async Task<Book> Get(Guid Id)
        {
            return await _LibraryContext.Books.FindAsync(Id);
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _LibraryContext.Books.ToListAsync();
        }

        public async Task<Book> Insert(Book Book)
        {
            _LibraryContext.Books.Add(Book);
            await _LibraryContext.SaveChangesAsync();
            var InsertedBook = await _LibraryContext.Books.FindAsync(Book.Id);
            return InsertedBook;
        }

        public async Task<Book> Update(Book Book)
        {
            var ExistedBook = await _LibraryContext.Books.FindAsync(Book.Id);
            ExistedBook.Author = Book.Author;
            ExistedBook.Publisher = Book.Publisher;
            ExistedBook.Title = Book.Title;
            ExistedBook.YearOfPublication = Book.YearOfPublication;
            await _LibraryContext.SaveChangesAsync();
            return ExistedBook;

        }

        public async Task Delete(Guid Id)
        {
            var ExistingBook = await _LibraryContext.Books.FindAsync(Id);
            _LibraryContext.Books.Remove(ExistingBook);
            await _LibraryContext.SaveChangesAsync();
        }
    }
}
