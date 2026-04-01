using SportsLeague.Domain.entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportsLeague.Domain.interfaces.repositories
{
    public interface ITournamentSponsorRepository: IGenericRepository<TournamentSponsor>// creo el Irepository donde hereda los metodos del generic
    {
        Task<TournamentSponsor?> GetByTournamentAndSponsor(int TournamentId, int SponsorId);

        Task<IEnumerable<TournamentSponsor>> GetBySponsorAsync(int SponsorId);// para buscar segun el id del sponsor 

    }
}
