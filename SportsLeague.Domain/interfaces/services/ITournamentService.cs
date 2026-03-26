using SportsLeague.Domain.entities;
using SportsLeague.Domain.enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportsLeague.Domain.interfaces.services
{
    


    public interface ITournamentService

    {

        Task<IEnumerable<Tournament>> GetAllAsync();

        Task<Tournament?> GetByIdAsync(int id);

        Task<Tournament> CreateAsync(Tournament tournament);

        Task UpdateAsync(int id, Tournament tournament);

        Task DeleteAsync(int id);

        Task UpdateStatusAsync(int id, TournamentStatus newStatus);

        Task RegisterTeamAsync(int tournamentId, int teamId);

        Task<IEnumerable<Team>> GetTeamsByTournamentAsync(int tournamentId);

    }
}
