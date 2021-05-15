using System.Collections.Generic;

namespace SudokuSolver.CLI.Commands
{
    public class ExitCommand : ICommand
    {
        public string GetHelpString()
        {
            return $"Quits the application";
        }

        public void Execute()
        {
            CLI.Stop();
        }

        public IDictionary<string, string> GetParameters()
        {
            return null;
        }
    }
}