
using System.Text.Json.Serialization;

namespace Matchaholic.Processor.Model.MobilePush
{
    public class MobilePushNotification
    {
        [JsonPropertyName("body")]
        public string Body { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        public MobilePushNotification(string title, string body)
        {
            Title = title;
            Body = body;
        }
    }
}
