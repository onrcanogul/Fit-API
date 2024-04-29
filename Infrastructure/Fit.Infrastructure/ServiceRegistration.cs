using Fit.Application.Abstractions.Services.Token;
using Fit.Infrastructure.Services.Token;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fit.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfstructuresServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenHandler, TokenHandler>();
        }
    }
}
