using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace StackOverflowTagApp.Core.Infrastructure.StackOverflow.Services;

public class StackOverflowTagsSyncHostedService : IHostedService
{
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly StackOverflowTagsSyncService _stackOverflowTagsSyncService;

    public StackOverflowTagsSyncHostedService(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using (var scope = _serviceScopeFactory.CreateScope())
        {
            var stackOverflowTagsSyncService = scope.ServiceProvider.GetRequiredService<StackOverflowTagsSyncService>();
            await stackOverflowTagsSyncService.SyncTagsAsync();
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
