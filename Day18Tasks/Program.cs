using System;
using Day18Tasks.Tasks;
using static System.Console;

namespace Day18Tasks
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            WriteLine("Enter sizes: (int)");
            int[,] matrixInt = new int[int.Parse(ReadLine() ?? string.Empty),int.Parse(ReadLine() ?? string.Empty)];
            var r = new Random();
            var rows = matrixInt.GetLength(0);
            var cols = matrixInt.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                    matrixInt[i, j] = r.Next(1,100);
            }
            WriteLine("...");
            Day18Class.PrintMatrix(matrixInt);
            
            WriteLine("Enter sizes: (int)");
            double[,] matrixDouble = new double[(int)double.Parse(ReadLine() ?? string.Empty),(int)double.Parse(ReadLine() ?? string.Empty)];
            rows = matrixDouble.GetLength(0);
            cols = matrixDouble.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                    matrixDouble[i, j] = r.NextDouble();
            }
            WriteLine("...");
            Day18Class.PrintMatrix(matrixDouble);
            
        }
    }
}