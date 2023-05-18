using AutoMapper;
using Konyvtar_nyilvantarto.Services.LibraryMembers.Model;
using LibaryRegister.Contracts.LibraryMember;

namespace Konyvtar_nyilvantarto.MappingProfiles.LibraryMember
{
    public class UpdateLibraryMemberRequestProfile : Profile
    {
        public UpdateLibraryMemberRequestProfile()
        {
            CreateMap<UpdateLibraryMemberRequest, LibraryMemberDto>();
        }
    }
}
