namespace Konyvtar_nyilvantarto.Contracts.LibraryMember
{
    public class CreateLibraryMemberRequest
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
