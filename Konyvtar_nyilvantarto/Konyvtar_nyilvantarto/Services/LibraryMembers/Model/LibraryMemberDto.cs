namespace Konyvtar_nyilvantarto.Services.LibraryMembers.Model
{
    public class LibraryMemberDto
    {
        public Guid MemberId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
