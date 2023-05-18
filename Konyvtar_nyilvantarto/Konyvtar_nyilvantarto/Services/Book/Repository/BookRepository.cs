using Konyvtar_nyilvantarto.Contexts;
using LibaryRegister.Contracts.Book;
using Microsoft.EntityFrameworkCore;

namespace Konyvtar_nyilvantarto
{
    public class BookRepository : IBookRepository
    {
        
        private LibraryContext _libraryContext;

        public BookRepository(LibraryContext libraryContext) {
            _libraryContext = libraryContext;
        }

        public async Task<BookEntity> Get(Guid id)
        {
            return await _libraryContext.Books.FindAsync(id);
        }

        public async Task<IEnumerable<BookEntity>> GetAll()
        {
            return await _libraryContext.Books.ToListAsync();
        }

        public async Task<BookEntity> Insert(BookEntity book)
        {
            _libraryContext.Books.Add(book);
            await _libraryContext.SaveChangesAsync();
            return await _libraryContext.Books.FindAsync(book.Id);
        }

        public async Task<BookEntity> Update(Guid id, BookEntity book)
        {
            var existedBook = await _libraryContext.Books.FindAsync(id);
            existedBook.Author = book.Author;
            existedBook.Publisher = book.Publisher;
            existedBook.Title = book.Title;
            existedBook.YearOfPublication = book.YearOfPublication;
            await _libraryContext.SaveChangesAsync();
            return existedBook;

        }

        public async Task Delete(BookEntity book)
        {
            _libraryContext.Books.Remove(book);
            await _libraryContext.SaveChangesAsync();

        }
    }
}
