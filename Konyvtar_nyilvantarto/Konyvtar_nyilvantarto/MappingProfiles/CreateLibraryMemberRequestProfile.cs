using AutoMapper;
using Konyvtar_nyilvantarto.Contracts.LibraryMember;
using Konyvtar_nyilvantarto.Services.LibraryMembers.Model;

namespace Konyvtar_nyilvantarto.MappingProfiles
{
    public class CreateLibraryMemberRequestProfile : Profile
    {
        public CreateLibraryMemberRequestProfile()
        {
            CreateMap<CreateLibraryMemberRequest, LibraryMemberDto>();
        }
    }
}
