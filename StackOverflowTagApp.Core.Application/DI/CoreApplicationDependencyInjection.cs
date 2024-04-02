using Microsoft.Extensions.DependencyInjection;
using StackOverflowTagApp.Core.Application.Mappers;
using StackOverflowTagApp.Core.Application.Services;

namespace StackOverflowTagApp.Core.Application.DI;

public static class CoreApplicationDependencyInjection
{
    public static void AddCoreApplicationServices (this IServiceCollection services)
    {
        services.AddScoped<TagsReadService>();
        services.AddScoped<TagMapper>();
    }
}
