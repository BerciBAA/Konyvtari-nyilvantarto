using Konyvtar_nyilvantarto.Services.LibraryMembers.Model;

namespace Konyvtar_nyilvantarto.Services.LibraryMembers.Repository
{
    public interface ILibraryMemberRepository
    {
        Task<bool> AddLibraryMember(LibraryMemberEntity libraryMemberEntity);
    }
}
