using SportsLeague.Domain.enums;

namespace SportsLeague.Domain.entities
{
    public class Tournament : AuditBase

    {

        public string Name { get; set; } = string.Empty;

        public string Season { get; set; } = string.Empty;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public TournamentStatus Status { get; set; } = TournamentStatus.Pending;


        // Navigation Properties

        public ICollection<TournamentTeam> TournamentTeams { get; set; } = new List<TournamentTeam>();
<<<<<<< HEAD
        public ICollection<TournamentSponsor> TournamentSponsor { get; set; } = new List<TournamentSponsor>();
=======
>>>>>>> parent of 61dfe6d (-add enum called "SponsorCategory")

    }
}
