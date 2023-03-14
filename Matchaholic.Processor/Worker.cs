using Matchaholic.Processor.Model;
using Matchaholic.Processor.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Matchaholic.Processor
{
    public class Worker : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<Worker> _logger;
        private readonly INotificationPublisher _notificationPublisher;

        public Worker(
            IServiceProvider serviceProvider,
            ILogger<Worker> logger, 
            INotificationPublisher notificationPublisher)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
            _notificationPublisher = notificationPublisher;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                using var scope = _serviceProvider.CreateScope();
                var matchImportService = scope.ServiceProvider.GetRequiredService<IMatchImportService>();
                await matchImportService.ImportMatch();

                _ = await _notificationPublisher.PublishNotification(new Match
                {
                    Description = "Hamburger SV vs Sandhausen 1-0"
                });
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}