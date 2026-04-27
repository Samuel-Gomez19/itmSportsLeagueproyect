using SportsLeague.Domain.enums;

namespace SportsLeague.API.DTOs.Request
{
    public class UpdateMatchStatusDTO
    {
        public MatchStatus Status { get; set; }
    }

}
