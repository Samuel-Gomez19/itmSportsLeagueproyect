using System;
using System.Collections.Generic;
using System.Text;

namespace SportsLeague.Domain.entities
{
    public class TournamentSponsor: AuditBase//creamos la tabla intermedia

    {
        public int SponsorId { get; set;}//foreign key
        public int TournamentId { get; set;}//foreign key
        public Decimal ContractAmount { get; set; }
        public DateTime JoinedAt { get; set; } = DateTime.UtcNow;


        // añadimos las propiedades de navegacion y ponemos las restricciones de nulidad
        public Sponsor Sponsor { get; set; } = null!;
        public Tournament tournament { get; set; } = null!;
        
    }
}
