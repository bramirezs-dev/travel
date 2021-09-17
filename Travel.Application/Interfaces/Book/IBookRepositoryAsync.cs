using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Application.Interfaces.Book
{
    public interface IBookRepositoryAsync:IGenericRepositoryAsync<Travel.Domain.Entities.Book>
    {
        public Task<Travel.Domain.Entities.Book> GetBookByIdCompleteAsync(int id);

        public Task<List<Travel.Domain.Entities.Book>> GetAllBookCompleteAsync();

        public Task<Travel.Domain.Entities.Book> GetBookByTitleAsync(string title);
    }
}
