using Microsoft.EntityFrameworkCore;
using SportsLeague.DataAccess.context;
using SportsLeague.Domain.entities;
using SportsLeague.Domain.enums;
using SportsLeague.Domain.interfaces.Repositories;

namespace SportsLeague.DataAccess.Repositories
{
    public class SponsorRepository : GenericRepository<Sponsor>, ISponsorRepository//creamos la logica de implementacion del repositorio, donde solamente definimos la logica de los metodos propios
    {
        public SponsorRepository(LeagueDbContext context) : base(context)
        {
        }

        public async Task<Sponsor?> ExistByNameAsync(string SponsorName)//Implementamos el metodo que permite ver si hay otro sponsor llamado igual
        {
            return await _dbSet
                .FirstOrDefaultAsync(s => s.SponsorName == SponsorName);//Con esta funcion conseguimos filtrar el primer resultado que nos coincida 

        }

        
        public async Task AddToTournamentAsync(int tournamentId, int sponsorId)
        {
            var tournamentSponsor = new TournamentSponsor
            {
                TournamentId = tournamentId,
                SponsorId = sponsorId
            };
            await _context.TournamentSponsors.AddAsync(tournamentSponsor);
            await _context.SaveChangesAsync();
        }
    }
}