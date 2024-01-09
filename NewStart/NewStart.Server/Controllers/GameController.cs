using Microsoft.AspNetCore.Mvc;
using NewStart.Server;

namespace OnePoint.Server.Controllers
{
    [ApiController]
    [Route("api/games")]
    public class GameController : ControllerBase
    {
        public static readonly IEnumerable<Games> Items = new[]
        {
            new Games { Name = "Mario", Description = "Un plombier qui saute haut", Category = "Platformer"},
            new Games { Name = "Sonic", Description = "Un herisson qui cour vite", Category = "Platformer"},
            new Games { Name = "Pokemon", Description = "Un enfant braconier", Category = "RPG"},
            new Games { Name = "Zelda", Description = "Un chevalier qui joue de la flutte", Category = "RPG"},
            new Games { Name = "CallOfDuty", Description = "C'est la guerre", Category = "FPS"},
            new Games { Name = "Battlefield", Description = "C'est la guerre mais moin fun a jouer", Category = "FPS"}
        };

        [HttpGet]
        public IActionResult GetGames()
        {
            return Ok(Items);
        }
    }
}
