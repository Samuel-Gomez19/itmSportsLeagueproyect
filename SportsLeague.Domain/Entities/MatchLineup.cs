using SportsLeague.Domain.entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportsLeague.Domain.Entities
{
    public class MatchLineup:AuditBase
    {
        public int MatchId { get; set; }//FK a match
        public int PlayerId { get; set; }// Fk a Player
        public bool IsStarter { get; set; }
        public string PlayerPosition { get; set; } = string.Empty;

        // navigation propierties

        public Match Match { get; set; } = null!;
        public Player Player { get; set; } = null!;

    }
}
