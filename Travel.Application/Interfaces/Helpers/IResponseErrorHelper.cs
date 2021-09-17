using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Application.DTOs.Error;

namespace Travel.Application.Interfaces.Helpers
{
    public interface IResponseErrorHelper
    {
        List<ErrorDTO> ConvertToResponse(List<ValidationFailure> failures);
    }
}
