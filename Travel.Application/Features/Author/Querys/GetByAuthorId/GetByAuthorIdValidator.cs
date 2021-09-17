using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Application.Features.Author.Querys.GetByAuthorId
{
    public class GetByAuthorIdValidator:AbstractValidator<GetByAuthorIdQuery>
    {
        public GetByAuthorIdValidator()
        {
            Validator();
        }

        public void Validator() {

            RuleFor(x => x.AuthorId).NotEmpty().WithMessage("Se debe ingresar un AuthorId valido");
        }
    }
}
