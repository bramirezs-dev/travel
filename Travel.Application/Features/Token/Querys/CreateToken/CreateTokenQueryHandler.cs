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
using Travel.Application.Interfaces.Helpers;
using Travel.Application.Interfaces.Security;
using Travel.Application.Wrappers;

namespace Travel.Application.Features.Token.Querys.CreateToken
{
    public class CreateTokenQueryHandler : IRequestHandler<CreateTokenQuery, ResponseSuccessful<TokenDTO>>
    {
        private readonly IJwtGenerator jwtGenerator;
        private readonly IEnumerable<IValidator<CreateTokenQuery>> validators;
        private readonly IResponseErrorHelper responseErrorHelper;

        public CreateTokenQueryHandler(IJwtGenerator jwtGenerator, IEnumerable<IValidator<CreateTokenQuery>> validators, IResponseErrorHelper responseErrorHelper)
        {
            this.jwtGenerator = jwtGenerator;
            this.validators = validators;
            this.responseErrorHelper = responseErrorHelper;
        }

        public async Task<ResponseSuccessful<TokenDTO>> Handle(CreateTokenQuery request, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<CreateTokenQuery>(request);
            List<ValidationFailure> failures = validators.Select(x => x.Validate(context)).SelectMany(x => x.Errors).Where(x => x != null).ToList();
            TokenDTO tokenDTO = new TokenDTO();


            if (!failures.Any())
            {
                if (request.User != "Us3rW3bBl4zor")
                {
                    var newFailure = new ValidationFailure(nameof(request.User), "Usuario no valido")
                    {
                        ErrorCode = TypeCodeTravel.TR102.ToString()
                    };
                    failures.Add(newFailure);
                }
                else
                {

                    tokenDTO.Token = (string)this.jwtGenerator.CreateToken(request.User);
                }
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

            return new ResponseSuccessful<TokenDTO>
            {
                RequestResult = true,
                Data = tokenDTO
            };

        }
    }
}
