using FitnessApp.Repository.IRepositories;
using FitnessApp.Repository.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FitnessApp.Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositoryDependency(this IServiceCollection services)
        {
            services.AddTransient<IAuthRepository, AuthRepository>();
            return services;
        }
    }
}
