namespace NewStart.Server.Models
{
    public class GameViewModel
    {
        public int GameId { get; set; }
        public string? GameName { get; set; }
        public string? GameDescription { get; set; }
        public List<string>? CategoryNames { get; set; }
    }
}
