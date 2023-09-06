using System;
using Day6Tasks.Tasks;

namespace Day6Tasks
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            // int[,] array = Day6Class.FillRandom(3);
            // Day6Class.ShowMatrix(array);
            // Console.WriteLine("**************");
            // Day6Class.SortMatrix(array);
            
            Day6Class.ShowMatrix(Day6Class.VariantMatrix(7));
            
        }
    }
}