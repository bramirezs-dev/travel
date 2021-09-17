using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Application.DTOs;
using Travel.Application.Interfaces;
using Travel.Domain.Entities;

namespace Travel.Application.Helpers
{
    public class GeneralHelper : IGeneralHelper
    {
        private readonly IMapper mapper;

        public GeneralHelper(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public BookDetailsDTO ConvertoBookDetailsDTO(List<Travel.Domain.Entities.Author> author, Book book, Editorial editorial)
        {
            var bookDetailsDto = new BookDetailsDTO
            {

                
                Author = mapper.Map<List<AuthorDTO>>(author),
                Editorial = mapper.Map<EditorialDTO>(editorial)

                
            };

            return bookDetailsDto;
        }
    }
}
