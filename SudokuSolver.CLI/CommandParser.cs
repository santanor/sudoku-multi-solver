using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SudokuSolver.CLI.Commands;

namespace SudokuSolver.CLI
{
    public class CommandParser
    {
        private IDictionary<string, Type> commands;

        public CommandParser()
        {
            HydrateCommands();
        }

        private void HydrateCommands()
        {
            var interfaces = Assembly.GetExecutingAssembly().GetTypes()
                .Where(x => x.GetInterfaces().Contains(typeof(ICommand)));

            commands = new Dictionary<string, Type>();
            
            foreach (var type in interfaces)
            {
                commands.Add(type.Name.Replace("Command", string.Empty).ToLower(), type);
            }
        }

        public ICommand ParseCommand(string commandLine)
        {
            if (string.IsNullOrWhiteSpace(commandLine))
            {
                return new EmptyCommand();
            }
            
            var commandChunks = commandLine.Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();

            if (commands.TryGetValue(commandChunks.FirstOrDefault(), out var commandType))
            {
                return (ICommand)Activator.CreateInstance(commandType);
            }

            return new ErrorCommand(commandChunks.FirstOrDefault());
        }
    }
}