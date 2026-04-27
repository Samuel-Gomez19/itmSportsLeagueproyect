using SportsLeague.DataAccess.context;
using Microsoft.EntityFrameworkCore;
using SportsLeague.Domain.entities;
using SportsLeague.Domain.interfaces.repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportsLeague.DataAccess.Repositories
{
    public class CardRepository : GenericRepository<Card>, ICardRepository

    {

        public CardRepository(LeagueDbContext context) : base(context) { }



        public async Task<IEnumerable<Card>> GetByMatchAsync(int matchId)

        {

            return await _dbSet

                .Where(c => c.MatchId == matchId)

                .OrderBy(c => c.Minute)

                .ToListAsync();

        }



        public async Task<IEnumerable<Card>> GetByMatchWithDetailsAsync(int matchId)

        {

            return await _dbSet

                .Where(c => c.MatchId == matchId)

                .Include(c => c.Player)

                .OrderBy(c => c.Minute)

                .ToListAsync();

        }

    }
}
