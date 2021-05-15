using System;

namespace SudokuSolver.Solvers
{
    public interface ISolver
    {
        delegate void SolverEvent(int i, int j);
        delegate void SolverFinished(TimeSpan timeTaken);

        event SolverFinished OnSolverFinished;
        event SolverEvent OnStepTaken;
        void Solve();
        void SetSudoku(Sudoku s);
    }
}