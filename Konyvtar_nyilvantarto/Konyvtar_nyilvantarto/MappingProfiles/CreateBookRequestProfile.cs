using AutoMapper;
using Konyvtar_nyilvantarto.Contracts.Book;
using Konyvtar_nyilvantarto.Services.Book.Model;

namespace Konyvtar_nyilvantarto.MappingProfiles
{
    public class CreateBookRequestProfile : Profile
    {
        public CreateBookRequestProfile() {
            CreateMap<CreateBookRequest, BookDto>().ForMember(x => x.Id,opt=>opt.Ignore());
        }
    }
}
