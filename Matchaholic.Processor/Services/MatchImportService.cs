using Amazon.Auth.AccessControlPolicy;
using Matchaholic.Processor.Model.Match;
using Matchaholic.Processor.Resources;
using Matchaholic.Processor.Services.Interfaces;
using System.Text;
using System.Text.Json;

namespace Matchaholic.Processor.Services
{
    public class MatchImportService : IMatchImportService
    {
        private static JsonSerializerOptions jsonSerializerCaseInsensitiveOption = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public Task ImportMatch()
        {
            //var test = ExampleData.ResourceManager.GetObject("first_goal", System.Globalization.CultureInfo.CurrentCulture);
            var match = JsonSerializer.Deserialize<Match>(Encoding.UTF8.GetString(ExampleData.first_goal), jsonSerializerCaseInsensitiveOption);
            return Task.CompletedTask;
        }
    }
}
