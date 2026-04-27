using SportsLeague.Domain.entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportsLeague.Domain.interfaces.Repositories
{
    namespace SportsLeague.Domain.Interfaces.Repositories
    {

        public interface IRefereeRepository : IGenericRepository<Referee>

        {

            Task<IEnumerable<Referee>> GetByNationalityAsync(string nationality);

        }
    }
}
