using Microsoft.Extensions.Logging;
using SportsLeague.Domain.entities;
using SportsLeague.Domain.enums;
using SportsLeague.Domain.interfaces.repositories;
using SportsLeague.Domain.interfaces.services;
using SportsLeague.Domain.Interfaces.Repositories;
using SportsLeague.Domain.Interfaces.Services;

namespace SportsLeague.Domain.Services
{
    public class SponsorService: ISponsorService// Creame la clase y traemos la herencia del iservice 
    {
        private readonly ISponsorRepository _sponsorRepository;//genera el enlace con los crud propios del repositorio de service 
        private readonly ITournamentSponsorRepository _tournamentSponsorRepository;// hace el enlace con los crud de Tournament sponsor 
        private readonly ILogger<Sponsor> _logger;
        private readonly ITournamentRepository _tournamentRepository;


        //inyeccion de dependencias necesarias 
        public SponsorService(ISponsorRepository SponsorRepository, ITournamentRepository TournamentRepository, ITournamentSponsorRepository tournamentSponsorRepository, ILogger<Sponsor> logger)
        {

            _sponsorRepository = SponsorRepository;
            _tournamentRepository = TournamentRepository;
            _tournamentSponsorRepository = tournamentSponsorRepository;
            _logger = logger;


        }
        public async Task<IEnumerable<Sponsor>> GetAllAsync()//Obtiene todos los Sponsors registrados en el sistema 
        {
            _logger.LogInformation(" Retrieving all Sponsors");
            return await _sponsorRepository.GetAllAsync();


        }

        public async Task<Sponsor?> GetByIdAsync(int id)//Busca un sponsor por su id
        {
            _logger.LogInformation(" Retrieving all Sponsors with ID : {SponsorId}", id);
            var Sponsor = await _sponsorRepository.GetByIdAsync(id);
            if (Sponsor == null)   //si el sponsor no registrado, devuelve un mensaje informando que no esta creado 

                _logger.LogWarning("Sponsor with ID{SponsorId} not found", id);
            return Sponsor;   //de lo contrario, devuelve normal


        }

        public async Task<Sponsor> CreateAsync(Sponsor Entity)//crea un sponsor validando que no haya otro creado igual
        {
            var existname = await _sponsorRepository.ExistByNameAsync(Entity.SponsorName);
            if (existname != null)//si el nombre existente no es nulo
                throw new InvalidOperationException($"Ya hay un equipo con este nombre {Entity.SponsorName}");//lanza el mensaje de alerta
            var sponsor = new Sponsor
            {
                SponsorName = Entity.SponsorName,// de lo contrario, deja crearlo 
                ContactEmail = Entity.ContactEmail,
                Phone = Entity.Phone,
                WebSiteURl = Entity.WebSiteURl




            };
            await _sponsorRepository.CreateAsync(sponsor);
            _logger.LogInformation("Sponsor {SponsorName} created successfully", sponsor.SponsorName);//da mensaje de confirmacion
            return sponsor;

        }














        public async Task UpdateCategoryAsync(int id, SponsorCategory newCategory)//actualiza la categoria del sponsor 
        {
            var Sponsor = await _sponsorRepository.GetByIdAsync(id);
            if (Sponsor == null)// si el sponsor no esta registrado 
                throw new KeyNotFoundException($"No se encontro el Sponsor con la ID {id}");// da mensaje de sponsor no encontrado 




            Sponsor.Category = newCategory;
            await _sponsorRepository.UpdateAsync(Sponsor);
            _logger.LogInformation("Updating Sponsor {SponsorId} status to {newCategory}", id, newCategory);// de lo contrario, deja actualizar su nueva categoria




        }
        public async Task UpdateAsync(int id, Sponsor entity)//buscamos actualizar 
        {
            var Sponsor = await _sponsorRepository.GetByIdAsync(id);//primero buscamos si existe ya un sponsor con la misma id
            if (Sponsor == null)
                throw new KeyNotFoundException($"No se encontro el Sponsor con la ID {id}");//avisamos de que la id buscada para actualizar no existe 

            var existingnname = await _sponsorRepository.ExistByNameAsync(entity.SponsorName);// Ahora buscamos si hay un sponsor con el mismo nombre
            if (existingnname != null && existingnname.Id != id)
                throw new InvalidOperationException($"Ya hay un Sponsor con este nombre:{entity.SponsorName}");//Avisamos si lo hay
            Sponsor.SponsorName = entity.SponsorName;//en caso de si haya un sponsor, permitimos actualizar 
            Sponsor.ContactEmail = entity.ContactEmail;
            Sponsor.Phone = entity.Phone;
            Sponsor.WebSiteURl = entity.WebSiteURl;

            await _sponsorRepository.UpdateAsync(Sponsor);//retornamos la nueva informacion
            _logger.LogInformation("Sponsor{SponsorId} update sucesfully", id);// mensaje de confirmacion











        }
        public async Task DeleteAsync(int id)//implementamos el metodo de eliminacion
        {
            var exist = await _sponsorRepository.ExistsAsync(id);
            if (!exist)//validamos si no existe 
                throw new KeyNotFoundException($"No se encontro sponsor con esa ID{id}");


            _logger.LogInformation($"deleting sponsor with the ID: {id}");
            await _sponsorRepository.DeleteAsync(id);//en caso que exista, retornamos 
            





        }
        public async Task AddToTournamentAsync(int tournamentId, int sponsorId)//implementamos metodo para asociar sponsor a tournament
        {

            var sponsor = await _sponsorRepository.GetByIdAsync(sponsorId);//valida que exista el sponsor
            if (sponsor == null)
                throw new KeyNotFoundException($"No se encontro el sponsor con la ID {sponsorId}");//en caso que no da alerta 
            var tournament = await _tournamentRepository.GetByIdAsync(tournamentId);//valida que exista el torneo
            if (tournament == null)
                throw new KeyNotFoundException($"No se encontro el torneo con la ID {tournamentId}");//en caso que no da alerta 
            var existigr = await _tournamentSponsorRepository.GetByTournamentAndSponsor(tournamentId, sponsorId);
            if (existigr !=null)
                throw new InvalidOperationException($"el Sponsor {sponsorId} ya esta asociado a un torneo{tournamentId}");//si existe, advierte 
            await _sponsorRepository.AddToTournamentAsync(tournamentId, sponsorId);//devuelve 

            

            _logger.LogInformation("Sponsor {SponsorId} added to Tournament {TournamentId}", sponsorId, tournamentId);//te entrega este mensaje





        }
        

        
        
    }





}
        


       
   

