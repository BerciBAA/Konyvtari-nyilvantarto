namespace Konyvtar_nyilvantarto.Contracts.LibraryMember
{
    public sealed class UpdateLibraryMemberRequest : LibraryMemberContractBase
    {
        public Guid Id { get; set; }
    }
}
