using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Application.Interfaces.AuthorHasBook
{
    public interface IAuthorHasBookRepositoryAsync:IGenericRepositoryAsync<Travel.Domain.Entities.AuthorHasBook>
    {
        public Task<IReadOnlyList<Travel.Domain.Entities.AuthorHasBook>> GetAuthorHasBookbyAuthorId(int authorId);

        public Task<IReadOnlyList<Travel.Domain.Entities.AuthorHasBook>> GetAuthorHasBookbyBookId(int bookId);

        public Task<List<Travel.Domain.Entities.AuthorHasBook>> GetAllAuthorHasBook();
    }
}
