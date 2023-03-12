using Matchaholic.Processor.Model;
using Matchaholic.Processor.Services.Interfaces;

namespace Matchaholic.Processor
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly INotificationPublisher _notificationPublisher;

        public Worker(ILogger<Worker> logger, INotificationPublisher notificationPublisher)
        {
            _logger = logger;
            _notificationPublisher = notificationPublisher;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                var publishResponse = await _notificationPublisher.PublishNotification(new Match
                {
                   Description = "Hamburger SV vs Sandhausen 1-0"
                });
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}