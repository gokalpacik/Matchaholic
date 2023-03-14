namespace Matchaholic.Processor.Model.Match
{
    public record MatchInfo
    {
        public string Id { get; init; } = string.Empty;
        public string Date { get; init; } = string.Empty;
        public string? Time { get; init; }
        public string? Description { get; init; }
    }
}
