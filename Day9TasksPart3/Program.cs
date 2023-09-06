using Day9TasksPart3.Tasks;
using static System.Console;
using Bus = Day9TasksPart3.Tasks.Bus;
using Car = Day9TasksPart3.Tasks.Car;
using Transport = Day9TasksPart3.Tasks.Transport;

namespace Day9TasksPart3
{
    internal static class Program
    {
/*
        private static string RepeatChar(char c, int n)
        {
            return new string(c, n);
        }
*/
        
/*
        static string JoinCharArray(char[] arr)
        {
            return new string(arr);
        }
*/
        
/*
        static string JoinStringArray(string[] arr)
        {
            return string.Join(", ", arr);
        }
*/
        
/*
        static string GenerateRandomString(int n)
        {
            Random rand = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, n).Select(s => s[rand.Next(s.Length)]).ToArray());
        }
*/
        
        public static void Main(string[] args)
        {
            TwoDimArray array1 = new TwoDimArray(new[,] { { 1, 2 }, { 3, 4 } });
            TwoDimArray array2 = new TwoDimArray(new
                [,] { { 5, 6 }, { 7, 8 } });

            WriteLine(array1 > array2); // Выводит False, так как сумма элементов главной диагонали в array1 меньше, чем в array2
            WriteLine(array1 < array2); // Выводит True, так как сумма элементов главной диагонали в array1 меньше, чем в array2
            
            //5-1
            Transport[] transports = new Transport[5];
            transports[0] = new Car("Ford", 100, 5);
            transports[1] = new Car("Tesla", 200, 10);
            transports[2] = new Bus(20, 300, 2);
            transports[3] = new Bus(50, 500, 3);
            transports[4] = new Transport();
            
            foreach (Transport transport in transports)
            {
                transport.ShowInfo();
                WriteLine($"Стоимость: {transport.CalculateCost()}");
                WriteLine();
            }
            
            //5-2
            // Transport[] transports = new Transport[] {
            //     new Car("Toyota Camry", 500, 5.5),
            //     new Car("BMW X5", 300, 9.3),
            //     new Bus(30, 200, 4.0),
            //     new Airplane("Самолет", 200, 2000, 12),
            //     new Ship("Корабль", 500, 800, 10)
            // };
            //
            // double totalAirplaneCost = 0;
            // double totalShipCost = 0;
            //
            // foreach (Transport t in transports)
            // {
            //     t.ShowInfo();
            //
            //     if (t is Airplane)
            //     {
            //         totalAirplaneCost += t.CalculateCost();
            //     }
            //     else if (t is Ship)
            //     {
            //         totalShipCost += t.CalculateCost();
            //     }
            // }
            //
            // int numberOfAirplanes = transports.Count(t => t is Airplane);
            // int numberOfShips = transports.Count(t => t is Ship);
            //
            // double averageAirplaneCost = numberOfAirplanes > 0 ? totalAirplaneCost / numberOfAirplanes : 0;
            // double averageShipCost = numberOfShips > 0 ? totalShipCost / numberOfShips : 0;
            //
            // WriteLine($"Средняя стоимость проезда на самолете: {averageAirplaneCost:F2}");
            // WriteLine($"Средняя стоимость проезда на корабле: {averageShipCost:F2}");
            //
            // ReadKey();
        }
    }
}