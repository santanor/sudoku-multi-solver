using System.Collections.Generic;
using SudokuSolver.Utils;

namespace SudokuSolver.CLI.Commands
{
    public class EchoCommand : ICommand
    {
        private string toEcho;

        public EchoCommand()
        {
        }

        public EchoCommand(string toEcho)
        {
            this.toEcho = toEcho;
        }
        
        public string GetHelpString()
        {
            return "Prints whatever you pass in as parameter";
        }

        public void Execute()
        {
            Chalk.BlueLine(toEcho);
        }

        public IDictionary<string, string> GetParameters()
        {
            return null;
        }
    }
}