using SportsLeague.Domain.entities;

namespace SportsLeague.Domain.interfaces.repositories
{ 
    public interface ISponsorRepository : IGenericRepository<Sponsor>// creo el IRepository donde hereda los metodos del generic 
    {
        Task<Sponsor?> ExistByNameAsync(string SponsorName);//para ver si es repetido el nombre del sponsor 
        
        Task<Sponsor?> GetByIdWithTournamentAsync(int Id);
        Task AddToTournamentAsync(int tournamentId, int sponsorId);
    }
}
