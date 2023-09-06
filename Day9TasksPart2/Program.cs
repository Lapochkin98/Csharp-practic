using System;
using Day9TasksPart2.Tasks;
using static System.Console;

namespace Day9TasksPart2
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Matrix mat = new Matrix(3);
                mat.Input();
                
                Console.WriteLine("Original matrix:");
                mat.Output();

                mat.Process();

                Console.WriteLine("Processed matrix:");
                mat.Output();
            }
            catch (Exception e)
            {
                WriteLine(e);
                throw;
            }
            try
            {
                WriteLine("Введите имя транспорта: ");
                string name = ReadLine();
                WriteLine("Введите расстояние");
                double distance = double.Parse(ReadLine() ?? string.Empty);
                WriteLine("Введите стоимость(км): ");
                double cost = double.Parse(ReadLine() ?? string.Empty);

                Vehicle vehicle = new Vehicle(name, distance, cost);
                vehicle.ShowVehicle();
                
                WriteLine($"Приблизительная стоимость проезда: {vehicle.CalculateCost()}");
            }
            catch (Exception e)
            {
                WriteLine(e);
                throw;
            }
            try
            {
                WriteLine("Введите номер счета: ");
                string accountNumber = ReadLine();
                WriteLine("Введите баланс счета: ");
                BankAccount user = new BankAccount(accountNumber, int.Parse(ReadLine() ?? string.Empty));

                WriteLine("Положить: ");
                var temp = double.Parse(ReadLine() ?? string.Empty);
                user.AddMoney(temp);
                user.ShowBalance();
                
                WriteLine("Снять: ");
                temp = Double.Parse(ReadLine() ?? string.Empty);
                user.TakeMoney(temp);
                user.ShowBalance();
                
            }
            catch (Exception e)
            {
                WriteLine($"Ошибка: {e.Message}");
            }
            
        }
    }
}