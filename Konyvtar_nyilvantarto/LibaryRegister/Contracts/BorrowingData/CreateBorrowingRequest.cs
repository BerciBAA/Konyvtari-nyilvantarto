namespace LibaryRegister.Contracts.BorrowingData
{
	public class CreateBorrowingRequest
    {
        public Guid BookId { get; set; }
        public Guid LibraryMemberId { get; set; }
        public DateTime RentalTime { get; set; }

        public DateTime RetrievalLimitTime { get; set; }

    }
}
