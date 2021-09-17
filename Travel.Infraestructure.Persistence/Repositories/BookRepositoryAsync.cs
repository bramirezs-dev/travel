using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Application.Interfaces.Book;
using Travel.Domain.Entities;
using Travel.Infraestructure.Persistence.Contexts;

namespace Travel.Infraestructure.Persistence.Repositories
{
    public class BookRepositoryAsync : GenericRepositoryAsync<Travel.Domain.Entities.Book>, IBookRepositoryAsync
    {
        private readonly DbSet<Travel.Domain.Entities.Book> book;
        public BookRepositoryAsync(TravelDbContext dbContext) : base(dbContext)
        {
            this.book = dbContext.Set<Travel.Domain.Entities.Book>();
        }

        public async Task<List<Book>> GetAllBookCompleteAsync()
        {

            //return await this.book.Include(s => s.Editorial).ToListAsync();
            return await this.book.ToListAsync();
        }

        public async Task<Book> GetBookByIdCompleteAsync(int id)
        {
            var book = await this.book.Include(p=>p.Editorial)
                                      .Include(ab=>ab.AuthorHasBooks)
                                      .ThenInclude(ab=>ab.Author)
                                      .Include(ab => ab.AuthorHasBooks)
                                      .ThenInclude(ab => ab.Book)
                                      .Where(b => b.ISBNId == id)
                                      .FirstOrDefaultAsync();

            return book;
            
        }

        public async Task<Book> GetBookByTitleAsync(string title)
        {
            return await this.book.Where(b=>b.Title.ToUpper() == title.ToUpper()).FirstOrDefaultAsync();
        }
    }
}
