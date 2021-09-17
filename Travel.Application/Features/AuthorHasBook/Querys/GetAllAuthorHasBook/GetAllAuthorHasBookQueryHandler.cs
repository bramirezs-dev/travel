using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Travel.Application.DTOs;
using Travel.Application.Interfaces;
using Travel.Application.Interfaces.AuthorHasBook;

namespace Travel.Application.Features.AuthorHasBook.Querys.GetAllAuthorHasBook
{
    public class GetAllAuthorHasBookQueryHandler : IRequestHandler<GetAllAuthorHasBookQuery, List<AuthorHasBookDTO>>
    {

        
        private readonly IAuthorHasBookRepositoryAsync authorHasBookRepositoryAsync;
        private readonly IMapper mapper;

        public GetAllAuthorHasBookQueryHandler(IAuthorHasBookRepositoryAsync authorHasBookRepositoryAsync, IMapper mapper)
        {

            this.authorHasBookRepositoryAsync = authorHasBookRepositoryAsync;
            this.mapper = mapper;
        }

        public async Task<List<AuthorHasBookDTO>> Handle(GetAllAuthorHasBookQuery request, CancellationToken cancellationToken)
        {
            List<AuthorHasBookDTO> authorHasBookDTOs = new List<AuthorHasBookDTO>();

            var authorsHasBooks = await this.authorHasBookRepositoryAsync.GetAllAuthorHasBook();

            

            if (authorsHasBooks != null)
            {
                foreach (var item in authorsHasBooks)
                {
                        var exist = authorHasBookDTOs.Where(a => a.Author.Id == item.Author.Id).FirstOrDefault();

                        if (exist==null)
                        {
                        var listBooks = authorsHasBooks.Where(au => au.Author.Id == item.Author.Id).Select(au => au.Book).ToList();
                        var authorHasBookDTO = new AuthorHasBookDTO
                        {
                            Author = this.mapper.Map<AuthorDTO>(item.Author),
                            Books = this.mapper.Map<List<BookDTO>>(listBooks)
                        };
                        ///var removeListAuthorHasBooks = authorsHasBooks.RemoveAll(i => listAuthorHasBooksCurrent.Contains(i));

                        authorHasBookDTOs.Add(authorHasBookDTO);
                    }
                 
                }
            }

            return authorHasBookDTOs;
        }
    }
}
