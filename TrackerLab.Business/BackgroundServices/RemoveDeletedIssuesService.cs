using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLab.Data;

namespace TrackerLab.Business.BackgroundServices
{
    public class RemoveDeletedIssuesService : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly ILogger<RemoveDeletedIssuesService> _logger;

        public RemoveDeletedIssuesService(IServiceScopeFactory serviceScopeFactory, ILogger<RemoveDeletedIssuesService> logger)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogWarning("Removing deleted Issues");
                using var scope = _serviceScopeFactory.CreateScope();

                try
                {
                    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                    var deletedIssuesCount = await RemoveDeletedIssues(context, stoppingToken);

                    _logger.LogInformation("Finished removing {Count} deleted issues", deletedIssuesCount);
                    await Task.Delay(TimeSpan.FromDays(14), stoppingToken);
                }
                catch (OperationCanceledException)
                {
                    return;
                }
            }
        }

        private async Task<int> RemoveDeletedIssues(AppDbContext context, CancellationToken stoppingToken)
        {
            var deletedIssues = await context.Issues.IgnoreQueryFilters()
                       .Where(x => x.Deleted.HasValue && x.Deleted.Value < DateTime.UtcNow.AddDays(-30))
                       .ToListAsync(stoppingToken);

            context.Issues.RemoveRange(deletedIssues);
            await context.SaveChangesAsync(stoppingToken);

            return deletedIssues.Count;
        }
    }
}
