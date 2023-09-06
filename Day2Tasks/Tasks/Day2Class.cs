using System;

namespace Day2Tasks.Tasks
{
    public class Day2Class
    {
        public static void Task1()
        {
            int x = int.Parse(Console.ReadLine() ?? string.Empty);
            int result = x > 0 ? x + 1 : x - 2;
            Console.WriteLine(result);
        }

        public static void Task2()
        {
            int x = int.Parse(Console.ReadLine() ?? string.Empty);
            int y = int.Parse(Console.ReadLine() ?? string.Empty);

            string quadrant = x == 0 && y == 0 ? "начале координат" :
                x == 0 ? "на оси OY" :
                y == 0 ? "на оси OX" :
                x > 0 && y > 0 ? "в первой координатной четверти" :
                x < 0 && y > 0 ? "во второй координатной четверти" :
                x < 0 && y < 0 ? "в третьей координатной четверти" :
                "в четвертой координатной четверти";

            Console.WriteLine($"Точка находится {quadrant}");
        }

        public static void Task3()
        {
            Console.WriteLine("Введите число a: ");
            double a = double.Parse(Console.ReadLine() ?? string.Empty);
            
            Console.WriteLine("Введите число b: ");
            double b = double.Parse(Console.ReadLine() ?? string.Empty);
            
            Console.WriteLine("Введите число c: ");
            double c = double.Parse(Console.ReadLine() ?? string.Empty);


            if ((a + b > c) && (a + c > b) && (c + b > a))
            {
                Console.WriteLine("Треугольник существует");
            }
            else
            {
                Console.WriteLine("Треугольника не существует");
            }
        }

        public static void Task4()
        {
            Console.WriteLine("Введите число a: ");
            double a = double.Parse(Console.ReadLine() ?? string.Empty);
            
            Console.WriteLine("Введите число b: ");
            double b = double.Parse(Console.ReadLine() ?? string.Empty);
            
            Console.WriteLine("Введите число c: ");
            double c = double.Parse(Console.ReadLine() ?? string.Empty);
            
            
            if (Math.Pow(c,2.0) == Math.Pow(a,2.0) + Math.Pow(b,2) ) 
            {
                Console.WriteLine("Треугольник со сторонами {0}, {1}, {2} является прямоугольным", a, b, c);
            } 
            else 
            {
                Console.WriteLine("Треугольник со сторонами {0}, {1}, {2} не является прямоугольным", a, b, c);
            }
        }

        public static void Task5()
        {
            Console.WriteLine("Введите число a: ");
            int a = int.Parse(Console.ReadLine() ?? string.Empty);

            switch (Math.Sign(a))
            {
                case -1:
                    if (a % 2 == 0)
                    {
                        Console.WriteLine("Отрицательное четное число");
                    }
                    else
                    {
                        Console.WriteLine("Отрицательное нечетное число");
                    }
                    break;
                case 0:
                    Console.WriteLine("Нулевое число");
                    break;
                case 1:
                    if (a % 2 == 0)
                    {
                        Console.WriteLine("Положительное четное число");
                    }
                    else
                    {
                        Console.WriteLine("Положительное нечетное число");
                    }
                    break;
            }
        }

        public static void Task6()
        {
            Console.Write("Введите первое число: ");
            double num1 = double.Parse(Console.ReadLine() ?? string.Empty);

            Console.Write("Введите второе число: ");
            double num2 = double.Parse(Console.ReadLine() ?? string.Empty);

            Console.Write("Введите знак арифметического действия (+, -, *, /): ");
            char operation = char.Parse(Console.ReadLine() ?? string.Empty);

            double result = 0;

            switch (operation)
            {
                case '+':
                    result = num1 + num2;
                    break;
                case '-':
                    result = num1 - num2;
                    break;
                case '*':
                    result = num1 * num2;
                    break;
                case '/':
                    result = num1 / num2;
                    break;
                default:
                    Console.WriteLine("Неизвестный знак арифметического действия.");
                    break;
            }

            Console.WriteLine("Результат: " + result);
        }

        public static void Task7()
        {
            Console.WriteLine("Введите число a: "); //радиус
            double a = double.Parse(Console.ReadLine() ?? string.Empty);
            
            Console.WriteLine("Введите число b: "); //ширина
            double b = double.Parse(Console.ReadLine() ?? string.Empty);
            
            Console.WriteLine("Введите число c: "); //высота
            double c = double.Parse(Console.ReadLine() ?? string.Empty);


            //по теореме Пифагора: d = sqrt(bb + cc).
            double d = 2 * a; // диагональ прямоугольника
            if (d < b && d < c)
            {
                Console.WriteLine("Окружность можно поместить внутри прямоугольника");
            }
            else
            {
                Console.WriteLine("Окружность нельзя поместить внутри прямоугольника");
            }
        }

        public static void Task8()
        {
            Console.WriteLine("Введите дату в формате dd.MM.yyyy:");
            string input = Console.ReadLine(); // считываем дату в строку
            DateTime date = DateTime.ParseExact(input, "dd.MM.yyyy", null);
            DateTime nextDay = date.AddDays(1);
            Console.WriteLine("Дата следующего дня: " + nextDay.ToString("dd.MM.yyyy"));
        }

        public static void Task9()
        {
            Console.WriteLine("Введите день, месяц и год рождения первого человека (через пробел):");
            string input1 = Console.ReadLine();
            string[] parts1 = input1.Split(' '); // разбиваем строку на части по пробелам
            int day1 = int.Parse(parts1[0]); // считываем день
            int month1 = int.Parse(parts1[1]); // считываем месяц
            int year1 = int.Parse(parts1[2]); // считываем год

            Console.WriteLine("Введите день, месяц и год рождения второго человека (через пробел):");
            string input2 = Console.ReadLine();
            string[] parts2 = input2.Split(' '); // разбиваем строку на части по пробелам
            int day2 = int.Parse(parts2[0]); // считываем день
            int month2 = int.Parse(parts2[1]); // считываем месяц
            int year2 = int.Parse(parts2[2]); // считываем год

            DateTime date1 = new DateTime(year1, month1, day1); // создаем объект DateTime для первого человека
            DateTime date2 = new DateTime(year2, month2, day2); // создаем объект DateTime для второго человека

            if (date1 < date2)
            {
                Console.WriteLine("Первый человек старше");
            }
            else if (date1 > date2)
            {
                Console.WriteLine("Второй человек старше");
            }
            else
            {
                Console.WriteLine("Оба человека родились в один день");
            }
        }

        public static void Task10()
        {
            Console.WriteLine("Введите положительное вещественное число:");
            double number = double.Parse(Console.ReadLine() ?? string.Empty);

            int decimalPointPos = number.ToString().IndexOf('.');
            string fractionPart = number.ToString().Substring(decimalPointPos + 1).TrimStart('0');
            bool hasZero = fractionPart.Contains("0");

            if (hasZero)
            {
                Console.WriteLine("Среди первых трех цифр дробной части есть ноль");
            }
            else
            {
                Console.WriteLine("Среди первых трех цифр дробной части нет нуля");
            }
            
            /*
            Console.WriteLine("Введите положительное вещественное число:");
            double number = double.Parse(Console.ReadLine());

        
            double fraction = number - Math.Truncate(number);

            int digits = (int)(fraction * 1000);
            if (digits % 10 == 0 || (digits / 10) % 10 == 0 || (digits / 100) % 10 == 0)
            {
                Console.WriteLine("Среди первых трех цифр дробной части есть цифра 0");
            }
            else
            {
                Console.WriteLine("Среди первых трех цифр дробной части нет цифры 0");
            }
            */
        }
    }
}