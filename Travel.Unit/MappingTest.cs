using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Application.DTOs;

namespace Travel.Unit
{
    public class MappingTest:Profile
    {
        public MappingTest()
        {
            CreateMap<Travel.Domain.Entities.Book, BookDTO>().ReverseMap();
        }
    }
}
