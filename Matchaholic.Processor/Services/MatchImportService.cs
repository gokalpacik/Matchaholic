using Matchaholic.Processor.Model.Match;
using Matchaholic.Processor.Resources;
using Matchaholic.Processor.Services.Interfaces;
using System.Text.Json;

namespace Matchaholic.Processor.Services
{
    public class MatchImportService : IMatchImportService
    {
        private static JsonSerializerOptions jsonSerializerCaseInsensitiveOption = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public Task<Match?> GetMatchDetail(int goalOrder)
        {
            var test = ExampleData.ResourceManager.GetObject($"goal{goalOrder}", System.Globalization.CultureInfo.CurrentCulture);            
            var match= JsonSerializer.Deserialize<Match>((byte[])test!, jsonSerializerCaseInsensitiveOption);
            return Task.FromResult(match);
        }
    }
}
