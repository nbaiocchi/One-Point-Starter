using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewStart.Server.Data;
using NewStart.Server.Models;

namespace NewStart.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        public readonly DataContext _context;

        public TodoController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
            public async Task<IActionResult> GetTodos()
            {

                var todos = await _context.Todo.ToListAsync();

            return Ok(todos);

        }
    }
}
