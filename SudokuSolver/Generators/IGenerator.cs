using System.Threading.Tasks;

namespace SudokuSolver.Generators
{
    /// <summary>
    /// Interface used to generate Sudoku boards
    /// </summary>
    public interface IGenerator
    {
        Task<int[,]> Generate(Difficulty difficulty = Difficulty.Easy);
    }
}