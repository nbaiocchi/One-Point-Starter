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
        private const string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=my_game_db;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

        [HttpGet]
        public IEnumerable<GameModel> GetGames()
        {
            List<GameModel> games = [];
            List<string> categories = [];


            using (SqlConnection connection = new(ConnectionString))
            {
                connection.Open();

                /*string queryC = @"
                    SELECT Games.GameId, Games.GameName, Games.GameDescription, Category.CategoryName
                    FROM GameCategory
                    INNER JOIN Games ON GameCategory.GameId = Games.GameId
                    INNER JOIN Category ON GameCategory.CategoryId = Category.CategoryId
                ";*/

                

                string queryC = @"
                    SELECT Games.GameId, Games.GameName, Games.GameDescription, STRING_AGG(Category.CategoryName, ', ') AS CategoryList
                    FROM GameCategory
                    INNER JOIN Games ON GameCategory.GameId = Games.GameId
                    INNER JOIN Category ON GameCategory.CategoryId = Category.CategoryId
                    GROUP BY Games.GameId, Games.GameName, Games.GameDescription
                ";

                using SqlCommand command = new(queryC, connection);
                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    GameModel game = new()
                    {
                        GameId = Convert.ToInt32(reader["GameId"]),
                        GameName = Convert.ToString(reader["GameName"]),
                        GameDescription = Convert.ToString(reader["GameDescription"]),
                        GameCategory = [.. Convert.ToString(reader["CategoryList"] ?? string.Empty).Split(", ")]
                    };

                    games.Add(game);
                }
            }

            return games;

        }
    }
}
