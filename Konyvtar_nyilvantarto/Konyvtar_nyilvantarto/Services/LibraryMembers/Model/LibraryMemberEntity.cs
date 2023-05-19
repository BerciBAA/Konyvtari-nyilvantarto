using Konyvtar_nyilvantarto.Services.BorrowingData.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibaryRegister.Contracts.LibraryMember
{
    public class LibraryMemberEntity
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid MemberId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

		public virtual BorrowingDataEntity BorrowingData { get; set; }


	}
}
