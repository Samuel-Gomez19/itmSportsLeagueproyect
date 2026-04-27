using SportsLeague.Domain.entities;
using SportsLeague.Domain.interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportsLeague.Domain.interfaces.repositories
{
    



    public interface IMatchResultRepository : IGenericRepository<MatchResult>

    {

        Task<MatchResult?> GetByMatchIdAsync(int matchId);

    }
}
