using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewStart.Server.Data;
using NewStart.Server.Models;

namespace NewStart.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        public readonly DataContext _context;

        public GameController(DataContext context)
        {
            _context = context;
        }

        private const string NoGamesFoundMessage = "No games has been found in the DB";

        [HttpGet]
        public async Task<IActionResult> GetGames()
        {
            try
            {
                var games = await _context.GameModel
                    .Include(g => g.Categories)
                    .ToListAsync();

                if (games == null || !games.Any())
                {
                    return NotFound(NoGamesFoundMessage);
                }

                var gameViewModels = games.Select(g => new GameViewModel
                {

                    GameId = g.GameId,
                    GameName = g.GameName,
                    GameDescription = g.GameDescription,
                    CategoryNames = g.Categories?.Select(c => c.CategoryName).ToList()
                }).ToList();

                return Ok(gameViewModels);
            }

            catch (Exception error)
            {
                Console.Error.WriteLine($"An error pop up: {error.Message}");

                return StatusCode(StatusCodes.Status500InternalServerError, "An error pop up while processing your request.");
            }
        }
    }
}
