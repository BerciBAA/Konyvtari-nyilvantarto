using Microsoft.EntityFrameworkCore;

namespace Konyvtar_nyilvantarto.Contexts
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<BookEntity> Books { get; set; }

    }
}