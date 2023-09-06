using System;
using System.IO;

namespace Day15Tasks.Entities
{
    public static class Methods
    {
        public static void FillFileWithRandomNumbers(string fileName, int count, int min, int max)
        {
            Random random = new Random();
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                for (int i = 0; i < count; i++)
                {
                    writer.WriteLine(random.Next(min, max));
                }
            }
        }
        
        public static void PrintFileContents(string fileName)
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
        
        public static void CalculateSumAndWriteToFile(string fileName)
        {
            int sum = 0;
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    sum += Int32.Parse(line);
                }
            }
            using (StreamWriter writer = new StreamWriter(fileName, true))
            {
                writer.WriteLine(sum);
            }
            Console.WriteLine("В файл дописано: Сумма чисел: " + sum);
        }
        
        public static double Factorial(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException("n должно быть неотрицательным числом.");
            }

            double result = 1.0;

            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }

            return result;
        }
        
        public static double CalculateSinByTaylor(double x, int n)
        {
            double result = x;
            int sign = 1;
            double power = x;
            double factorial = 1;

            for (int i = 1; i < n; i++)
            {
                sign *= -1;
                power *= x * x;
                factorial *= (2 * i - 1) * (2 * i);
                double term = sign * power / factorial;
                result += term;
            }

            return result;
        }
    }
}