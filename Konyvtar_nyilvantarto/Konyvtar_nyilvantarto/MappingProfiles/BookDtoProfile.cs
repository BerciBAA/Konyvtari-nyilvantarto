using AutoMapper;
using Konyvtar_nyilvantarto.Services.Book.Model;

namespace Konyvtar_nyilvantarto.MappingProfiles
{
    public class BookDtoProfile : Profile
    {
        public BookDtoProfile()
        {
            CreateMap<BookDto, BookEntity>();

            CreateMap<BookEntity, BookDto>();
        }
    }
}
