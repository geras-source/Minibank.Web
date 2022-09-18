using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Minibank.Core.Domains.Users.Services;
using Minibank.Core.Domains.Account.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minibank.Core
{
    public static class Bootstraps
    {
        public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddScoped<IConvector, Convector>()
                .AddScoped<IUserServices, UserServices>()
                .AddScoped<IAccountServices, AccountServices>();   

            return services;
        }
    }
}