using SportsLeague.Domain.entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportsLeague.Domain.interfaces.Repositories
{
    public interface ITournamentTeamRepository : IGenericRepository<TournamentTeam>

    {

        Task<TournamentTeam?> GetByTournamentAndTeamAsync(int tournamentId, int teamId);

        Task<IEnumerable<TournamentTeam>> GetByTournamentAsync(int tournamentId);

    }
}
