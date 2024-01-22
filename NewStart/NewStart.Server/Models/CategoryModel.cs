using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace NewStart.Server.Models
{
    public class CategoryModel
    {
        [Key]
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }

        [JsonIgnore]
        public ICollection<GameModel>? Games { get; set; }
    }
}
