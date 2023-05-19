using AutoMapper;
using Konyvtar_nyilvantarto.Services.BorrowingData.Model;
using LibaryRegister.Contracts.BorrowingData;

namespace Konyvtar_nyilvantarto.MappingProfiles.BorrowingData
{
    public class BookStateResponseProfile : Profile
    {
        public BookStateResponseProfile()
        {
            CreateMap<BorrowingDataDto, BookStateResponse>()
                .ForMember(x => x.IsOnLoan, opt => opt.MapFrom(source => source.LibraryMembers != null));
        }
    }
}
