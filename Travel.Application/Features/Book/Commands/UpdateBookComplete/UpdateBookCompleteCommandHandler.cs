using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Travel.Application.DTOs;
using Travel.Application.Interfaces.Book;

namespace Travel.Application.Features.Book.Commands.UpdateBookComplete
{
    public class UpdateBookCompleteCommandHandler : IRequestHandler<UpdateBookCompleteCommand, BookDetailsDTO>
    {
        private readonly IBookRepositoryAsync bookRepositoryAsync;

        public UpdateBookCompleteCommandHandler(IBookRepositoryAsync bookRepositoryAsync)
        {
            this.bookRepositoryAsync = bookRepositoryAsync;
        }
        public async Task<BookDetailsDTO> Handle(UpdateBookCompleteCommand request, CancellationToken cancellationToken)
        {
            var bookComplete = await this.bookRepositoryAsync.GetBookByIdCompleteAsync(request.BookId);
            if (bookComplete!=null)
            {
                var book = new Travel.Domain.Entities.Book
                {
                    ISBNId= bookComplete.ISBNId,
                    NumberPages = (bookComplete.NumberPages != request.Book.NumberPages) ? request.Book.NumberPages : bookComplete.NumberPages,
                    Title = (bookComplete.Title != request.Book.Title) ? request.Book.Title : bookComplete.Title,
                    Synopsis = (bookComplete.Synopsis != request.Book.Synopsis) ? request.Book.Synopsis : bookComplete.Synopsis,
                };

                var editorial = new Travel.Domain.Entities.Editorial { 
                    Id= bookComplete.Editorial.Id,
                    Name =(bookComplete.Editorial.Name != request.Book.Editorial.Name)? request.Book.Editorial.Name: bookComplete.Editorial.Name,
                    Headquarters = (bookComplete.Editorial.Headquarters != request.Book.Editorial.Headquarters) ? request.Book.Editorial.Headquarters : bookComplete.Editorial.Headquarters,
                };

                
            }
            else
            {
                throw new Exception("No se encontro el libro con la informacion suministrada");
            }
            throw new NotImplementedException();
        }
    }
}
