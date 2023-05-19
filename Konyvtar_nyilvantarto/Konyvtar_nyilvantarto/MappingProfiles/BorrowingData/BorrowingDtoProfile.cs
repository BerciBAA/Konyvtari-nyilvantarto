using AutoMapper;
using Konyvtar_nyilvantarto.Services.BorrowingData.Model;

namespace Konyvtar_nyilvantarto.MappingProfiles.BorrowingData
{
    public class BorrowingDtoProfile : Profile
    {
        public BorrowingDtoProfile()
        {
            CreateMap<BorrowingDataEntity, BorrowingDataDto>()
                .ForMember(x=>x.LibraryMemberId,opt=>opt.MapFrom(source => source.BorrowingDataLibraryMembersFK))
                .ForMember(x=>x.BookId, opt=>opt.MapFrom(source => source.BorrowingDataBookEntityFK));

            CreateMap<BorrowingDataDto, BorrowingDataEntity>()
                .ForMember(x=>x.BorrowingDataLibraryMembersFK,opt=>opt.MapFrom(source => source.LibraryMemberId))
                .ForMember(x => x.BorrowingDataBookEntityFK, opt => opt.MapFrom(source => source.BookId));

        }
    }
}
