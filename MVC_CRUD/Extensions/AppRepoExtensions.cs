using Microsoft.Extensions.DependencyInjection;
using MVC.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_CRUD.Extensions
{
    public static class AppRepoExtensions
    {
        public static IServiceCollection AddAppRepos(this IServiceCollection services)
        {

            services.AddTransient<IEmployeeRepository, EmployeeRepository>();

            return services;
        }
    }
}
