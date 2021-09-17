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
using Travel.Application.Interfaces.Book;

namespace Travel.Application.Features.Book.Commands.CreateBookComplete
{
    public class CreateBookCompleteCommandHandler : IRequestHandler<CreateBookCompleteCommand, BookDetailsDTO>
    {
        private readonly IGenericRepositoryAsync<Travel.Domain.Entities.Book> GenericRepositoryBookAsync;
        private readonly IGenericRepositoryAsync<Travel.Domain.Entities.Editorial> GenericRepositoryEditorialAsync;
        private readonly IGenericRepositoryAsync<Travel.Domain.Entities.AuthorHasBook> GenericRepositoryAuthorHasBookAsync;
        private readonly IGenericRepositoryAsync<Travel.Domain.Entities.Author> GenericRepositoryAuthorAsync;
        private readonly IBookRepositoryAsync BookRepositoryAsync;
        private readonly IMapper mapper;
        public CreateBookCompleteCommandHandler(
                                                 IGenericRepositoryAsync<Domain.Entities.Book> genericRepositoryBookAsync
                                               , IGenericRepositoryAsync<Domain.Entities.Editorial> genericRepositoryEditorialAsync
                                               , IGenericRepositoryAsync<Domain.Entities.AuthorHasBook> genericRepositoryAuthorHasBookAsync
                                               , IGenericRepositoryAsync<Domain.Entities.Author> genericRepositoryAuthorAsync
                                               , IBookRepositoryAsync bookRepositoryAsync, IMapper mapper)
        {
            GenericRepositoryBookAsync = genericRepositoryBookAsync;
            GenericRepositoryEditorialAsync = genericRepositoryEditorialAsync;
            GenericRepositoryAuthorHasBookAsync = genericRepositoryAuthorHasBookAsync;
            GenericRepositoryAuthorAsync = genericRepositoryAuthorAsync;
            BookRepositoryAsync = bookRepositoryAsync;
            this.mapper = mapper;
        }
        public async Task<BookDetailsDTO> Handle(CreateBookCompleteCommand request, CancellationToken cancellationToken)
        {

            var existBook = await this.BookRepositoryAsync.GetBookByTitleAsync(request.BookComplete.Title);
            if (existBook== null)
            {
                var editorial = this.mapper.Map<Travel.Domain.Entities.Editorial>(request.BookComplete.Editorial);
                await this.GenericRepositoryEditorialAsync.AddAsync(editorial);

                var book = new Travel.Domain.Entities.Book
                {
                    Editorial = editorial,
                    NumberPages = request.BookComplete.NumberPages,
                    Synopsis = request.BookComplete.Synopsis,
                    Title = request.BookComplete.Title
                };

                await this.GenericRepositoryBookAsync.AddAsync(book);

                var authors = this.mapper.Map<List<Travel.Domain.Entities.Author>>(request.BookComplete.Author);

                foreach (var item in authors)
                {
                    await this.GenericRepositoryAuthorAsync.AddAsync(item);
                    
                    await this.GenericRepositoryAuthorHasBookAsync.AddAsync(
                        new Domain.Entities.AuthorHasBook { 
                            Author=item,
                            Book=book
                        }
                        );
                }

                return request.BookComplete;

            }

            throw new Exception("No se pudo realizar la creacion del libro");
        }
    }
}
