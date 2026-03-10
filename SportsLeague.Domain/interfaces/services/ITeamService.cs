using SportsLeague.Domain.entities;

namespace SportsLeague.Domain.interfaces.services
{
    public interface ITeamService

    {

        Task<IEnumerable<Team>> GetAllAsync();

        Task<Team?> GetByIdAsync(int id);

        Task<Team> CreateAsync(Team team);

        Task UpdateAsync(int id, Team team);

        Task DeleteAsync(int id);

    }
}
