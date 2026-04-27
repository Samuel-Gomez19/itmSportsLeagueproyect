using SportsLeague.DataAccess.context;
using SportsLeague.Domain.entities;
using SportsLeague.Domain.interfaces.repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace SportsLeague.DataAccess.Repositories
{
    public class GoalRepository : GenericRepository<Goal>, IGoalRepository

    {

        public GoalRepository(LeagueDbContext context) : base(context) { }



        public async Task<IEnumerable<Goal>> GetByMatchAsync(int matchId)

        {

            return await _dbSet

                .Where(g => g.MatchId == matchId)

                .OrderBy(g => g.Minute)

                .ToListAsync();

        }



        public async Task<IEnumerable<Goal>> GetByMatchWithDetailsAsync(int matchId)

        {

            return await _dbSet

                .Where(g => g.MatchId == matchId)

                .Include(g => g.Player)

                .OrderBy(g => g.Minute)

                .ToListAsync();

        }

    }
}
