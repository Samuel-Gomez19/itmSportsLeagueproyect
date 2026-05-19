using SportsLeague.Domain.entities;
using SportsLeague.Domain.enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportsLeague.Domain.Interfaces.Repositories
{
    public interface ITournamentRepository : IGenericRepository<Tournament>

    {

        Task<IEnumerable<Tournament>> GetByStatusAsync(TournamentStatus status);

        Task<Tournament?> GetByIdWithTeamsAsync(int id);

    }
}
