namespace NewStart.Server.Models
{
    public class GameModel
    {
        public int GameId { get; set; }
        public string? GameName { get; set; }

        public string? GameDescription { get; set; }

        public List<string>? GameCategory { get; set;}
    }
}

