using Microsoft.Extensions.DependencyInjection;
using StackOverflowTagApp.Core.Infrastructure.Repositories;
using StackOverflowTagApp.Core.Infrastructure.StackOverflow.Mappers;
using StackOverflowTagApp.Core.Infrastructure.StackOverflow.Services;

namespace StackOverflowTagApp.Core.Infrastructure.DI;

public static class StackOverflowServiceDependencyInjection
{
    public static void AddStackOverflowServices(this IServiceCollection services)
    {
        services.AddScoped<StackOverflowTagsSyncService>();
        services.AddScoped<StackOverflowTagMapper>();
        services.AddScoped<TagWriteRepository>();
    }
}
