using System;
using Day4Tasks.Tasks;

namespace Day4Tasks
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("выберите задание(TaskNull 1-9): ");
            int task = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            switch (task)
            {
                case 1:
                {
                    
                    Day4Class.Task1(Console.ReadLine());
                    break;
                }
                case 2:
                {
                    double avgMark = Double.Parse(Console.ReadLine() ?? string.Empty);
                    double stockStipend = Double.Parse(Console.ReadLine() ?? string.Empty);
                    Console.WriteLine(Day4Class.Task2(avgMark, stockStipend));
                    break;
                }
                case 3:
                {
                    int month = int.Parse(Console.ReadLine() ?? string.Empty);
                    bool isLeapYear = bool.Parse(Console.ReadLine() ?? string.Empty);
                    Console.WriteLine(Day4Class.Task3(month, isLeapYear));
                    break;
                }
                case 4:
                {
                    int day = int.Parse(Console.ReadLine() ?? string.Empty);
                    int month = int.Parse(Console.ReadLine() ?? string.Empty);
                    bool isLeapYear = bool.Parse(Console.ReadLine() ?? string.Empty);
                    Console.WriteLine(Day4Class.Task4(day, month, isLeapYear));
                    break;
                }
                case 5:
                {
                    double a = double.Parse(Console.ReadLine() ?? string.Empty);
                    double b = double.Parse(Console.ReadLine() ?? string.Empty);
                    Day4Class.Task5(ref a,ref b);
                    break;
                }
                case 6:
                {
                    double a = double.Parse(Console.ReadLine() ?? string.Empty);
                    double b = double.Parse(Console.ReadLine() ?? string.Empty);

                    Day4Class.Task6(a,b,out var perimeter, out var area);
                    Console.WriteLine($"P={perimeter}, S={area}");
                    break;
                }
                case 7:
                {
                    Console.WriteLine("Введите N:");
                    int n = int.Parse(Console.ReadLine() ?? string.Empty);
                    
                    if (n % 2 == 0)
                    {
                        n++;
                        Console.WriteLine($"N было увеличено до {n}");
                    }
                    
                    Console.WriteLine(Day4Class.Task7(n));
                    break;
                }
                case 8:
                {
                    Console.Write("Введите начальное значение x: ");
                    double a = double.Parse(Console.ReadLine() ?? string.Empty);

                    Console.Write("Введите конечное значение x: ");
                    double b = double.Parse(Console.ReadLine() ?? string.Empty);

                    Console.Write("Введите шаг: ");
                    double h = double.Parse(Console.ReadLine() ?? string.Empty);
                    
                    Day4Class.Task8(a,b,h);
                    
                    break;
                }
                case 9:
                {
                    Console.WriteLine("Введите значение N: ");
                    int n = int.Parse(Console.ReadLine() ?? string.Empty);

                    Console.WriteLine(Day4Class.Task9_sum(n));
                    break;
                }
            }
        }
    }
}