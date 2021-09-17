using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Application.Features.Editorial.Querys.GetAllEditorials
{
    public class GetAllEditorialsQuery:IRequest<IEnumerable<Travel.Domain.Entities.Editorial>>
    {
    }
}
