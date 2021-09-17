using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Travel.Application.Exceptions;
using Travel.Application.Wrappers;

namespace Travel.API.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }


        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = new ResponseIncorrect<object>();

                switch (error)
                {
                    case CustomException<object> e:
                        response.StatusCode = e.StatusHttpCode == 0 ? 500 : (int)e.StatusHttpCode;
                        responseModel.Errors = e.Response;
                        break;
                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }
                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                var result = JsonSerializer.Serialize(responseModel, options);
                await response.WriteAsync(result);
            }
        }

    }
}
