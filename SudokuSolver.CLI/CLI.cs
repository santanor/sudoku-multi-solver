using System;
using System.Threading;
using SudokuSolver.CLI.Commands;
using SudokuSolver.Solvers;
using SudokuSolver.Utils;

namespace SudokuSolver.CLI
{
    public static class CLI
    {
        private static bool isRunning = true;
        public static Sudoku Sudoku;
        private static  CommandParser parser;

        static CLI()
        {
            Sudoku = new Sudoku();
            parser = new CommandParser();
        }
        
        public static void Run()
        {
            try
            {
                Chalk.BlueLine("Welcome to the Sudoku Solver CLI. Type 'help' or '?' to display available commands.");
                //Todo remove this
                SetSolver(new BasicBacktrackSolver());
                LifeCycle();
            }
            catch (Exception e)
            {
                Chalk.RedLine(e.Message);
            }
        }

        public static void SetSolver(ISolver solver)
        {
            Sudoku.SetSolver(solver);
            Sudoku.solver.OnStepTaken += SolverOnOnStepTaken;
            Sudoku.solver.OnSolverFinished += SolverOnOnSolverFinished;
        }

        private static void SolverOnOnSolverFinished(TimeSpan timetaken)
        {
            PrintBasicCLI();
            Chalk.GreenLine($"Sudoku solved in {timetaken}");
        }

        private static void SolverOnOnStepTaken(int i, int j)
        {
            Thread.Sleep(50);
            PrintBasicCLI();
            Chalk.GreenLine("Solving...");
        }

        public static void Stop()
        {
            isRunning = false;
        }

        private static void LifeCycle()
        {
            ICommand previousCommand = null;
            while (isRunning)
            {
                PrintBasicCLI();
                if (previousCommand != null)
                {
                    previousCommand.Execute();
                    previousCommand = null;
                }
                
                previousCommand = ReadCommand();
            }
        }

        private static void PrintBasicCLI()
        {
            Console.Clear();
            Chalk.BlueLine("\t\t\tSudoku Multi Solver");
            Chalk.White("\n");
            Sudoku.PrettyPrint();
        }

        private static ICommand ReadCommand()
        {
            Chalk.White(">>");
            var line = Console.ReadLine();
            var command = parser.ParseCommand(line);
            return command;
        }
    }
}