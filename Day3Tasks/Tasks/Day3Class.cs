using System;

namespace Day3Tasks.Tasks
{
    public static class Day3Class
    {
        public static void Task1()
        {
            Console.Write("Введите первое число: ");
            int num1 = int.Parse(Console.ReadLine() ?? string.Empty);

            Console.Write("Введите второе число: ");
            int num2 = int.Parse(Console.ReadLine() ?? string.Empty);
            double result = 1;
            
            for (int i = num1; i <= num2; i++)
                result *= i;
            Console.WriteLine($"Произведение равно: {result}");
        }

        public static void Task2()
        {
            Console.Write("Введите первое число: ");
            int num1 = int.Parse(Console.ReadLine() ?? string.Empty);

            Console.Write("Введите второе число: ");
            int num2 = int.Parse(Console.ReadLine() ?? string.Empty);
            
            for (int i = num1; i <= num2; i++)
                if(i % 17 == 0)
                    Console.WriteLine(i);
        }

        public static void Task3()
        {
            Console.Write("Введите первое число: ");
            int num1 = int.Parse(Console.ReadLine() ?? string.Empty);

            Console.Write("Введите второе число: ");
            int num2 = int.Parse(Console.ReadLine() ?? string.Empty);

            for (int i = num1; i <= num2; i++)
                if (i % 17 == 0)
                {
                    Console.WriteLine($"Минимальное число: {i}");
                    break;
                }
        }

        public static void Task4()
        {
            Console.Write("Введите первое число: ");
            int num1 = int.Parse(Console.ReadLine() ?? string.Empty);

            Console.Write("Введите второе число: ");
            int num2 = int.Parse(Console.ReadLine() ?? string.Empty);
            int temp = int.MinValue;
            
            for (int i = num1; i <= num2; i++)
                if(i % 17 == 0)
                    if (i > temp)
                        temp = i;
            Console.WriteLine(temp != int.MinValue ? $"Максимальное число: {temp}" : "Чисел нет");
        }

        public static void Task5()
        {
            Console.WriteLine("Введите стоимость метра ткани: ");
            double cost = double.Parse(Console.ReadLine() ?? string.Empty);
            Console.WriteLine("Введите длину: ");
            int line = int.Parse(Console.ReadLine() ?? string.Empty);


            for (int i = 0; i <= line; i++)
            {
                var total = i * cost;
                if(i>=5 && i<10)
                    // ReSharper disable once RedundantAssignment
                    Console.WriteLine($"Цена за длину {i} составляет: {total -= total * 0.05}");
                else if (i>=10)
                    // ReSharper disable once RedundantAssignment
                    Console.WriteLine($"Цена за длину {i} составляет: {total -= total * 0.1}");
                else
                {
                    Console.WriteLine($"Цена за длину {i} составляет: {total}");
                }
            }

        }

        public static void Task6()
        {
            Console.Write("Введите количество чисел: ");
            int n = int.Parse(Console.ReadLine() ?? string.Empty);

            Console.Write("Введите число X: ");
            int x = int.Parse(Console.ReadLine() ?? string.Empty);

            int count = 0;

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Введите число {i + 1}: ");
                int num = int.Parse(Console.ReadLine() ?? string.Empty);

                if (num > x)
                {
                    count++;
                }
            }

            Console.WriteLine($"Количество чисел, больших {x}: {count}");
        }

        public static void Task7()
        {
            Console.WriteLine("Введите n");
            int n = int.Parse(Console.ReadLine() ?? string.Empty);
            // ReSharper disable once NotAccessedVariable
            double sum = 0;

            for (int i = 1; i <= n; i++)
            {
                sum += 2 + (1.0 / i);
            }
            Console.WriteLine($"Сумма ряда равна: {sum}");
        }

        public static void Task8()
        {
            Console.WriteLine("Введите число X: ");
            int x = int.Parse(Console.ReadLine() ?? string.Empty);

            bool isPrime = true;

            for (int i = 2; i < x; i++)
            {
                if (x % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }
            Console.WriteLine(isPrime ? $"{x} - простое число" : $"{x} - не простое число");
        }

        public static void Task9()
        {
            Console.Write("Введите начальное число: ");
            int a = int.Parse(Console.ReadLine() ?? string.Empty);

            Console.Write("Введите конечное число: ");
            int b = int.Parse(Console.ReadLine() ?? string.Empty);

            for (int i = a; i <= b; i++)
            {
                bool isPrime = true;

                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                    Console.WriteLine(i);
            }
        }
    }
}