using Matchaholic.Processor.Model;
using Matchaholic.Processor.Model.Match;
using Matchaholic.Processor.Services.Interfaces;

namespace Matchaholic.Processor
{
    public class MatchProcesser : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<MatchProcesser> _logger;
        private readonly INotificationPublisher _notificationPublisher;
        private static int goalOrder = 1;

        public MatchProcesser(
            IServiceProvider serviceProvider,
            ILogger<MatchProcesser> logger,
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

                if (goalOrder <= 3)
                {
                    var match = await matchImportService.GetMatchDetail(goalOrder);
                    goalOrder++;

                    var notification = GetGoalNotification(match);
                    if (notification != null)
                    {
                        _ = await _notificationPublisher.PublishNotification(new Match
                        {
                            Description = notification
                        });
                    }                   
                }

                await Task.Delay(1000, stoppingToken);
            }
        }

        private static string? GetGoalNotification(Match? match)
        {
            var description = match?.MatchInfo.Description;
            var homeScore = match?.LiveData?.Goal?.LastOrDefault()?.HomeScore;
            var awayScore = match?.LiveData?.Goal?.LastOrDefault()?.AwayScore;
            var scorerName = match?.LiveData?.Goal?.LastOrDefault()?.ScorerName;
            var minute = match?.LiveData?.Goal?.LastOrDefault()?.TimeMin;

            if (IsInvalidGoalInfo(description, homeScore, awayScore, scorerName, minute)) return null;

            var goalNotification = $"{description} ({homeScore}-{awayScore}) GOALLLL!! {scorerName} scores in {minute}'";
            return goalNotification;
        }

        private static bool IsInvalidGoalInfo(string? description, int? homeScore, int? awayScore, string? scorerName, int? minute)
        {
            return description == null || homeScore == null || awayScore == null || scorerName == null || minute == null;
        }
    }
}