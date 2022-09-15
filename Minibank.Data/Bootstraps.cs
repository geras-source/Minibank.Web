using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Minibank.Core;
using Minibank.Core.Repositories;
using Minibank.Data.Users.Repositories;
using System;
    
namespace Minibank.Data
{
    public static class Bootstraps
    {
        public static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<ICourse, CourseHttpProvider>(option =>
            {
                option.BaseAddress = new Uri(configuration["CurrencyUri"]);
            });

            services.AddScoped<IUserRepository, UserRepotitory>();

            return services;
        }
    }
}