using AutoMapper;
using Konyvtar_nyilvantarto.Services.LibraryMembers.Model;
using LibaryRegister.Contracts.LibraryMember;

namespace Konyvtar_nyilvantarto.MappingProfiles.LibraryMember
{
    public class LibaryMemberDtoProfile : Profile
    {
        public LibaryMemberDtoProfile()
        {
            CreateMap<LibraryMemberDto,LibraryMemberEntity>();
            CreateMap<LibraryMemberEntity, LibraryMemberDto>();
        }
    }
}
