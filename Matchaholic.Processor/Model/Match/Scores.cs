namespace Matchaholic.Processor.Model.Match
{
    public record Scores
    {
        public Score? Ht { get; init; }
        public Score? Ft { get; init; }
        public Score? Et { get; init; }
        public Score? Pen { get; init; }
        public Score? Total { get; init; }
    }
}
