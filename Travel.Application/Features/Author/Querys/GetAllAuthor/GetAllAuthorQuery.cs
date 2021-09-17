using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Application.Features.Author.Querys
{
    public class GetAllAuthorQuery:IRequest<IEnumerable<Travel.Domain.Entities.Author>>
    {
    }
}
