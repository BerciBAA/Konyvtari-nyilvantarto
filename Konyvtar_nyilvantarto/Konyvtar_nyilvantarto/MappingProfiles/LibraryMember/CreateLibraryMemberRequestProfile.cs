using AutoMapper;
using Konyvtar_nyilvantarto.Contracts.LibraryMember;
using Konyvtar_nyilvantarto.Services.LibraryMembers.Model;

namespace Konyvtar_nyilvantarto.MappingProfiles.LibraryMember
{
    public class CreateLibraryMemberRequestProfile : Profile
    {
        public CreateLibraryMemberRequestProfile()
        {
            CreateMap<CreateLibraryMemberRequest, LibraryMemberDto>()
                .ForMember(x => x.MemberId, opt => opt.Ignore());
        }
    }
}
