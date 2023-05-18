using AutoMapper;
using Konyvtar_nyilvantarto.Contracts.Book;
using Konyvtar_nyilvantarto.Contracts.BorrowingData;
using Konyvtar_nyilvantarto.Services.Book.Model;
using Konyvtar_nyilvantarto.Services.BorrowingData.Model;

namespace Konyvtar_nyilvantarto.MappingProfiles.BorrowingData
{
    public class BorrowingResponseProfile : Profile
    {
        public BorrowingResponseProfile()
        {
            CreateMap<BorrowingDataDto, BorrowingResponse>();
        }
        
    }
}
