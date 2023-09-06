using System;
using System.Collections.Generic;

namespace Day6Tasks.Tasks
{
    public class Day6ClassPart2
    {
        private static void ShowArray(int[][] userArray)
        {
            foreach (var t in userArray)
            {
                foreach (var t1 in t)
                    Console.Write(t1 + " ");

                Console.WriteLine();
            }
        }
        
        //1
        public static void SortStaircaseMatrix(int[][] matrix)
        {
            int rows = matrix.Length;

            for (int i = 0; i < rows; i++)
            {
                // Сортировка четных строк по возрастанию
                if (i % 2 == 0)
                {
                    Array.Sort(matrix[i]);
                }
                // Сортировка нечетных строк по убыванию
                else
                {
                    Array.Sort(matrix[i], (x, y) => y.CompareTo(x));
                }
            }
            ShowArray(matrix);
        }
        
        //2
        public static void CountMaxElements(int[][] matrix)
        {
            int rows = matrix.Length;

            for (int i = 0; i < rows; i++)
            {
                int[] row = matrix[i];
                int max = row[0];
                int count = 0;

                for (int j = 1; j < row.Length; j++)
                {
                    if (row[j] > max)
                    {
                        max = row[j];
                        count = 0;
                    }

                    if (row[j] == max)
                    {
                        count++;
                    }
                }

                Console.WriteLine($"Максимальный элемент в строке {i + 1}: {max}. Количество повторений: {count}.");
            }
        }
        
        //3
        public static int FindRowWithMaxAverage(int[][] matrix)
        {
            int rows = matrix.Length;
            int maxRowIndex = 0;
            double maxAverage = double.MinValue;

            for (int i = 0; i < rows; i++)
            {
                int[] row = matrix[i];
                double rowSum = 0;

                foreach (var t in row)
                    rowSum += t;
                

                double rowAverage = rowSum / row.Length;

                if (rowAverage > maxAverage)
                {
                    maxAverage = rowAverage;
                    maxRowIndex = i;
                }
            }

            return maxRowIndex;
        }
        
        //4
        public static int CountRowsWithZeros(int[][] matrix)
        {
            int rows = matrix.Length;
            int count = 0;

            for (int i = 0; i < rows; i++)
            {
                int[] row = matrix[i];

                if (Array.IndexOf(row, 0) != -1)
                {
                    count++;
                }
            }

            return count;
        }
        
        //5
        private static int CountDistinctElements(int[] arr)
        {
            var distinctElements = new HashSet<int>(arr);
            return distinctElements.Count;
        }

        public static void CountDistinctElements(int[][] matrix)
        {
            int rows = matrix.Length;

            for (int i = 0; i < rows; i++)
            {
                int[] row = matrix[i];
                int count = CountDistinctElements(row);
                Console.WriteLine($"Количество различных элементов в строке {i + 1}: {count}.");
            }
        }
    }
}