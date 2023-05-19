using Konyvtar_nyilvantarto.Services.Book.Model;
using Konyvtar_nyilvantarto.Services.LibraryMembers.Model;
using LibaryRegister.Contracts.Book;
using LibaryRegister.Contracts.LibraryMember;

namespace Konyvtar_nyilvantarto.Services.BorrowingData.Model
{
    public class BorrowingDataDto
    {
        public Guid BorrowingId { get; set; }

        public virtual Guid LibraryMemberId { get; set; }
        public virtual LibraryMemberDto LibraryMembers { get; set; }

        public virtual Guid BookId { get; set; }
        public virtual BookDto Book { get; set; }

        public DateTime RentalTime { get; set; }

        public DateTime RetrievalLimitTime { get; set; }


    }
}
