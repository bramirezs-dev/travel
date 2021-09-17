using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Application.DTOs.Error;
using Travel.Application.Interfaces.Helpers;

namespace Travel.Application.Helpers
{
    public class ResponseErrorHelper : IResponseErrorHelper
    {
        public List<ErrorDTO> ConvertToResponse(List<ValidationFailure> failures)
        {
            var errorDTOs = new List<ErrorDTO>();
            foreach (ValidationFailure failure in failures)
            {
                errorDTOs.Add(new ErrorDTO { Field = failure.PropertyName, InternalCode = failure.ErrorCode, Msg = failure.ErrorMessage});
            }

            return errorDTOs;

        }
    }
}
