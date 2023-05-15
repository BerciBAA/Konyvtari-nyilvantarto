using Konyvtar_nyilvantarto.Contexts;
using Konyvtar_nyilvantarto.Services.LibraryMembers.Model;

namespace Konyvtar_nyilvantarto.Services.LibraryMembers.Repository
{
    public class LibraryMemberRepository : ILibraryMemberRepository
    {
        private readonly LibraryContext _libraryContext;

        public LibraryMemberRepository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        public Task<bool> AddLibraryMember(LibraryMemberEntity libraryMemberEntity)
        {
            throw new NotImplementedException();
        }
    }
}
