using Microsoft.Extensions.DependencyInjection;
using StackOverflowTagApp.Core.Application.Mappers;
using StackOverflowTagApp.Core.Application.Models;
using StackOverflowTagApp.Core.Application.Services;
using StackOverflowTagApp.Core.Domain;
using StackOverflowTagApp.Core.Infrastructure.Abstractions;

namespace StackOverflowTagApp.Core.Application.DI;

public static class CoreApplicationDependencyInjection
{
    public static void AddCoreApplicationServices (this IServiceCollection services)
    {
        services.AddScoped<TagsReadService>();
        services.AddScoped<IMapper<TagEntity, TagOutDto>, TagMapper>();
    }
}
