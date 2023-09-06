using System;
using System.IO;

namespace Day6Tasks.Tasks
{
    public static class Day6Class
    {
        public static int[,] FillRandom(int n)
        {
            int[,] matrix = new int[n, n];
            Random r = new Random();

            for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                matrix[i, j] = r.Next(1, 228);

            return matrix;
        }

        public static int[,] FillHand(int n)
        {
            int[,] matrix = new int[n, n];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    matrix[i, j] = int.Parse(Console.ReadLine() ?? string.Empty);

            return matrix;
        }

        public static void ShowMatrix(int[,] userArray)
        {
            int rows = userArray.GetLength(0);
            int cols = userArray.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                    Console.Write($"{userArray[i, j],5}|");

                Console.WriteLine();
            }
        }

        public static void FileMatrix(int[,] userArray)
        {
            int rows = userArray.GetLength(0);
            int cols = userArray.GetLength(1);

            StreamWriter userArrayString = new StreamWriter("userArray.txt");

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                    userArrayString.Write($"{userArray[i, j].ToString()}");
                userArrayString.WriteLine();
            }
        }

        public static void ShowMainDiag(int[,] userArray)
        {
            int rows = userArray.GetLength(0);

            for (int i = 0; i < rows; i++)
                Console.WriteLine(userArray[i, i]);
        }

        public static bool SimetricMatrix(int[,] userArray)
        {
            for (int i = 0; i < userArray.GetLength(0); i++)
            {
                for (int j = 0; j < userArray.GetLength(1); j++)
                {
                    if (userArray[i, j] != userArray[j, i])
                        return false;
                }
            }
            return true;
        }

        public static int[,] VariantMatrix(int n)
        {
            int[,] matrix = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == 0)
                    {
                        matrix[i, j] = (j % 2 == 0) ? 1 : 5;
                    }
                    else if (i == 4)
                    {
                        matrix[i, j] = (j % 2 == 0) ? 5 : 1;
                    }
                    else if (i == 3)
                    {
                        // ReSharper disable once ConditionIsAlwaysTrueOrFalse
                        if (i == 3 && j == 2)
                        {
                            matrix[i, j] = 3;
                        }
                        else
                        {
                            matrix[i, j] = (j % 2 == 0) ? 4 : 2;
                        }
                    }
                    else if (i == 1)
                    {
                        matrix[i, j] = (j % 2 == 0) ? 2 : 4;
                    }
                    else
                    {
                        matrix[i, j] = 3;
                    }
                }
            }

            return matrix;
        }

        public static int SumElements(int[,] userArray)
        {
            int sum = 0;
            for (int i = 0; i < userArray.GetLength(0); i++)
            {
                for (int j = 0; j < userArray.GetLength(1); j++)
                {
                    if (i % 2 == 0)
                        sum += userArray[i, j];
                }
            }

            return sum;
        }

        public static void SumRows(int[,] userArray)
        {
            int sum = 0;
            for (int i = 0; i < userArray.GetLength(0); i++)
            {
                for (int j = 0; j < userArray.GetLength(1); j++)
                {
                    sum += userArray[i, j];
                }

                Console.WriteLine(sum);
                sum = 0;
            }
        }

        public static void SortMatrix(int[,] matrix)
        {
            int[] maxElements = new int[matrix.GetLength(0)];

// Заполним массив максимальными элементами каждой строки
            for (int i = 0; i < matrix.GetLength(0); i++) {
                int max = matrix[i, 0];
                for (int j = 1; j < matrix.GetLength(1); j++) {
                    if (matrix[i, j] > max) {
                        max = matrix[i, j];
                    }
                }
                maxElements[i] = max;
            }

// Упорядочим строки матрицы по возрастанию их максимальных элементов
            for (int i = 0; i < matrix.GetLength(0) - 1; i++) {
                for (int j = i + 1; j < matrix.GetLength(0); j++) {
                    if (maxElements[i] > maxElements[j]) {
                        // Обмен значениями строк
                        for (int k = 0; k < matrix.GetLength(1); k++) {
                            (matrix[i, k], matrix[j, k]) = (matrix[j, k], matrix[i, k]);
                        }
                        // Обмен значениями максимальных элементов
                        (maxElements[i], maxElements[j]) = (maxElements[j], maxElements[i]);
                    }
                }
            }

// Вывод отсортированной матрицы в консоль
            for (int i = 0; i < matrix.GetLength(0); i++) {
                for (int j = 0; j < matrix.GetLength(1); j++) {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}