using AutoMapper;
using Konyvtar_nyilvantarto.Contracts.BorrowingData;
using Konyvtar_nyilvantarto.Services.BorrowingData.Model;

namespace Konyvtar_nyilvantarto.MappingProfiles.BorrowingData
{
    public class BorrwoingRequestProfile : Profile
    {
        public BorrwoingRequestProfile()
        {
            CreateMap<BorrowingRequest,BorrowingDataDto>().ForMember(x => x.BorrowingId, opt => opt.Ignore()); 
        }
    }
}
