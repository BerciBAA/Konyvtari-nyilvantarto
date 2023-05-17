using AutoMapper;
using Konyvtar_nyilvantarto.Contracts.LibraryMember;
using Konyvtar_nyilvantarto.Services.LibraryMembers.Model;

namespace Konyvtar_nyilvantarto.MappingProfiles.LibraryMember
{
    public class LibraryMemberRequestProfile : Profile
    {
        public LibraryMemberRequestProfile()
        {
            CreateMap<LibraryMemberDto, LibraryMemberResponse>();
        }
    }
}
