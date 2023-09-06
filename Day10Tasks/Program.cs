using System;
using System.Collections.Generic;
using Day10Tasks.Tasks;
using Day9TasksPart2.Tasks;
using static System.Console;

namespace Day10Tasks
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            //1
            Hero hero = new Hero ("Nikitos", 1);
            List<IEnemy> enemies = new List<IEnemy>
            {
                new Zombie(5, 50),
                new Gargoyle(7, 70),
                new Vampire(10, 100)
            };

            while (hero.Hp > 0)
            {
                foreach (IEnemy enemy in enemies)
                {
                    enemy.DealDamage(hero);
                    if (hero.Hp <= 0)
                        break;
                }
                hero.RestoreHealth();
            }

            WriteLine("{0} has died", hero.Name);
            WriteLine();
            
            //2
            List<Car> cars = new List<Car>
            {
                new Car { brand = "BMW", owner = "Smith", year = 2010, mileage = 100000 },
                new Car { brand = "Audi", owner = "Johnson", year = 2015, mileage = 50000 },
                new Car { brand = "Mercedes", owner = "Williams", year = 2012, mileage = 80000 }
            };

            int year = 2012;
            List<Car> filteredCars = new List<Car>();
            foreach (Car car in cars)
            {
                if (car.year < year)
                {
                    filteredCars.Add(car);
                }
            }
            filteredCars.Sort();

            foreach (Car car in filteredCars)
            {
                WriteLine("{0} owned by {1}, bought in {2}, mileage: {3}", car.brand, car.owner, car.year, car.mileage);
            }
            
            //3
            List<Vehicle> vehicles = new List<Vehicle>();
            bool continueAdding = true;

            while (continueAdding)
            {
                Console.WriteLine("Введите название транспортного средства:");
                string name = Console.ReadLine();

                Console.WriteLine("Введите расстояние:");
                double distance = double.Parse(Console.ReadLine() ?? string.Empty);

                Console.WriteLine("Введите стоимость проезда на километр:");
                double costPerKm = double.Parse(Console.ReadLine() ?? string.Empty);

                Vehicle vehicle = new Vehicle(name, distance, costPerKm);
                vehicles.Add(vehicle);

                Console.WriteLine("Хотите продолжить? (да/нет)");
                continueAdding = Console.ReadLine()?.ToLower() == "да" || Console.ReadLine() == "1";
            }

            foreach (var vehicle in vehicles)
            {
                vehicle.ShowVehicle();
            }
            
            
            //4
            double x = 10.0;
            List<Vehicle> expensiveVehicles = new List<Vehicle>();

            WriteLine(vehicles.Count);
            for (var index = 0; index < vehicles.Count; index++)
            {
                var vehicle = vehicles[index];
                WriteLine(vehicle.CalculateCost());
                if (vehicle.CalculateCost() > x)
                {
                    expensiveVehicles.Add(vehicle);
                    vehicles.Remove(vehicle);
                    index--;
                }
            }

            foreach (var vehicle in expensiveVehicles)
            {
                vehicle.ShowVehicle();
            }
        }
    }
}