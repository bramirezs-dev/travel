using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Application.Enums;

namespace Travel.Application.Features.BookDetails.Querys.GetBookDetails
{
    public class GetBookDetailsQueryValidator: AbstractValidator<GetBookDetailsQuery>
    {
        public GetBookDetailsQueryValidator()
        {
            Validator();
        }

        public void Validator()
        {
            RuleFor(x => x.BookId).NotEmpty().WithErrorCode(TypeCodeTravel.TR101.ToString());
            
        }
    }
}
