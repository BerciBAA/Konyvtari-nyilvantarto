using AutoMapper;
using Konyvtar_nyilvantarto.Services.BorrowingData.Model;

namespace Konyvtar_nyilvantarto.MappingProfiles.BorrowingData
{
    public class BorrowingDtoProfile : Profile
    {
        public BorrowingDtoProfile()
        {   
            CreateMap<BorrowingDataEntity, BorrowingDataDto>();
            CreateMap<BorrowingDataDto, BorrowingDataEntity>();
           
        }
    }
}
