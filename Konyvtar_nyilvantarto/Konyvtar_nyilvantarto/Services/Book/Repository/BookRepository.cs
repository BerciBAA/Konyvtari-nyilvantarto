using Konyvtar_nyilvantarto.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Konyvtar_nyilvantarto
{
    public class BookRepository : IBookRepository
    {
        
        private LibraryContext _libraryContext;

        public BookRepository(LibraryContext libraryContext) {
            _libraryContext = libraryContext;
        }

        public async Task<BookEntity> Get(Guid Id)
        {
            return await _libraryContext.Books.FindAsync(Id);
        }

        public async Task<IEnumerable<BookEntity>> GetAll()
        {
            return await _libraryContext.Books.ToListAsync();
        }

        public async Task<BookEntity> Insert(BookEntity Book)
        {
            _libraryContext.Books.Add(Book);
            await _libraryContext.SaveChangesAsync();
            var InsertedBook = await _libraryContext.Books.FindAsync(Book.Id);
            return InsertedBook;
        }

        public async Task<BookEntity> Update(BookEntity Book)
        {
            var ExistedBook = await _libraryContext.Books.FindAsync(Book.Id);
            ExistedBook.Author = Book.Author;
            ExistedBook.Publisher = Book.Publisher;
            ExistedBook.Title = Book.Title;
            ExistedBook.YearOfPublication = Book.YearOfPublication;
            await _libraryContext.SaveChangesAsync();
            return ExistedBook;

        }

        public async Task Delete(Guid Id)
        {
            var ExistingBook = await _libraryContext.Books.FindAsync(Id);
            _libraryContext.Books.Remove(ExistingBook);
            await _libraryContext.SaveChangesAsync();
        }
    }
}
