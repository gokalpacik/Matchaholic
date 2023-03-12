using Amazon.SimpleNotificationService.Model;
using Matchaholic.Processor.Model;

namespace Matchaholic.Processor.Services.Interfaces
{
    public interface INotificationPublisher
    {
        Task<PublishResponse> PublishNotification(Match match);
    }
}