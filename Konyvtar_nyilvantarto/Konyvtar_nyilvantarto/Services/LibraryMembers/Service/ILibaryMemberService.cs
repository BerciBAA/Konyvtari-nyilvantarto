using Konyvtar_nyilvantarto.Services.LibraryMembers.Model;

namespace Konyvtar_nyilvantarto.Services.LibraryMembers.Service
{
    public interface ILibaryMemberService
    {
        Task<bool> AddLibraryMember(LibraryMemberDto libraryMember);
    }
}
