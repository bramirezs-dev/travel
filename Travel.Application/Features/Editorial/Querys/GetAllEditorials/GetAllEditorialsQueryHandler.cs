using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Travel.Application.Interfaces;

namespace Travel.Application.Features.Editorial.Querys.GetAllEditorials
{
    public class GetAllEditorialsQueryHandler : IRequestHandler<GetAllEditorialsQuery, IEnumerable<Travel.Domain.Entities.Editorial>>
    {
        private readonly IGenericRepositoryAsync<Travel.Domain.Entities.Editorial> repositoryAsync;

        public async Task<IEnumerable<Domain.Entities.Editorial>> Handle(GetAllEditorialsQuery request, CancellationToken cancellationToken)
        {
            return await this.repositoryAsync.GetAllAsync();
        }
    }
}
