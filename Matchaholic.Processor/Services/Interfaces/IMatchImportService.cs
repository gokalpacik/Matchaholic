using Matchaholic.Processor.Model.Match;

namespace Matchaholic.Processor.Services.Interfaces
{
    public interface IMatchImportService
    {
        Task<Match?> GetMatchDetail(int goalOrder);
    }
}
