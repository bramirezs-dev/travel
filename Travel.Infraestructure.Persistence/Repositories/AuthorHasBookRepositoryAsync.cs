using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Application.Interfaces.AuthorHasBook;
using Travel.Domain.Entities;
using Travel.Infraestructure.Persistence.Contexts;

namespace Travel.Infraestructure.Persistence.Repositories
{
    public class AuthorHasBookRepositoryAsync : GenericRepositoryAsync<Travel.Domain.Entities.AuthorHasBook>, IAuthorHasBookRepositoryAsync
    {
        private readonly DbSet<Travel.Domain.Entities.AuthorHasBook> authorHasBooks;

        public AuthorHasBookRepositoryAsync(TravelDbContext dbContext):base(dbContext)
        {
            this.authorHasBooks = dbContext.Set<Travel.Domain.Entities.AuthorHasBook>();
        }

        public async Task<List<AuthorHasBook>> GetAllAuthorHasBook()
        {
            try
            {
                return await this.authorHasBooks.Include(a => a.Author).Include(b => b.Book).ThenInclude(b => b.Editorial).ToListAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        public async Task<IReadOnlyList<Travel.Domain.Entities.AuthorHasBook>> GetAuthorHasBookbyAuthorId(int authorId)
        {
            return await this.authorHasBooks.Include(a=>a.Author).Include(b=>b.Book).Where(a => a.Id == authorId).ToListAsync();
        }

        public async Task<IReadOnlyList<Travel.Domain.Entities.AuthorHasBook>> GetAuthorHasBookbyBookId(int bookId)
        {
            return await this.authorHasBooks.Include(a => a.Author).Include(b => b.Book).Where(a => a.Id == bookId).ToListAsync();
        }
    }
}
