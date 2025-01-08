using Blog.Core.Repositories;
using Blog.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.DAL;

public static class ServiceRegistration
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
