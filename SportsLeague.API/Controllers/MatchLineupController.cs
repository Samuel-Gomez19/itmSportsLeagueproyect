using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SportsLeague.API.DTOs.Request;
using SportsLeague.API.DTOs.Response;
using SportsLeague.Domain.entities;
using SportsLeague.Domain.Entities;
using SportsLeague.Domain.Interfaces.Services;


namespace SportsLeague.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MatchLineupController : ControllerBase
    {
        private readonly IMatchLineupService _matchLineupService;
        private readonly IMapper _mapper;


        public MatchLineupController(
            IMatchLineupService matchLineupService,
            IMapper mapper)

        {
            _matchLineupService = matchLineupService;
            _mapper = mapper;

        }

        [HttpGet("{matchId}/lineup")]


        public async Task<ActionResult<IEnumerable<MatchLineupDTO>>> GetLineup(int matchId)
        {

            try

            {
                var lineup = await _matchLineupService.GetByMatchAsync(matchId);



                return Ok(_mapper.Map<IEnumerable<MatchLineupDTO>>(lineup));

            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });


            }


        }


        [HttpPost("{matchId}/lineup")]

        public async Task<ActionResult<MatchLineupDTO>> AddPlayerAsync(int matchId, CreateMatchLineupDTO dto)

        {
            try
            { var player = _mapper.Map<MatchLineup>(dto);
                var createdplayer = await _matchLineupService.AddPlayerToLineupAsync(matchId, player);


                var responsedto = _mapper.Map<MatchLineupDTO>(createdplayer);
                return CreatedAtAction(nameof(GetLineup), new { matchId }, responsedto);

            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });


            }
            catch (InvalidOperationException ex)
            {

                return Conflict(new { message = ex.Message });


            }


        }
        [HttpGet("{matchId}/lineup/team/{teamId}")]

        public async Task<ActionResult<IEnumerable<MatchLineupDTO>>> GetByMatchAndTeamAsync(int matchId, int teamId)
        {
            try
            {
                var lineup = await _matchLineupService.GetByMatchAndTeamAsync(matchId, teamId);

                return Ok(_mapper.Map<IEnumerable<MatchLineupDTO>>(lineup));



            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });



            }



        }


        [HttpDelete("{matchId}/lineup/{Id} ")]
         

         public async Task<ActionResult> DeleteLineupAsync(int matchId, int Id)
         {
            try
            {

                await _matchLineupService.DeleteLineupAsync(matchId, Id);
                return NoContent();



            }
            catch(KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });

            }


         }


}   }

