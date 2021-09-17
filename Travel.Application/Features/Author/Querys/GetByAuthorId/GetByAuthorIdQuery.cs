using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Application.Features.Author.Querys.GetByAuthorId
{
    public class GetByAuthorIdQuery:IRequest<Travel.Domain.Entities.Author>
    {
        public int AuthorId { get; set; }
    }
}
