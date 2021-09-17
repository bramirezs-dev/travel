using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Application.Interfaces.Security;

namespace Travel.Security
{
    public static class ServiceExternsion
    {
        public static void AddSecurityCustom(this IServiceCollection service) {

            service.AddScoped<IJwtGenerator, JwtGenerator>();
        }
    }
}
