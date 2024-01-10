using Microsoft.AspNetCore.Mvc;
using NewStart.Server;
using NewStart.Server.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace OnePoint.Server.Controllers
{
    [ApiController]
    [Route("api/games")]
    public class GameController : ControllerBase
    {
        /*public static readonly IEnumerable<Games> Items = new[]
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
        }*/

        private const string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=my_game_db;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

        [HttpGet]
        public IEnumerable<GameModel> GetGames()
        {
            List<GameModel> games = [];

            using (SqlConnection connection = new(ConnectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Games";

                using SqlCommand command = new(query, connection);
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    GameModel game = new()
                    {
                        GameId = Convert.ToInt32(reader["GameId"]),
                        GameName = Convert.ToString(reader["GameName"]),
                        GameDescription = Convert.ToString(reader["GameDescription"]),
                        GameCategory = Convert.ToString(reader["GameCategory"])
                    };

                    games.Add(game);
                }
            }

            return games;
        }
    }
}
