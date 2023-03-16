using Amazon.SimpleNotificationService.Model;
using Matchaholic.Processor.Model.MobilePush;

namespace Matchaholic.Processor.Services.Interfaces
{
    public interface INotificationPublisher
    {
        Task<PublishResponse> PublishNotification(Notification notification);
    }
}