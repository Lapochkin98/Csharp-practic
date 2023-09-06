using System;

namespace ConsoleApplication1.Tasks
{
    public class TaskN
    {
        public void Main()
        {
            Console.WriteLine("Введите число x: ");
            double x = double.Parse(Console.ReadLine() ?? string.Empty);
            
            Console.WriteLine("Введите число y: ");
            double y = double.Parse(Console.ReadLine() ?? string.Empty);
            
            Console.WriteLine("Введите число z: ");
            double z = double.Parse(Console.ReadLine() ?? string.Empty);
            
            
            double a = Math.Sqrt(Math.Abs(x)) * (x - (Math.Pow(y,3) / (z + Math.Pow(x,2)) ) );
            double b = x - (Math.Pow(x, 2) / 3) + (Math.Pow(x, 5) / 5);

            Console.WriteLine("Ответ а: " + a);
            Console.WriteLine("Ответ b: " + b);
        }
    }
}