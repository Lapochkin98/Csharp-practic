using System;

namespace ConsoleApplication1.Tasks
{
    public class TaskN13
    {
        private static int Factorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            else
            {
                return n * Factorial(n - 1);
            }
        }
        
        public static void Task()
        {
            Console.WriteLine("Введите число x: ");
            double x = double.Parse(Console.ReadLine() ?? string.Empty);
            
            Console.WriteLine("Введите число y: ");
            double y = double.Parse(Console.ReadLine() ?? string.Empty);
            
            Console.WriteLine("Введите число z: ");
            double z = double.Parse(Console.ReadLine() ?? string.Empty);
            
            
            double a = Math.Log(Math.Abs( (1 + (y + Math.Sqrt(Math.Abs(x)))) * (x + (Math.Pow(y, 1.0/3) / z + (Math.Pow(x,2) / 4)))));
            double b = x - (Math.Pow(x, 2) / Factorial(3) + (Math.Pow(x, 5) / Factorial(5)));
            
            Console.WriteLine("Ответ а: " + a);
            Console.WriteLine("Ответ b: " + b);
        }
    }
}