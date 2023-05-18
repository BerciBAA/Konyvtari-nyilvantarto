﻿using AutoMapper;
using Konyvtar_nyilvantarto.Services.Book.Model;

namespace Konyvtar_nyilvantarto.MappingProfiles.Book
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
