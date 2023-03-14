namespace Matchaholic.Processor.Model.Match
{
    public record MatchDetails
    {
        public string MatchStatus { get; init; } = string.Empty;
        public Scores? Scores { get; init; }
    }
}
