using System.Collections.Generic;
using System.Net.Http;
using BenchmarkDotNet.Toolchains.CoreRt;
using SudokuSolver.Generators;
using SudokuSolver.Utils;

namespace SudokuSolver.CLI.Commands
{
    public class GenerateCommand : ICommand
    {
        private IGenerator generator;
        private const string uri = "https://sugoku.herokuapp.com/board";

        public GenerateCommand()
        {
            generator = new WebApiGenerator();
        }
        
        public string GetHelpString()
        {
            return string.Empty;
        }

        public void Execute()
        {
            Chalk.YellowLine("Generating...");
            var board = generator.Generate().Result;
            Chalk.YellowLine("Done");
            CLI.Sudoku.Board = board;
            Chalk.YellowLine("Press enter again to refresh the board (Yeah, I know....)");
        }

        public IDictionary<string, string> GetParameters()
        {
            return null;
        }
    }
}