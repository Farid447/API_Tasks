using Oyun.Services.Abstracts;
using Oyun.Services.Implements;

namespace Oyun;

public static class ServiceRegistrations
{
    public static IServiceCollection AddService(this IServiceCollection services)
    {
        services.AddScoped<ILanguageService, LanguageService>();
        return services;
    }
}
