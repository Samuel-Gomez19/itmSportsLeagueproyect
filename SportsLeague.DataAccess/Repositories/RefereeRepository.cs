using Microsoft.EntityFrameworkCore;
using SportsLeague.DataAccess.context;
using SportsLeague.Domain.entities;
using SportsLeague.Domain.interfaces.Repositories;
using SportsLeague.Domain.interfaces.Repositories.SportsLeague.Domain.Interfaces.Repositories;

namespace SportsLeague.DataAccess.Repositories
{
    public class RefereeRepository : GenericRepository<Referee>, IRefereeRepository

    {

        public RefereeRepository(LeagueDbContext context) : base(context)

        {

        }


        public async Task<IEnumerable<Referee>> GetByNationalityAsync(string nationality)

        {

            return await _dbSet

            .Where(r => r.Nationality.ToLower() == nationality.ToLower())

            .ToListAsync();
        }
    }
}
