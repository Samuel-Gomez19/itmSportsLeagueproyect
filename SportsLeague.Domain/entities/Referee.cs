using System;
using System.Collections.Generic;
using System.Text;

namespace SportsLeague.Domain.entities
{
    public class Referee : AuditBase

    {

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Nationality { get; set; } = string.Empty;

    }
}
