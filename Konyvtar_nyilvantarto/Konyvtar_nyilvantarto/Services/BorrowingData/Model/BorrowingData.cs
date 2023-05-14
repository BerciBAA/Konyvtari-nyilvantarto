namespace Konyvtar_nyilvantarto.Services.BorrowingData.Model
{
    public class BorrowingData
    {
        private string readingNumber { get; set; }

        private string accessionNumber { get; set; }

        DateTime rentalTime { get; set; }

        DateTime deadlineForReturn { get; set; }

       
    }
}
