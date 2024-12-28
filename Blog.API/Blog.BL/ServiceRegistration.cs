using Blog.BL.Services.Implements;
using Blog.BL.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.BL
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            return services;
        }
    }
}
