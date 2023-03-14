namespace Matchaholic.Processor.Model.Match
{
    public record Goal
    {
        public string Type { get; init; } = string.Empty;
        public string ScorerId { get; init; } = string.Empty;
        public string ScorerName { get; init; } = string.Empty;
        public string Timestamp { get; init; } = string.Empty;
        public int HomeScore { get; init; }
        public int AwayScore { get; init; }
        public string AssistPlayerId { get; init; } = string.Empty;
        public string AssistPlayerName { get; init; } = string.Empty;
        public string ContestantId { get; init; } = string.Empty;
        public int PeriodId { get; init; }
        public int TimeMin { get; init; }
    }
}
