using Konyvtar_nyilvantarto.Services.LibaryMembers.Model;
using Konyvtar_nyilvantarto.Services.LibraryMembers.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Konyvtar_nyilvantarto.Services.BorrowingData.Model
{
    public class BorrowingDataEntity
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid BorrowingId { get; set; }

        public virtual LibraryMemberEntity LibraryMembers { get; set; }

        public virtual BookEntity Book { get; set; }

        public DateTime RentalTime { get; set; }

        public DateTime RetrievalLimitTime { get; set; }


    }
}
