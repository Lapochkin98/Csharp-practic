using System;

namespace Day4Tasks.Tasks
{
    public static class Day4Class
    {
        public static void Task1(string text)
        {
            Console.WriteLine(text);
        }
        public static double Task2(double avgMark, double stockStipend)
        {
            if (avgMark >= 5 && avgMark < 6)
                return stockStipend;
            if (avgMark >= 6 && avgMark < 8)
                return stockStipend * 1.2;
            if (avgMark >= 8 && avgMark < 9)
                return stockStipend * 1.4;
            if (avgMark >= 9)
                return stockStipend * 1.6;

            return 0;
        }

        public static int Task3(int month, bool isLeapYear)
        {
            switch (month)
            {
                case 2:
                    return isLeapYear ? 29 : 28;
                case 4: case 6: case 9: case 11:
                    return 30;
                default:
                    return 31;
            }
        }

        public static string Task4(int day, int month, bool isLeapYear)
        {
            int daysInMonth = Task3(month, isLeapYear);

            if (day < daysInMonth)
            {
                return $"{day + 1}.{month}";
            }
            else if (month<12)
            {
                return $"1.{month}";
            }
            else
            {
                return $"1.1";
            }
        }

        public static void Task5(ref double a, ref double b)
        {
            (a, b) = (b, a);
        }

        public static void Task6(double a, double b, out double perimeter, out double area)
        {
            double c = Math.Sqrt(a * a + b * b);
            perimeter = a + b + c;
            area = (a * b) / 2;
        }

        public static double Task7(int n)
        {
            double sum = 0;

            for (int i = 1; i < n; i+=2)
            {
                sum += (i + Math.Sin(i))/3.0;
            }

            return sum;
        }

        public static void Task8(double a,double b, double h)
        {
            Console.WriteLine("**    x    *    y    **");

            for (double x = a; x <= b; x += h)
            {
                double y = 5 * x - (2 * Math.Pow(x, 1.0 / 3) + 1);
                Console.WriteLine($"**{x,8:F2}*{y,8:F2}**");
            }
        }

        private static int Task9_factorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            else
            {
                return n * Task9_factorial(n - 1);
            }
        }

        private static double Task9_term(int term)
        {
            return 7.0 / (5.0 * term);
        }

        public static double Task9_sum(int n)
        {
            double total = 0;
            for (int i = 0; i < n; i++)
            {
                total += Task9_term(Task9_factorial(n));
            }

            return total;
        }
    }
}