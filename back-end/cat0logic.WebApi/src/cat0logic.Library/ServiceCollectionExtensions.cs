using Microsoft.Extensions.DependencyInjection;

namespace cat0logic.Library
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMoviesLibrary(this IServiceCollection services)
        {
            services.AddTransient<MovieService>();
            services.AddTransient<ReviewService>();
            services.AddTransient<MovieIdentityService>();
            services.AddTransient<ReviewPermissionService>();

            return services;
        }
    }
}
