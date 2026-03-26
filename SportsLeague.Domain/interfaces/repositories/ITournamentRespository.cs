using SportsLeague.Domain.entities;
using SportsLeague.Domain.enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportsLeague.Domain.interfaces.repositories
{
    public interface ITournamentRepository : IGenericRepository<Tournament>

    {

        Task<IEnumerable<Tournament>> GetByStatusAsync(TournamentStatus status);

        Task<Tournament?> GetByIdWithTeamsAsync(int id);

    }
}
