using Oyun.Services.Abstracts;
using Oyun.Services.Implements;

namespace Oyun;

public static class ServiceRegistrations
{
    public static IServiceCollection AddService(this IServiceCollection services)
    {
        services.AddScoped<ILanguageService, LanguageService>();
        services.AddScoped<IWordService, WordService>();
        services.AddScoped<IBannedWordService, BannedWordService>();
        services.AddScoped<IGameService, GameService>();

        return services;
    }
}
