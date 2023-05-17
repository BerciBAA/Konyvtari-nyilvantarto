using Konyvtar_nyilvantarto.Services.LibaryMembers.Model;

namespace Konyvtar_nyilvantarto.Services.BorrowingData.Model
{
    public class BorrowingDataDto
    {
        public Guid BorrowingId { get; set; }

        public virtual LibraryMemberEntity LibraryMembers { get; set; }

        public virtual BookEntity Book { get; set; }

        DateTime RentalTime { get; set; }

        DateTime RetrievalLimitTime { get; set; }


    }
}
