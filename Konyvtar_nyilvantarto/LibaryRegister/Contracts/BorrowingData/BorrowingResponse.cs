
using Konyvtar_nyilvantarto.Contracts.Book;
using Konyvtar_nyilvantarto.Contracts.LibraryMember;

namespace Konyvtar_nyilvantarto.Contracts.BorrowingData
{
    public class BorrowingResponse
    {
        public Guid BorrowingId { get; set; }

        public BookResponse Book { get; set; }

        public LibraryMemberResponse LibraryMembers { get; set; }

        public DateTime RentalTime { get; set; }

        public DateTime RetrievalLimitTime { get; set; }


    }
}
