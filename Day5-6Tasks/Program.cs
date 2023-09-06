using System;
using Day5_6Tasks.Tasks;

namespace Day5_6Tasks
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Введите к-во элементов массива: ");
            int n = int.Parse(Console.ReadLine() ?? string.Empty);
            
            int[] userArray = new int[n]; 

            Console.WriteLine("Выберите метод заполнения массива(1-случайно, 2-клавиатура, 3-файл): ");
            int userFillingType = int.Parse(Console.ReadLine() ?? string.Empty);

            switch (userFillingType)
            {
                case 1:
                {
                    userArray = Task1.RandomFilling(userArray);
                    break;
                }
                case 2:
                {
                    userArray = Task1.HandFilling(userArray);
                    break;
                }
                case 3:
                {
                    userArray = Task1.FileFilling(userArray);
                    break;
                }
                default:
                {
                    Console.WriteLine("Тип заполнения не распознан, выбран тип по умолчанию: случайно.");
                    userArray = Task1.RandomFilling(userArray);
                    break;
                }
            }
            
            
            //Вывод
            Console.WriteLine("Теперь выберите тип вывода массива(1-строка, 2-столбец, 3-файл): ");
            int userOut = int.Parse(Console.ReadLine() ?? string.Empty);

            switch (userOut)
            {
                case 1:
                {
                    Task1.LineOut(userArray);
                    break;
                }
                case 2:
                {
                    Task1.ColumnOut(userArray);
                    break;
                }
                case 3:
                {
                    Task1.FileOut(userArray);
                    break;
                }
                default:
                {
                    Console.WriteLine("Выбран тип по умолчанию: Столбец");
                    break;
                }
            }
            
        }
    }
}