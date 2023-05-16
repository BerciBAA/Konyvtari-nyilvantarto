namespace Konyvtar_nyilvantarto.Services.Book.Model
{
    public class BookDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int YearOfPublication { get; set; }
    }
}
