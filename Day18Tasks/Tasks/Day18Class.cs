using static System.Console;

namespace Day18Tasks.Tasks
{
    public static class Day18Class
    {
        public static void PrintMatrix<T>(T[,] matrix)
        {
            var rows = matrix.GetLength(0);
            var cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                    Write(matrix[i, j] + " ");
                WriteLine();
            }
        }
    }
}