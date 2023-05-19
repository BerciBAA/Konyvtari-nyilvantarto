using LibaryRegister.Contracts.LibraryMember;

namespace Konyvtar_nyilvantarto.Services.LibraryMembers.Repository
{
    public interface ILibraryMemberRepository
    {
        Task<bool> AddLibraryMember(LibraryMemberEntity libraryMemberEntity);
        Task<LibraryMemberEntity> GetLibraryMemberById(Guid id);
        IEnumerable<LibraryMemberEntity> GetAllLibraryMemberByPage(int page, int size);
        Task<bool> DeleteLibraryMemberById(Guid id);
        Task<bool> UpdateLibraryMember(LibraryMemberEntity libraryMemberEntity);
        Task<LibraryMemberEntity> GetLibraryMemberByName(string name);
    }
}
