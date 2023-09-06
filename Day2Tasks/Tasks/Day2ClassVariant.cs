using System;
// ReSharper disable RedundantAssignment

namespace Day2Tasks.Tasks
{
    public class Day2ClassVariant
    {
        private int Variant1 { get; set; }

        //1 часть
        public static void Task1()
        {
            Console.WriteLine("Введите A: ");
            double a = double.Parse(Console.ReadLine() ?? string.Empty);
            Console.WriteLine("Введите B: ");
            double b = double.Parse(Console.ReadLine() ?? string.Empty);
            
            if (a>b)
            {
                b = a;
            }
            else if (a<b)
            {
                a = b;
            }
            else
            {
                a = 0;
                b = 0;
            }
        }

        public static void Task2()
        {
            Console.Write("Введите натуральное число: ");
            int num = int.Parse(Console.ReadLine() ?? string.Empty);

            if (num >= 10 && num <= 99)
            {
                Console.WriteLine("Данное число является двузначным.");
            }
            else
            {
                Console.WriteLine("Данное число не является двузначным.");
            }
        }
        
        
        //2часть
        public Day2ClassVariant(int variant)
        {
            this.Variant1 = variant;
        }

        public void Task3()
        {
            Variant1 += 13;
            
            Console.Write("Введите номер месяца (1-январь, 2-февраль, ...): ");
            int month = int.Parse(Console.ReadLine() ?? string.Empty);

            string season = "";

            switch (month)
            {
                case 12: case 1: case 2:
                    season = "зима";
                    break;
                case 3: case 4: case 5:
                    season = "весна";
                    break;
                
                case 6: case 7: case 8:
                    season = "лето";
                    break;
                case 9: case 10: case 11:
                    season = "осень";
                    break;
                default:
                    Console.WriteLine("Некорректный номер месяца.");
                    break;
            }

            Console.WriteLine($"Время года: {season}");
        }

        public void Task4()
        {
            Console.Write("Введите номер элемента окружности (1-R, 2-D, 3-L, 4-S): ");
            int element = int.Parse(Console.ReadLine() ?? string.Empty);

            double value;
            double pi = 3.14;

            switch (element)
            {
                case 1:
                    Console.Write("Введите радиус: ");
                    value = double.Parse(Console.ReadLine() ?? string.Empty);
                    Console.WriteLine($"Диаметр: {2 * value}");
                    Console.WriteLine($"Длина: {2 * pi * value}");
                    Console.WriteLine($"Площадь: {pi * value * value}");
                    break;

                case 2:
                    Console.Write("Введите диаметр: ");
                    value = double.Parse(Console.ReadLine() ?? string.Empty);
                    Console.WriteLine($"Радиус: {value / 2}");
                    Console.WriteLine($"Длина: {pi * value}");
                    Console.WriteLine($"Площадь: {pi * (value / 2) * (value / 2)}");
                    break;

                case 3:
                    Console.Write("Введите длину окружности: ");
                    value = double.Parse(Console.ReadLine() ?? string.Empty);
                    Console.WriteLine($"Радиус: {value / (2 * pi)}");
                    Console.WriteLine($"Диаметр: {value / pi}");
                    Console.WriteLine($"Площадь: {pi * ((value / (2 * pi)) * (value / (2 * pi)))}");
                    break;

                case 4:
                    Console.Write("Введите площадь круга: ");
                    value = double.Parse(Console.ReadLine() ?? string.Empty);
                    Console.WriteLine($"Радиус: {Math.Sqrt(value / pi)}");
                    Console.WriteLine($"Диаметр: {2 * Math.Sqrt(value / pi)}");
                    Console.WriteLine($"Длина: {2 * pi * Math.Sqrt(value / pi)}");
                    break;

                default:
                    Console.WriteLine("Некорректный номер элемента.");
                    break;
            }
        }
    }
}