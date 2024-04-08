using FitnessApp.Facade.Facade;
using FitnessApp.Facade.IFacade;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Facade
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddFacadeDependency(this IServiceCollection services)
        {
            services.AddTransient<IAuthFacade, AuthFacade>();
            return services;
        }
    }
}
