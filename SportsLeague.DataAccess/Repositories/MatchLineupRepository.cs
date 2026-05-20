using Microsoft.EntityFrameworkCore;
using SportsLeague.DataAccess.context;
using SportsLeague.Domain.Entities;
using SportsLeague.Domain.Interfaces.Repositories;


namespace SportsLeague.DataAccess.Repositories
{
    public class MatchLineupRepository : GenericRepository<MatchLineup>, IMatchLineupRepository//hacemos las migraciones hacia el generico y el irepository
    {
        public MatchLineupRepository(LeagueDbContext context) : base(context)
        {

        }

        public async Task<bool> ExistsByMatchAndPlayer(int matchId, int playerId)//buscamos si existe o no el equipo al cual esta asociado el jugador o el propio jugador

        {
            return await _dbSet
                 .AnyAsync(ml => ml.MatchId == matchId && ml.PlayerId == playerId);

        }

        public async Task<IEnumerable<MatchLineup>> GetByMatchAndTeamAsync(int MatchId, int TeamId)//buscamos tanto pot el partido como por el torneo si jugador esta asociado
        {
            return await _dbSet
                 .Include(ml => ml.PlayerId)
                 .Include(ml => ml.MatchId)
                 .Where(ml => ml.MatchId == MatchId && ml.Player.TeamId == TeamId)
                 .ToListAsync();
            
        }

        public async Task<IEnumerable<MatchLineup>> GetByMatchAsync(int MatchId)
        {
            return await _dbSet

                  .Include(ml => ml.MatchId)
                  .Include(ml => ml.PlayerId)
                  .Where(ml => ml.MatchId == MatchId)
                  .ToListAsync();

        }
    }
}
