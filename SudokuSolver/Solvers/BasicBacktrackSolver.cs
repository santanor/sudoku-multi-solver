using System.Diagnostics;

namespace SudokuSolver.Solvers
{
    public class BasicBacktrackSolver : ISolver
    {
        public event ISolver.SolverFinished OnSolverFinished;
        public event ISolver.SolverEvent OnStepTaken;

        private Sudoku sudoku;
        private Stopwatch sw;
        private const int N = 9;

        

        public void Solve()
        {
            sw = new Stopwatch();
            sw.Start();
            
            SolveBacktrack(sudoku, 0, 0);
            
            sw.Stop();
            OnSolverFinished?.Invoke(sw.Elapsed);
        }

        public void SetSudoku(Sudoku s)
        {
            sudoku = s;
        }

        private bool SolveBacktrack(Sudoku s, int i, int j)
        {
            if (i == N-1 && j == N) return true;

            if (j == N)
            {
                i++;
                j = 0;
            }

            if (s.Board[i, j] != 0)
            {
                return SolveBacktrack(s, i, j + 1);
            }
            

            for (var k = 1; k <= 9; k++)
            {
                if (s.IsPossible(i, j, k))
                {
                    s.Board[i, j] = k;
                    //OnStepTaken?.Invoke(i, j);
                    if (SolveBacktrack(s, i, j + 1))
                    {
                        return true;
                    }
                }
                s.Board[i, j] = 0;
            }

            return false;
        }
    }
}