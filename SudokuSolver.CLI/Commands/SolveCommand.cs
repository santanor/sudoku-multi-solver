using System.Collections.Generic;

namespace SudokuSolver.CLI.Commands
{
    public class SolveCommand : ICommand
    {
        public string GetHelpString()
        {
            return "Solves the damn thing";
        }

        public void Execute()
        {
            CLI.Sudoku.Solve();
        }

        public IDictionary<string, string> GetParameters()
        {
            return null;
        }
    }
}