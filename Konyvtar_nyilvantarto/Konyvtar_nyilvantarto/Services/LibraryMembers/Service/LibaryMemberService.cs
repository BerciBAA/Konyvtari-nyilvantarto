using Konyvtar_nyilvantarto.Services.LibraryMembers.Model;
using Konyvtar_nyilvantarto.Services.LibraryMembers.Repository;

namespace Konyvtar_nyilvantarto.Services.LibraryMembers.Service
{
    public class LibaryMemberService : ILibaryMemberService
    {
        private readonly ILibraryMemberRepository _repository;

        public Task<bool> AddLibraryMember(LibraryMemberDto libraryMember)
        {
            throw new NotImplementedException();
        }
    }
}
