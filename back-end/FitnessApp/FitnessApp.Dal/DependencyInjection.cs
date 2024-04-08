using FitnessApp.Dal.Dal;
using FitnessApp.Dal.Data;
using FitnessApp.Dal.IDal;
using FitnessApp.Dal.IData;
using Microsoft.Extensions.DependencyInjection;

namespace FitnessApp.Dal
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDalDependency(this IServiceCollection services)
        {
            services.AddTransient<IAuthDal,AuthDal>();
            services.AddTransient<IConnectionStringProvider, ConnectionStringProvider>();
            return services;
        }
    }
}
