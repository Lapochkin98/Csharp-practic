using static System.Console;

namespace Day9TasksPart3.Tasks
{
    public class Task5Part1
    {
        
    }
    public class Transport
    {
        public virtual void ShowInfo()
        {
            WriteLine("Базовый класс Транспорт");
        }

        public virtual double CalculateCost()
        {
            return 0;
        }
    }

    public class Car : Transport
    {
        private string Name { get; }
        private double Distance { get; }
        private double CostPerKm { get; }

        public Car(string name, double distance, double costPerKm)
        {
            Name = name;
            Distance = distance;
            CostPerKm = costPerKm;
        }

        public override void ShowInfo()
        {
            WriteLine($"Автомобиль {Name}, пройденное расстояние {Distance} км, стоимость (км) - {CostPerKm}");
        }

        public override double CalculateCost()
        {
            return Distance * CostPerKm;
        }
    }

    public class Bus : Transport
    {
        private int NumberOfPassengers { get; }
        private double Distance { get; }
        private double CostPerKm { get; }

        public Bus(int numberOfPassengers, double distance, double costPerKm)
        {
            NumberOfPassengers = numberOfPassengers;
            Distance = distance;
            CostPerKm = costPerKm;
        }

        public override void ShowInfo()
        {
            WriteLine($"Автобус на {NumberOfPassengers} человек, пройденное расстояние {Distance} км, стоимость (км) - {CostPerKm}");
        }

        public override double CalculateCost()
        {
            return Distance * CostPerKm * NumberOfPassengers;
        }
    }
}