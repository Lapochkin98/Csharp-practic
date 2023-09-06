using System;

namespace ConsoleApplication1.Tasks
{
    public static class Day1Tasks
    {
        public static void Task1()
        {
            Console.WriteLine("Введите два числа: ");
            double a = Double.Parse(Console.ReadLine() ?? string.Empty);
            double b = Double.Parse(Console.ReadLine() ?? string.Empty);
            if (a != 0 && b != 0)
            {
                Console.WriteLine("Сумма: " +(a + b));
                Console.WriteLine("Разность: " +(a - b));
                Console.WriteLine("Произведение: " +(a * b));
                Console.WriteLine("Частное: " + (a / b));
            }
            else
            {
                Console.WriteLine("Ошибка, одно из чисел равно нулю!");
            }
        }
        
        public static void Task2()
        {
            Console.WriteLine("Введите число N: ");
            int n = int.Parse(Console.ReadLine() ?? string.Empty);
            Console.WriteLine("Количество секунд, прошедших с начала последнего часа: " + (n % 3600));       
        }
        
        public static void Task3()
        {
            Console.WriteLine("Введите автомобиля 1: ");
            double v1 = double.Parse(Console.ReadLine() ?? string.Empty);
            Console.WriteLine("Введите автомобиля 2: ");
            double v2 = double.Parse(Console.ReadLine() ?? string.Empty);
            Console.WriteLine("Введите расстояние между автомобилями: ");
            double s = double.Parse(Console.ReadLine() ?? string.Empty);
            Console.WriteLine("Введите время в часах: ");
            double t = double.Parse(Console.ReadLine() ?? string.Empty);

            
            double distance = Math.Abs((v1 + v2) * t - s); 
            Console.WriteLine($"Расстояние между автомобилями через {t} часов: {distance} км");
        }
        
        public static void Task4()
        {
            Console.WriteLine("Введите число a: ");
            double a = double.Parse(Console.ReadLine() ?? string.Empty);
            
            Console.WriteLine("Введите число b: ");
            double b = double.Parse(Console.ReadLine() ?? string.Empty);
            
            Console.WriteLine("Введите число c: ");
            double c = double.Parse(Console.ReadLine() ?? string.Empty);

            Console.WriteLine("Значение выражения: " + (5*(a+b)/(a-c)));
        }
        
        public static void Task5()
        {
            Console.Write("Введите значение x: ");
            double x = double.Parse(Console.ReadLine() ?? string.Empty);
            double y = 3 * Math.Pow(x, 6) - 6 * Math.Pow(x, 2) + 7;
            Console.WriteLine("Значение функции y = {0}", y);
        }

        public static void Task6()
        {
            Console.WriteLine("Введите число a: ");
            double a = double.Parse(Console.ReadLine() ?? string.Empty);
            
            Console.WriteLine("Введите число b: ");
            double b = double.Parse(Console.ReadLine() ?? string.Empty);
            
            Console.WriteLine("Введите число c: ");
            double c = double.Parse(Console.ReadLine() ?? string.Empty);

            double answer = (-b + Math.Sqrt(Math.Pow(b, 2) - 4 * a * c)) / (2 * a);
            Console.WriteLine("Ответ: " + answer);
        }

        public static void Task7()
        {
            Console.Write("Введите двухзначное число: ");
            int number = int.Parse(Console.ReadLine() ?? string.Empty);
            int firstDigit = number / 10;
            int secondDigit = number % 10;
            int reversedNumber = secondDigit * 10 + firstDigit;
            Console.WriteLine("Число в обратном порядке: " + reversedNumber);
        }

        public static void Task8()
        {
            Console.WriteLine("Введите число a: ");
            double a = double.Parse(Console.ReadLine() ?? string.Empty);
            
            Console.WriteLine("Введите число b: ");
            double b = double.Parse(Console.ReadLine() ?? string.Empty);
            
            Console.WriteLine("Введите число c: ");
            double c = double.Parse(Console.ReadLine() ?? string.Empty);
            
            double temp = a;
            a = b;
            b = c;
            c = temp;

            Console.WriteLine($"A = {a}, B = {b}, C = {c}");
        }

        public static void Task9()
        {
            int a = 4;
            int b = 5;

            // Способ 1: с помощью третьей переменной
            (a, b) = (b, a);

            Console.WriteLine($"a = {a}, b = {b}");

            // Способ 2: с помощью арифметических операций
            a = 4;
            b = 5;
            
            a = a + b;
            b = a - b;
            a = a - b;

            Console.WriteLine($"a = {a}, b = {b}");
        }

    }
}