using Konyvtar_nyilvantarto.Contexts;
using Konyvtar_nyilvantarto.Services.LibraryMembers.Model;
using Microsoft.EntityFrameworkCore;

namespace Konyvtar_nyilvantarto.Services.LibraryMembers.Repository
{
    public class LibraryMemberRepository : ILibraryMemberRepository
    {
        private readonly LibraryContext _libraryContext;

        public LibraryMemberRepository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        public async Task<bool> AddLibraryMember(LibraryMemberEntity libraryMemberEntity)
        {
            await _libraryContext.LibraryMembers.AddAsync(libraryMemberEntity);

            var result = await _libraryContext.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> DeleteLibraryMemberById(Guid id)
        {
            var entity = await _libraryContext.LibraryMembers.FindAsync(id);

            if (entity == null) 
                return false;

            _libraryContext.LibraryMembers.Remove(entity);

            var result = await _libraryContext.SaveChangesAsync();

            return result > 0;
        }

        public IEnumerable<LibraryMemberEntity> GetAllLibraryMemberByPage(int page, int size)
        {
            return _libraryContext.LibraryMembers.Skip(page * size).Take(size).ToList();
        }

        public async Task<LibraryMemberEntity> GetLibraryMemberById(Guid id)
        {
            return await _libraryContext.LibraryMembers.FirstOrDefaultAsync(x => x.MemberId == id);  
        }

        public async Task<bool> UpdateLibraryMember(LibraryMemberEntity libraryMemberEntity)
        {

            var entity = await _libraryContext.LibraryMembers.FirstOrDefaultAsync(x => x.MemberId == libraryMemberEntity.MemberId);

            entity = libraryMemberEntity;

            var result = await _libraryContext.SaveChangesAsync();

            return result > 0;
        }
        public async Task<LibraryMemberEntity> GetLibraryMemberByName(string name)
        {
            return await _libraryContext.LibraryMembers.FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}
