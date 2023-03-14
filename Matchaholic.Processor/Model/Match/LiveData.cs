namespace Matchaholic.Processor.Model.Match
{
    public record LiveData
    {
        public MatchDetails MatchDetails { get; init; } = new();
        public IReadOnlyCollection<Goal> Goal { get; init; } = new List<Goal>();
    }
}
