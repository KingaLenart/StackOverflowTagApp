using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackOverflowTagApp.Core.Services.Implementations;

namespace StackOverflowTagApp.Core.Services.DI
{
    public static class StackOverflowServiceDependencyInjection
    {
        public static void AddStackOverflowServices(this IServiceCollection services)
        {
            services.AddScoped<StackOverflowReadTagsService>();
            services.AddScoped<TagMapper>();
            services.AddScoped<TagWriteRepository>();
        }
    }
}
