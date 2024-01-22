using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace NewStart.Server.Models
{
    public class GameModel
    {
        [Key]
        public int GameId { get; set; }
        public string? GameName { get; set; }

        public string? GameDescription { get; set; }

        [JsonIgnore]
        public ICollection<CategoryModel>? Categories { get; set;}
    }
}