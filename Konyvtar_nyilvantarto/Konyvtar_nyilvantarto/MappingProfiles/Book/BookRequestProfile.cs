﻿using AutoMapper;
using Konyvtar_nyilvantarto.Services.Book.Model;
using LibaryRegister.Contracts.Book;

namespace Konyvtar_nyilvantarto.MappingProfiles.Book
{
    public class CreateBookRequestProfile : Profile
    {
        public CreateBookRequestProfile()
        {
            CreateMap<BookRequest, BookDto>().ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}
