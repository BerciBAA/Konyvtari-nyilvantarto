using AutoMapper;
using Konyvtar_nyilvantarto.Services.LibraryMembers.Model;
using Konyvtar_nyilvantarto.Services.LibraryMembers.Repository;
using LibaryRegister.Contracts.LibraryMember;

namespace Konyvtar_nyilvantarto.Services.LibraryMembers.Service
{
    public class LibaryMemberService : ILibaryMemberService
    {
        private readonly ILibraryMemberRepository _repository;
        private readonly IMapper _mapper;

        public LibaryMemberService(ILibraryMemberRepository libaryMemberRepository, IMapper mapper)
        {
            _repository = libaryMemberRepository;
            _mapper = mapper;
        }

        public async Task<bool> AddLibraryMember(LibraryMemberDto libraryMember)
        {
            var libraryMemberEntity = _mapper.Map<LibraryMemberDto, LibraryMemberEntity>(libraryMember);
            return await _repository.AddLibraryMember(libraryMemberEntity);
        }

        public async Task<bool> DeleteLibraryMemberById(Guid id)
        {
            return await _repository.DeleteLibraryMemberById(id);
        }

        public async Task<LibraryMemberDto> GetLibraryMember(Guid id)
        {
            var entity =  await _repository.GetLibraryMemberById(id);

            var result = _mapper.Map<LibraryMemberEntity, LibraryMemberDto>(entity);

            return result;
        }

        public IEnumerable<LibraryMemberDto> GetLibraryMembersByPage(int page, int size)
        {
            var entities = _repository.GetAllLibraryMemberByPage(page, size);

            var result = _mapper.Map<IEnumerable<LibraryMemberEntity>, IEnumerable<LibraryMemberDto>>(entities);

            return result;
        }

        public Task<bool> UpdateLibraryMember(LibraryMemberDto libraryMember)
        {
            var libraryMemberEntity = _mapper.Map<LibraryMemberDto, LibraryMemberEntity>(libraryMember);
            return _repository.UpdateLibraryMember(libraryMemberEntity);
        }
        public async Task<LibraryMemberDto> GetLibraryMemberByName(string name)
        {
            var libraryMemberEntity = await _repository.GetLibraryMemberByName(name);

            return _mapper.Map<LibraryMemberEntity, LibraryMemberDto>(libraryMemberEntity);
        }
    }
}
