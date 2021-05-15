using System.Collections.Generic;

namespace SudokuSolver.CLI
{
    public interface ICommand
    {
        string GetHelpString();
        void Execute();
        IDictionary<string, string> GetParameters();
    }
}