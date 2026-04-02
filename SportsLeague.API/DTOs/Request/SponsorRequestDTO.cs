using SportsLeague.Domain.enums;

namespace SportsLeague.API.DTOs.Request
{
    public class SponsorRequestDTO
    {
        
        public string SponsorName { get; set; } = String.Empty;
        public string ContactEmail { get; set; } = String.Empty;
        public string? Phone { get; set; }
        public string? WebSiteURl { get; set; }

        public SponsorCategory Category { get; set; }

    }
}
