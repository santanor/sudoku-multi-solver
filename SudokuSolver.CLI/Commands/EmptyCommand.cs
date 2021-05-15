using System.Collections.Generic;

namespace SudokuSolver.CLI.Commands
{
    public class EmptyCommand : ICommand
    {
        public string GetHelpString()
        {
            return "It does nothing";
        }

        public void Execute()
        {
            //nothing
        }

        public IDictionary<string, string> GetParameters()
        {
            return null;
        }
    }
}