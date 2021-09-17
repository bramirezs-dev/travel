using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Application.DTOs;
using Travel.Application.Wrappers;

namespace Travel.Application.Features.BookDetails.Querys.GetBookDetails
{
    public class GetBookDetailsQuery:IRequest<ResponseSuccessful<BookDetailsDTO>>
    {
        public int BookId { get; set; }
    }
}
