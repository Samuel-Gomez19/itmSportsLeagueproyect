using Microsoft.Extensions.Logging;
using SportsLeague.Domain.Entities;
using SportsLeague.Domain.Helpers;
using SportsLeague.Domain.Interfaces.Repositories;
using SportsLeague.Domain.Interfaces.Services;

namespace SportsLeague.Domain.Services
{
    public class MatchLineupService : IMatchLineupService//hacemos la herencia del IMatchLineupService
    {
        private readonly IMatchLineupRepository _MatchLineupRepository;//inyectamos las dependencias
        private readonly MatchValidationHelper _ValidationHelper;
        private readonly ILogger<MatchLineupService> _logger;
        private readonly IPlayerRepository _playerRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly IMatchRepository _matchRepository;




        public MatchLineupService(//inicializamos las dependencias 
            IMatchLineupRepository matchLineupRepository,
            MatchValidationHelper validationHelper,
            ILogger<MatchLineupService> logger,
            IMatchRepository matchRepository,
            IPlayerRepository playerRepository,
            ITeamRepository teamRepository)


        {
            _MatchLineupRepository = matchLineupRepository;
            _ValidationHelper = validationHelper;
            _logger = logger;
            _matchRepository = matchRepository;
            _playerRepository = playerRepository;
            _teamRepository = teamRepository;

        }

        public async Task<MatchLineup> AddPlayerToLineupAsync(int matchId, MatchLineup lineup)//Buscamos agregar un jugador a una alineacion
        {
            var Match = await _ValidationHelper.ValidateMatchForLineupAsync(matchId);//verificamos que exista el equipo y que el mismo debe de estar en scheduled con el helper nuevo(V1,V6)

            var player = await _ValidationHelper.ValidatePlayerInMatchAsync(lineup.PlayerId, Match);//verificamos que exista el jugador y que este en algun equipo gracias al helper(V2,V3)

            var existplayer = await _MatchLineupRepository.ExistsByMatchAndPlayer(matchId, lineup.PlayerId);//buscamos la existencia del jugadomediante el metodo propio(V4)
            if (existplayer)
                throw new InvalidOperationException("el jugador ya esta registrado en la aplicacion");

            if (lineup.IsStarter) //declaramos la variable con su propieda
            {
                var teamlineup = await _MatchLineupRepository.GetByMatchAndTeamAsync(matchId, player.TeamId);//buscamos tanto el partido como el equipo de la alineacion(v5)
                var StartEleven = teamlineup.Count(l => l.IsStarter);//usando el linq, tomamos el metodo COUNT y contamos la cantidad de playerid
                if (StartEleven >= 11)//si supera los 11 players, suelta el error 
                    throw new InvalidOperationException("el equipo ya tiene a su once inicialista");
            }

            lineup.MatchId = matchId;//hacemos la sociedad

            _logger.LogInformation($"Registrando Informacion: match {matchId},Player{lineup.PlayerId},IsStarter{lineup.IsStarter}", matchId, lineup.PlayerId, lineup.IsStarter);
            return await _MatchLineupRepository.CreateAsync(lineup);//de pasar todo, deja crear eljugador 

        }

        public async Task DeleteLineupAsync(int matchId, int lineupId)
        {
            var exist = await _MatchLineupRepository.ExistsAsync(lineupId);//verificamos que exista
            if (!exist)// si no existe, muestra error
                throw new KeyNotFoundException($"No se encontro la alineacion con la id: {lineupId}");
            var LineupMatch = await _MatchLineupRepository.GetByMatchAsync(matchId);//creamos la variable para ver la alineacion del partido
            var OnMatch = LineupMatch.Any(l => l.Id == lineupId);//con el linq any, buscamos asi sea una alineacion que concuerde con ese partido
            if (!OnMatch)//de no ser asi, muestra error
                throw new KeyNotFoundException($"La alineacion con la id {lineupId} no pertenece al partido {matchId}");
            
            _logger.LogInformation($"Eliminando la alineacion {lineupId} del partido {matchId}", lineupId, matchId);

            await _MatchLineupRepository.DeleteAsync(lineupId);//si pasa el flujo deja crear
        }

        public async Task<IEnumerable<MatchLineup>> GetByMatchAndTeamAsync(int matchId, int teamId)//ver tanto por equipo como por partido
        {
            var existmatch = await _matchRepository.GetByIdAsync(matchId);
            if (existmatch == null)
                throw new KeyNotFoundException($"No existe el partido con la id {matchId}");
            var existteam = await _teamRepository.GetByIdAsync(teamId);
            if (existteam == null)
                throw new KeyNotFoundException("No existe el equipo con la id {teamId}");

            return await _MatchLineupRepository.GetByMatchAndTeamAsync(matchId, teamId);


        }

        public async Task<IEnumerable<MatchLineup>> GetByMatchAsync(int matchId)//buscar alineacion de un partido en especifico
        {
            var exist = await _matchRepository.GetByIdAsync(matchId);//hacemos las busqueda desde match porque nos interesa es saber si existe el partido desde match
            if (exist == null)
                throw new KeyNotFoundException("No se encontro el partido con la id {matchId}");

            return await _MatchLineupRepository.GetByMatchAsync(matchId);
        }


    }
}









