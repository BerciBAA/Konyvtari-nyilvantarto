using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Konyvtar_nyilvantarto
{
    public class Book
    {
        public string title { get; set; }
        public string author { get; set; }
        public string publisher { get; set; }

        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string accessionNumber { get; set; }
        public int yearOfPublication { get; set; }
    }
}
