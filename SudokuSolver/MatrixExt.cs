namespace SudokuSolver
{
 
    /// <summary>
    /// Utility extension class to return rows, columns an blocks from a Sudoku board.
    ///
    /// No Need to make this generic, only Sudokus here
    /// </summary>
    public static class MatrixExt
    {
        public static int[] GetRow(this int[,] matrix, int rowIndex)
        {
            var length = matrix.GetLength(0);
            var result = new int[length];

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                result[i] = matrix[rowIndex, i];
            }

            return result;
        }

        public static int[] GetColumn(this int[,] matrix, int colIndex)
        {
            var length = matrix.GetLength(1);
            var result = new int[length];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                result[i] = matrix[i, colIndex];
            }

            return result;
        }

        public static int[,] GetBlock(this int[,] matrix, int startXIndex, int startYIndex, int sizeX, int sizeY)
        {
            var result = new int[sizeX, sizeY];

            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    result[i, j] = matrix[i + startXIndex, j + startYIndex];
                }
            }
            return result;
        }
        
    }
}