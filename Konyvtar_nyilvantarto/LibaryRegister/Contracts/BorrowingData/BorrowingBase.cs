namespace Konyvtar_nyilvantarto.Contracts.BorrowingData
{
	public class BorrowingBase
    {

        public Guid BookId { get; set; }
        public Guid LibraryMemberId { get; set; }
        public DateTime RentalTime { get; set; }

        public DateTime RetrievalLimitTime { get; set; }

    }
}
