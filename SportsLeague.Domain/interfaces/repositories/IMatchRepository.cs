using System;
using System.Collections.Generic;
using System.Text;
using SportsLeague.Domain.entities;

namespace SportsLeague.Domain.interfaces.Repositories
{
    public interface IMatchRepository : IGenericRepository<Match>

    {

        Task<IEnumerable<Match>> GetByTournamentAsync(int tournamentId);

        Task<IEnumerable<Match>> GetByTeamAsync(int teamId);

        Task<Match?> GetByIdWithDetailsAsync(int id);

        Task<IEnumerable<Match>> GetByTournamentWithDetailsAsync(int tournamentId);

    }
}
