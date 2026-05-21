namespace SportsLeague.API.DTOs.Request
{
    public class CreateMatchLineupDTO//creamos el que le pedira al usuario los datos de su jugador 
    {
        public int PlayerId { get; set; }
        public bool IsStarter { get; set; }
        public string PlayerPosition { get; set; } = string.Empty;
    }
}
