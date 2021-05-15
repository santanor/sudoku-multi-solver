using System;
using System.Collections.Generic;
using System.Text;
using SudokuSolver.Solvers;
using SudokuSolver.Utils;

namespace SudokuSolver
{
    public class Sudoku
    {
        public int[,] Board { get; set; }
        public ISolver solver { get; private set; }

        public Sudoku()
        {
            Board = new int[9,9];
        }

        public void SetSolver(ISolver solver)
        {
            this.solver = solver;
            this.solver.SetSudoku(this);
        }

        public void Solve()
        {
            solver.Solve();
        }
        
        public bool IsPossible(int x, int y, int n)
        {
            var isPossible = true;
            isPossible &= IsArrayValid(Board.GetColumn(y), n);
            isPossible &= IsArrayValid(Board.GetRow(x), n);
            isPossible &= IsBlockValid(Board.GetBlock(x - x%3, y - y%3, 3, 3), n);

            return isPossible;
        }

        private bool IsArrayValid(int[] row, int n)
        {
            for (var i = 0; i < row.Length; i++)
            {
                if (row[i] != 0 && row[i] == n)
                {
                    return false;
                }
            }
            return true;
        }

        private bool IsBlockValid(int[,] block, int n)
        {
            for (var i = 0; i < block.GetLength(0); i++)
            {
                for (int j = 0; j < block.GetLength(1); j++)
                {
                    if (block[i, j] != 0 && block[i,j] == n)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public void PrettyPrint()
        {
            //Local function to print either a point or the value
            string printCell(int i, int j)
            {
                if (Board[i, j] == 0)
                {
                    return "·";
                }

                return Board[i, j].ToString();
            }
            
            for (var i = 0; i < Board.GetLength(0); i++)
            {
                if (i % 3 == 0)
                {
                    Chalk.BlueLine("\t\t+---------+---------+---------+");
                }
                
                Chalk.Blue("\t\t|");
                for (var j = 0; j < Board.GetLength(1); j+=3)
                {
                    Chalk.White($" {printCell(i, j)} ");
                    Chalk.White($" {printCell(i, j+1)} ");
                    Chalk.White($" {printCell(i, j+2)} ");
                    Chalk.Blue("|");
                }
                Chalk.WhiteLine("");

                
            }
            Chalk.BlueLine("\t\t+---------+---------+---------+");
        }
    }
}