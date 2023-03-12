using System.Text.Json;
using System.Text.Json.Serialization;

namespace Matchaholic.Processor.Model.MobilePush
{
    public class FCMNotification
    {
        [JsonPropertyName("notification")]
        public MobilePushNotification Notification { get; set; }

        [JsonPropertyName("data")]
        public Dictionary<string, string> Data { get; set; }

        public FCMNotification() => Data = new Dictionary<string, string>();

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
