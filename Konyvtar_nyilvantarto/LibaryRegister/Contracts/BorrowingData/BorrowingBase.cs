using LibaryRegister.Contracts.Book;
using LibaryRegister.Contracts.LibraryMember;

namespace Konyvtar_nyilvantarto.Contracts.BorrowingData
{
    public class BorrowingBase
    {

        public virtual LibraryMemberEntity LibraryMembers { get; set; }

        public virtual BookEntity Book { get; set; }

        public DateTime RentalTime { get; set; }

        public DateTime RetrievalLimitTime { get; set; }

    }
}
