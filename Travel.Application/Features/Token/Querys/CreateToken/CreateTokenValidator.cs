using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Application.Enums;

namespace Travel.Application.Features.Token.Querys.CreateToken
{
    public class CreateTokenValidator:AbstractValidator<CreateTokenQuery>
    {
        public CreateTokenValidator()
        {
            Validator();
        }

        public void Validator()
        {
            RuleFor(x => x.User).NotEmpty().WithErrorCode(TypeCodeTravel.TR101.ToString());

        }
    }
}
