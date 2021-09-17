using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Travel.Application.DTOs;
using Travel.Application.DTOs.Error;
using Travel.Application.Enums;
using Travel.Application.Exceptions;
using Travel.Application.Interfaces;
using Travel.Application.Interfaces.AuthorHasBook;
using Travel.Application.Interfaces.Book;
using Travel.Application.Interfaces.Helpers;
using Travel.Application.Wrappers;

namespace Travel.Application.Features.BookDetails.Querys.GetBookDetails
{
    public class GetBookDetailsHandler : IRequestHandler<GetBookDetailsQuery, ResponseSuccessful<BookDetailsDTO>>
    {

        
        private readonly IBookRepositoryAsync bookRepositoryAsync;
        private readonly IMapper mapper;
        private readonly IEnumerable<IValidator<GetBookDetailsQuery>> validators;
        private readonly IResponseErrorHelper responseErrorHelper;
        public GetBookDetailsHandler(IBookRepositoryAsync bookRepositoryAsync
                                   , IMapper mapper
                                   , IResponseErrorHelper responseErrorHelper
                                   , IEnumerable<IValidator<GetBookDetailsQuery>> validators)
        {

            this.bookRepositoryAsync = bookRepositoryAsync;
            this.mapper = mapper;
            this.responseErrorHelper = responseErrorHelper;
            this.validators = validators;
        }
        public async Task<ResponseSuccessful<BookDetailsDTO>> Handle(GetBookDetailsQuery request, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<GetBookDetailsQuery>(request);
            List<ValidationFailure> failures = validators.Select(x => x.Validate(context)).SelectMany(x => x.Errors).Where(x => x != null).ToList();
            var book = new Travel.Domain.Entities.Book();
            var bookDetailDto = new BookDetailsDTO();
            List<Travel.Domain.Entities.Author> authors = new List<Domain.Entities.Author>();


            if (!failures.Any())
            {
                (Travel.Domain.Entities.Book, List<ValidationFailure>) result = await BookDetailsSearch(request, failures);
                book = result.Item1;
                failures = result.Item2;
            }

            if (failures.Any())
            {
                List<ErrorDTO> response = responseErrorHelper.ConvertToResponse(failures);
                throw new CustomException<object>
                {
                    Response = response,
                    StatusHttpCode = HttpStatusCode.BadRequest,
                    
                };
            }



            return new ResponseSuccessful<BookDetailsDTO>
            {
                RequestResult = true,
                Data = mapper.Map<BookDetailsDTO>(book)
            };
        }

        private async Task<(Travel.Domain.Entities.Book, List<ValidationFailure>)> BookDetailsSearch(GetBookDetailsQuery request, List<ValidationFailure> failures)
        {
            var book=await this.bookRepositoryAsync.GetBookByIdCompleteAsync(request.BookId);

            if (book != null) return (book, failures);
            var newFailure = new ValidationFailure(nameof(request.BookId), "No se encontraron resultados")
            {
                ErrorCode = TypeCodeTravel.TR100.ToString()
            };
            failures.Add(newFailure);
            return (book, failures);
        }

    }
}
