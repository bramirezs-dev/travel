using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Application.DTOs;

namespace Travel.Application.Interfaces
{
    public interface IGeneralHelper
    {
        public BookDetailsDTO ConvertoBookDetailsDTO(List<Travel.Domain.Entities.Author> author
                                                    ,Travel.Domain.Entities.Book book
                                                    ,Travel.Domain.Entities.Editorial editorial);
    }
}
