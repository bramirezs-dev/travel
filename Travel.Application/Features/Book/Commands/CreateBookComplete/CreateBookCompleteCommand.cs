using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Application.DTOs;

namespace Travel.Application.Features.Book.Commands.CreateBookComplete
{
    public class CreateBookCompleteCommand:IRequest<BookDetailsDTO>
    {
        public BookDetailsDTO BookComplete { get; set; }
    }
}
