

using System.Text.Json.Serialization;

namespace Matchaholic.Processor.Model.MobilePush
{
    public class SNSMessage
    {
        [JsonPropertyName("default")]
        public string DefaultContent { get; }

        [JsonPropertyName("GCM")]
        public string FCMContent { get; set; }


        public SNSMessage(string defaultContent)
        {
            DefaultContent = defaultContent;
        }
    }
}
