using Microsoft.EntityFrameworkCore;

namespace Konyvtar_nyilvantarto
{
    public class KonyvtarNyilvantartoContext : DbContext
    {
        public KonyvtarNyilvantartoContext(DbContextOptions options) : base(options) { 
        
        }

        public virtual DbSet<Book> books { get; set; }
    }
}   
