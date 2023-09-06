using System;
using System.Threading;
using System.Threading.Tasks;
using Day15Tasks.Entities;

namespace Day15Tasks
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Введи номер задания: ");
                int task = int.Parse(Console.ReadLine() ?? string.Empty);
                switch (task)
                {
                    case 0:
                        return;
                    case 1:
                        Console.WriteLine("Задание 1: ");
                        
                        string fileName = "numbers.txt";
                        int count = 10;
                        int min = 1;
                        int max = 100;
                        SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);

                        Methods.FillFileWithRandomNumbers(fileName, count, min, max);

                        for (int i = 0; i < 5; i++)
                        {
                            var semaphore2 = semaphore;
                            var name1 = fileName;
                            var printThread = new Thread(() =>
                            {
                                semaphore2.Wait();
                                Methods.PrintFileContents(name1);
                                semaphore2.Release();
                            });
                            printThread.Start();

                            var semaphore1 = semaphore;
                            var name = fileName;
                            var calculateThread = new Thread(() =>
                            {
                                semaphore1.Wait();
                                Methods.CalculateSumAndWriteToFile(name);
                                semaphore1.Release();
                            });
                            calculateThread.Start();

                            printThread.Join();
                            calculateThread.Join();
                        }
                        break;
                    case 2:
                        Console.WriteLine("Задание 2: ");
                        double[] angles = { 0.1, 0.2, 0.3, 0.4, 0.5 };
                        int n = 100;

                        Parallel.ForEach(angles, angle =>
                        {
                            double sinByTaylor = Methods.CalculateSinByTaylor(angle, n);
                            Console.WriteLine($"Ряд Тейлора: sin({angle:F2}) = {sinByTaylor:F5}. " +
                                              $"Класс Math: sin({angle:F2}) = {Math.Sin(angle):F5}");
                        });

                        Console.WriteLine();

                        foreach (double angle in angles)
                        {
                            double sinByTaylor = Methods.CalculateSinByTaylor(angle, n);
                            Console.WriteLine($"Ряд Тейлора: sin({angle:F2}) = {sinByTaylor:F5}. " +
                                              $"Класс Math: sin({angle:F2}) = {Math.Sin(angle):F5}");
                        }

                        break;
                    

                }

                return;
            }
        }
    }
}