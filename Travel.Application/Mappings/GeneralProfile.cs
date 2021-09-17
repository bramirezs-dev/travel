using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Application.DTOs;

namespace Travel.Application.Mappings
{
    public class GeneralProfile:Profile
    {
        public GeneralProfile()
        {
            CreateMap<Travel.Domain.Entities.Book, BookDTO>().ReverseMap();
            CreateMap<Travel.Domain.Entities.AuthorHasBook, AuthorHasBookDTO>()
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author))
                .ReverseMap();
            CreateMap<Travel.Domain.Entities.Author, AuthorDTO>().ReverseMap();
            CreateMap<Travel.Domain.Entities.Editorial, EditorialDTO>().ReverseMap();
            CreateMap<Travel.Domain.Entities.Book, BookDetailsDTO>()
                          .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.AuthorHasBooks.Select(p=>p.Author)))
                          .ReverseMap();
        }

        
    }
}
