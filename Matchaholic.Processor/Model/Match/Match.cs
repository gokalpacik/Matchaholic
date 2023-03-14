using Serilog.Filters;
namespace Matchaholic.Processor.Model.Match
{
    public record Match
    {
        public string Description { get; set; } = string.Empty;
        public MatchInfo MatchInfo { get; init; } = new();
        public LiveData? LiveData { get; init; }

    }
}
