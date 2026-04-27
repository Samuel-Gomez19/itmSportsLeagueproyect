using SportsLeague.Domain.entities;
using SportsLeague.Domain.interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportsLeague.Domain.interfaces.repositories
{
    public interface IGoalRepository : IGenericRepository<Goal>

    {

        Task<IEnumerable<Goal>> GetByMatchAsync(int matchId);

        Task<IEnumerable<Goal>> GetByMatchWithDetailsAsync(int matchId);

    }
}
