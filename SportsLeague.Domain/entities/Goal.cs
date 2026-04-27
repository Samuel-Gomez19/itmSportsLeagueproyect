using SportsLeague.Domain.enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportsLeague.Domain.entities
{


    public class Goal : AuditBase

    {

        public int MatchId { get; set; }

        public int PlayerId { get; set; }

        public int Minute { get; set; }

        public GoalType Type { get; set; }



        // Navigation Properties 

        public Match Match { get; set; } = null!;

        public Player Player { get; set; } = null!;

    }
}
