using Amazon;
using Amazon.Runtime;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using Matchaholic.Processor.Model.Match;
using Matchaholic.Processor.Model.Setings;
using Matchaholic.Processor.Services.Interfaces;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace Matchaholic.Processor.Services
{
    public class SNSNotificationPublisher : INotificationPublisher
    {
        private readonly ILogger _logger;
        private readonly SNSSettings _snsSettings;
        private readonly IAmazonSimpleNotificationService _snsClient;

        public SNSNotificationPublisher(
            IOptions<SNSSettings> snsSettings,
            ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<SNSNotificationPublisher>();
            _snsSettings = snsSettings.Value;

            var region = RegionEndpoint.GetBySystemName(_snsSettings.AWSRegion);

            _snsClient = new AmazonSimpleNotificationServiceClient(
                new BasicAWSCredentials(
                    _snsSettings.AWSAccessKey,
                    _snsSettings.AWSSecretKey),
                region
            );
        }

        public async Task<PublishResponse> PublishNotification(Match eventData)
        {
            try
            {
                var publishRequest = new PublishRequest
                {
                    TopicArn = _snsSettings.TopicArn,
                    Message = JsonSerializer.Serialize(eventData),
                    Subject = $"Goal!!!!!"
                };

                PublishResponse publishResponse = await _snsClient.PublishAsync(publishRequest);
                return publishResponse;
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Couldn't publish an event to SNS");
                throw;
            }
        }
    }
}
