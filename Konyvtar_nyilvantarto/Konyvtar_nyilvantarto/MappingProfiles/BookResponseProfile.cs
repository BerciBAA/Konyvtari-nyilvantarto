using AutoMapper;
using Konyvtar_nyilvantarto.Contracts.Book;
using Konyvtar_nyilvantarto.Services.Book.Model;

namespace Konyvtar_nyilvantarto.MappingProfiles
{
    public class BookResponseProfile : Profile
    {
        public BookResponseProfile()
        {
            CreateMap<BookDto, BookResponse>();
        }
    }
}
