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

        /*[HttpGet]
        public async Task<IActionResult> GetGames()
        {

            var games = await _context.GameModel.Include("Categories").ToListAsync();

            return Ok(games);

        }*/

        [HttpGet]
        public async Task<IActionResult> GetGames()
        {
            var games = await _context.GameModel
                .Include(g => g.Categories)
                .ToListAsync();

            var gameViewModels = games.Select(g => new GameViewModel
            {
                GameId = g.GameId,
                GameName = g.GameName,
                GameDescription = g.GameDescription,
                CategoryNames = g.Categories.Select(c => c.CategoryName).ToList()
            }).ToList();

            return Ok(gameViewModels);
        }
    }
}
