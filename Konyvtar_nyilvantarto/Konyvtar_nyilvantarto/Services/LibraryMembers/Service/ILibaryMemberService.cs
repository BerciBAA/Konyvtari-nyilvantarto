using Konyvtar_nyilvantarto.Services.LibraryMembers.Model;

namespace Konyvtar_nyilvantarto.Services.LibraryMembers.Service
{
    public interface ILibaryMemberService
    {
        Task<bool> AddLibraryMember(LibraryMemberDto libraryMember);

        Task<LibraryMemberDto> GetLibraryMember(Guid id);

        IEnumerable<LibraryMemberDto> GetLibraryMembersByPage(int page, int size);

        Task<bool> DeleteLibraryMemberById(Guid id);

        Task<bool> UpdateLibraryMember(LibraryMemberDto libraryMember);
    }
}
