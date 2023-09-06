using System;

namespace Day3Tasks.Tasks
{
    public class Day3ClassVariant
    {
        public static void Task1()
        {
            Console.WriteLine("Выберите подменю(1-6): ");
            int userChoise = int.Parse(Console.ReadLine() ?? string.Empty);
            switch (userChoise)
            {
                case 1:
                {
                    Console.Write("Введите число: ");
                    int num = int.Parse(Console.ReadLine() ?? string.Empty);
                    int digits = 0;
                    while (num != 0) {
                        digits++;
                        num /= 10; }
                    Console.WriteLine($"Количество цифр: {digits}");
                    break;
                }
                case 2:
                {
                    int number = int.Parse(Console.ReadLine() ?? string.Empty);
                    int digit = int.Parse(Console.ReadLine() ?? string.Empty);
                    int count = 0;
                    while (number > 0) {
                        if (number % 10 == digit)
                            count++;
                        number /= 10; }
                    Console.WriteLine($"Цифра {digit} встречается в числе {count} раз");
                    break;
                }
                case 3:
                {
                    int number = 12345;
                    int count = 0;
                    while (number > 0) {
                        int digit = number % 10;
                        if (digit % 2 == 0)
                            count++;
                        number /= 10; }
                    Console.WriteLine($"Количество чётных цифр в числе: {count}");
                    break;
                }
                case 4:
                {
                    int number = 36;
                    int maxDivisor = 1;
                    for (int i = 2; i < number; i++) 
                    { 
                        // ReSharper disable once ConditionIsAlwaysTrueOrFalse
                        if (number % i == 0 && i != number)
                            maxDivisor = i;
                    }
                    Console.WriteLine($"Максимальный делитель числа {number}, отличающийся от него: {maxDivisor}");
                    break;
                }
                case 5:
                {
                    int number = 12345;
                    int minDigit = 10;
                    int minIndex = -1;
                    for (int i = 0; i < number.ToString().Length; i++) {
                        int digit = number % 10;
                        if (digit < minDigit) {
                            minDigit = digit;
                            minIndex = i;
                        }
                        number /= 10;
                    }
                    Console.WriteLine($"Порядковый номер минимальной цифры: {minIndex}");
                    break;
                }
                case 6:
                {
                    int n = 5;
                    int[] numbers = {1, -2, 3, 4, -5};
                    bool found = false;
                    for (int i = 0; i < n - 2; i++) {
                        if (numbers[i] > 0 && numbers[i + 1] > 0 && numbers[i + 2] > 0) {
                            found = true;
                            break;
                        } else if (numbers[i] < 0 && numbers[i + 1] < 0 && numbers[i + 2] < 0) {
                            found = true;
                            break;
                        }
                    }
                    Console.WriteLine($"Было ли среди введенных чисел как минимум 3 числа подряд одинакового знака: {found}");
                    break;
                }
            }
        }
        public static double Task2(double n)
        {
            if (n == 0)
            {
                return 1;
            }
            else
            {
                return n * Task2(n - 1);
            }
        }
        public static void Task3()
        {
            string userCheck = "";
            string password = "12345";
            int counter = 0;
            
            while (userCheck != password)
            {
                Console.WriteLine("Введите пароль: ");
                userCheck = Console.ReadLine();
                if (userCheck != password)
                    counter++;
            }
            Console.WriteLine(counter);
        }

        public static void Task4()
        {
            Console.Write("Введите натуральное число: ");
            int n = int.Parse(Console.ReadLine() ?? string.Empty);

            int sum = 0;

            for (int i = 1; i <= n; i++)
            {
                sum += (int)Math.Pow(2, i);
            }

            Console.WriteLine($"{n} is {sum}");
        }

        public static void Task5()
        {
            int n = int.Parse(Console.ReadLine() ?? string.Empty); 
            int prev1 = 1, prev2 = 1, cur = 1;

            // находим n-ое число Фибоначчи
            for (int i = 2; i < n; i++)
            {
                cur = prev1 + prev2;
                prev2 = prev1;
                prev1 = cur;
            }

            Console.WriteLine($"n-ое число Фибоначчи: {cur}");

            // находим сумму первых n чисел Фибоначчи
            int sum = 2;
            prev1 = 1;
            prev2 = 1;
            // ReSharper disable once RedundantAssignment
            cur = 1;

            for (int i = 2; i < n; i++)
            {
                cur = prev1 + prev2;
                prev2 = prev1;
                prev1 = cur;
                sum += cur;
            }

            Console.WriteLine($"Сумма первых {n} чисел Фибоначчи: {sum}");
        }
    }
}