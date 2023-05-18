using Konyvtar_nyilvantarto.Contracts.LibraryMember;

namespace Konyvtar_nyilvantarto.Blazor.Services
{
    public interface ILibraryMemberService
    {
        public Task<LibraryMemberResponse?> GetLibraryMemberByNameAsync(string name);
    }
}
