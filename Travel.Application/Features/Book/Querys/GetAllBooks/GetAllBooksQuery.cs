using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Application.DTOs;
using Travel.Application.Wrappers;

namespace Travel.Application.Features.Book.Querys.GetAllBooks
{
    public class GetAllBooksQuery:IRequest<ResponseSuccessful<List<BookDTO>>>
    {
    }
}
