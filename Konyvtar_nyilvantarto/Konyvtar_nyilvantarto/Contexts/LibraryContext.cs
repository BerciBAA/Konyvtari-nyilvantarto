using Microsoft.EntityFrameworkCore;

namespace Konyvtar_nyilvantarto.Contexts
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }

        internal Task FindAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}