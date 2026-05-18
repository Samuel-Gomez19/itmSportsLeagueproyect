using System;
using System.Collections.Generic;
using System.Text;

namespace SportsLeague.Domain.interfaces.services
{


    public interface IStandingsService

    {

        Task<object> GetStandingsAsync(int tournamentId);

        Task<object> GetTopScorersAsync(int tournamentId);

        Task<object> GetCardStatsAsync(int tournamentId);

    }
}
