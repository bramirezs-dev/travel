using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Travel.Application.Interfaces;

namespace Travel.Application.Features.Author.Querys.GetByAuthorId
{
    public class GetByAuthorIdQueryHandler : IRequestHandler<GetByAuthorIdQuery, Travel.Domain.Entities.Author>
    {

        IGenericRepositoryAsync<Travel.Domain.Entities.Author> repositoryAsync;
        public async Task<Domain.Entities.Author> Handle(GetByAuthorIdQuery request, CancellationToken cancellationToken)
        {
            return await repositoryAsync.GetByIdAsync(request.AuthorId);
        }
    }
}
