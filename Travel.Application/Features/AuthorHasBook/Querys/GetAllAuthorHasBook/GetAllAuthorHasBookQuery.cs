using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Application.DTOs;

namespace Travel.Application.Features.AuthorHasBook.Querys.GetAllAuthorHasBook
{
    public class GetAllAuthorHasBookQuery:IRequest<List<AuthorHasBookDTO>>
    {

    }
}
