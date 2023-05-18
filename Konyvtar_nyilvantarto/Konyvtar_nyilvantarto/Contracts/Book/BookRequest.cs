namespace Konyvtar_nyilvantarto.Contracts.Book
{
    public class BookRequest
    {

        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int YearOfPublication { get; set; }
    }
}
