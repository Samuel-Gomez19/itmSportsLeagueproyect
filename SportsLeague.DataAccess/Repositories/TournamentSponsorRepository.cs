using Microsoft.EntityFrameworkCore;
using SportsLeague.DataAccess.context;
using SportsLeague.Domain.entities;
using SportsLeague.Domain.enums;
using SportsLeague.Domain.interfaces.repositories;
namespace SportsLeague.DataAccess.Repositories
{
    public class TournamentSponsorRepository : GenericRepository<TournamentSponsor>, ITournamentSponsorRepository//Implementamos el repository con los metodos del generic y del ITournamentSponsor
    {
        public TournamentSponsorRepository(LeagueDbContext context) : base(context)
        {
        }

        public async Task<TournamentSponsor?> GetByTournamentAndSponsor(int tournamentId, int sponsorId)//logramos buscar por cualquiera de las dos ids
        {
            return await _dbSet
                .Where(ts => ts.TournamentId == tournamentId && ts.SponsorId == sponsorId)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TournamentSponsor>> GetBySponsorAsync(int sponsorId)
        {
            return await _dbSet
                .Where(ts => ts.SponsorId == sponsorId)
                .Include(ts => ts.tournament)
                .ToListAsync();
        }
    }
}

