using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Minibank.Core;
using Minibank.Core.Repositories;
using Minibank.Data.Users.Repositories;
using Minibank.Core.Domains.Account.Repositories;
using System;
using Minibank.Data.Account.Repositories;

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

            services
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IBankAccountRepository, BankAccountRepository>();

            return services;
        }
    }
}