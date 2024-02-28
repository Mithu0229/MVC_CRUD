using MVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_CRUD.Extensions
{
    public static class AppServiceExtentions
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {

            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddTransient<IMvcUnitOfWork, MvcUnitOfWork>();
            services.AddTransient<IEmployeeService, EmployeeService>();

            return services;
        }
    }
}
