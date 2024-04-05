using Microsoft.Extensions.DependencyInjection;
using StackOverflowTagApp.Core.Domain;
using StackOverflowTagApp.Core.Domain.Abstractions;
using StackOverflowTagApp.Core.Infrastructure.Abstractions;
using StackOverflowTagApp.Core.Infrastructure.Repositories;
using StackOverflowTagApp.Core.Infrastructure.StackOverflow.Mappers;
using StackOverflowTagApp.Core.Infrastructure.StackOverflow.Models;
using StackOverflowTagApp.Core.Infrastructure.StackOverflow.Services;

namespace StackOverflowTagApp.Core.Infrastructure.DI;

public static class StackOverflowServiceDependencyInjection
{
    public static void AddStackOverflowServices(this IServiceCollection services)
    {
        services.AddScoped<StackOverflowTagsSyncService>();
        services.AddScoped<TagWriteRepository>();
        services.AddScoped<StackOverflowTagMapper>();
        services.AddScoped<ITagReadRepository, TagReadRepository>();
        services.AddScoped<IMapper<StackOverflowTag, double, TagEntity>, StackOverflowTagMapper>();
        services.AddHostedService<StackOverflowTagsSyncHostedService>();
    }
}
