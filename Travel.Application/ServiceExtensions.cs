using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Travel.Application.Helpers;
using Travel.Application.Interfaces;
using Travel.Application.Interfaces.Helpers;

namespace Travel.Application
{
    public static class ServiceExtensions
    {
        public static void AddAplicationsLayer(this IServiceCollection service) {


            service.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            service.AddAutoMapper(Assembly.GetExecutingAssembly());
            service.AddMediatR(assemblies:Assembly.GetExecutingAssembly());

            service.AddTransient<IGeneralHelper, GeneralHelper>();
            service.AddTransient<IResponseErrorHelper, ResponseErrorHelper>();

        }
    }
}
