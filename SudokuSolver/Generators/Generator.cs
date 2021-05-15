using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using SudokuSolver.Generators;

namespace SudokuSolver
{
    /// <summary>
    /// The generator is very lazy and it uses a web API to generate a puzzle
    /// </summary>
    public class WebApiGenerator : IGenerator
    {
        private HttpClient client;
        private const string endpoint = "https://sugoku.herokuapp.com/board";

        public WebApiGenerator()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri(endpoint)
            };
        }

        public async Task<int[,]> Generate(Difficulty difficulty = Difficulty.Easy)
        {
            var d = "";
            switch (difficulty)
            {
                case Difficulty.Easy:
                    d = "easy";
                    break;
                case Difficulty.Medium:
                    d = "medium";
                    break;
                case Difficulty.Hard:
                    d = "hard";
                    break;
            }

            var queryString = $"?difficulty={d}";
            var boardJson = await client.GetStringAsync(queryString);
            return GenerateFromJson(boardJson);
        }

        private int[,] GenerateFromJson(string json)
        {
            var board = new int[9,9];
            var document = JsonDocument.Parse(json);
            var enumerator = document.RootElement.GetProperty("board").EnumerateArray();
            var i = 0;
            foreach (var row in enumerator)
            {
                var j = 0;
                foreach (var column in row.EnumerateArray())
                {
                    board[i, j] = column.GetInt32();
                    j++;
                }
                i++;
            }
            return board;
        }
    }
}