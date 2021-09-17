using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Travel.Application.Interfaces;

namespace Travel.Application.Features.Author.Querys
{
    class GetAllAuthorQueryHandler : IRequestHandler<GetAllAuthorQuery, IEnumerable<Travel.Domain.Entities.Author>>
    {
        private readonly IGenericRepositoryAsync<Travel.Domain.Entities.Author>  repositoryAsync;

        public GetAllAuthorQueryHandler(IGenericRepositoryAsync<Domain.Entities.Author> repositoryAsync)
        {
            this.repositoryAsync = repositoryAsync;
        }

        public async Task<IEnumerable<Domain.Entities.Author>> Handle(GetAllAuthorQuery request, CancellationToken cancellationToken)
        {
            return await repositoryAsync.GetAllAsync();
        }
    }
}
