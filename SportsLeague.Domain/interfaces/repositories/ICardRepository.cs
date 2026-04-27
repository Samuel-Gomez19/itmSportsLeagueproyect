using SportsLeague.Domain.entities;
using SportsLeague.Domain.interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportsLeague.Domain.interfaces.repositories
{
    public interface ICardRepository : IGenericRepository<Card>

    {

        Task<IEnumerable<Card>> GetByMatchAsync(int matchId);

        Task<IEnumerable<Card>> GetByMatchWithDetailsAsync(int matchId);

    }
}
