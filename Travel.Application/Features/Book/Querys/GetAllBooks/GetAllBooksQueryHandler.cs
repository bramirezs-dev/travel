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
using Travel.Application.Wrappers;

namespace Travel.Application.Features.Book.Querys.GetAllBooks
{
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, ResponseSuccessful<List<BookDTO>>>
    {

        private readonly IBookRepositoryAsync bookRepositoryAsync;
        private readonly IMapper mapper;

        public GetAllBooksQueryHandler(IBookRepositoryAsync bookRepositoryAsync, IMapper mapper)
        {
            this.bookRepositoryAsync = bookRepositoryAsync;
            this.mapper = mapper;
        }

        

        public async Task<ResponseSuccessful<List<BookDTO>>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {

            var books= await this.bookRepositoryAsync.GetAllBookCompleteAsync();
            
            if (books.Count > 0)
            {
               
            }

            return new ResponseSuccessful<List<BookDTO>>
            {
                RequestResult = true,
                Data = this.mapper.Map<List<BookDTO>>(books)
            };

        }
    }
}
