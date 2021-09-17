using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Application.DTOs;

namespace Travel.Application.Features.Book.Commands.UpdateBookComplete
{
    public class UpdateBookCompleteCommand:IRequest<BookDetailsDTO>
    {
        public BookDetailsDTO Book { get; set; }

        public int BookId { get; set; }
    }
}
