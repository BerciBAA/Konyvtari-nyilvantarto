using AutoMapper;
using Konyvtar_nyilvantarto.Services.LibraryMembers.Model;

namespace Konyvtar_nyilvantarto.MappingProfiles.LibraryMember
{
    public class LibaryMemberDtoProfile : Profile
    {
        public LibaryMemberDtoProfile()
        {
            CreateMap<LibraryMemberDto,LibraryMemberEntity>();
        }
    }
}
