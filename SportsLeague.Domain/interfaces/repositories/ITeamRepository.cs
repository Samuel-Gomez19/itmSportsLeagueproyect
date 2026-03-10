using SportsLeague.Domain.entities;

namespace SportsLeague.Domain.interfaces.repositories
{
    public interface ITeamRepository : IGenericRepository<Team>

    {

        Task<Team?> GetByNameAsync(string name);

        Task<IEnumerable<Team>> GetByCityAsync(string city);

    }
}
