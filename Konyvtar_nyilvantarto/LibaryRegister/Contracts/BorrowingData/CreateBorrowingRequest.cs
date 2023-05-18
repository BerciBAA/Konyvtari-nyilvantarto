using LibaryRegister.Contracts.Book;
using LibaryRegister.Contracts.LibraryMember;

namespace LibaryRegister.Contracts.BorrowingData
{
    public class CreateBorrowingRequest
    {
        public Guid BorrowingId { get; set; }

        public virtual LibraryMemberEntity LibraryMembers { get; set; }

        public virtual BookEntity Book { get; set; }

        public DateTime RentalTime { get; set; }

        public DateTime RetrievalLimitTime { get; set; }

    }
}
