using SportsLeague.Domain.entities;
using SportsLeague.Domain.enums;



namespace SportsLeague.Domain.interfaces.services
{
    public interface IMatchService

    {

        Task<IEnumerable<Match>> GetAllByTournamentAsync(int tournamentId);

        Task<Match?> GetByIdAsync(int id);

        Task<Match> CreateAsync(Match match);

        Task UpdateAsync(int id, Match match);

        Task DeleteAsync(int id);

        Task UpdateStatusAsync(int id, MatchStatus newStatus);
        Task UpdateAsync(int id, System.Text.RegularExpressions.Match match);
    }
}
