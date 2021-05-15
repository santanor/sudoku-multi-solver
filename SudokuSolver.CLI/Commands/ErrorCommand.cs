using System.Collections.Generic;
using System.Linq;
using SudokuSolver.Utils;

namespace SudokuSolver.CLI.Commands
{
    /// <summary>
    /// This command represents an error, it's created when a command isn't recognised and it simply displays an error
    /// </summary>
    public class ErrorCommand : ICommand
    {
        private string attemptedCommand;
        
        public ErrorCommand(){}
        
        public ErrorCommand(string attemptedCommand)
        {
            this.attemptedCommand = attemptedCommand;
        }
        
        public string GetHelpString()
        {
            return string.Empty;
        }

        public void Execute()
        {
            Chalk.RedLine($"sudoku multi solver: command not found: {attemptedCommand}");
        }

        public IDictionary<string, string> GetParameters()
        {
            return null;
        }
    }
}