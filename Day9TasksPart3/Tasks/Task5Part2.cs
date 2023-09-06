using static System.Console;

namespace Day9TasksPart3.Tasks
{
    public abstract class Task5Part2 
    {
        public abstract class Transport 
        { 
            public abstract void ShowInfo(); 
            public abstract double CalculateCost(); 
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
        
        public class Airplane : Transport 
        { 
            private string Name { get; } 
            private double Distance { get; } 
            private double CostPerKm { get; } 
            private int NumberOfPassengers { get; }
            
            public Airplane(string name, double distance, double costPerKm, int numberOfPassengers) 
            { 
                Name = name; 
                Distance = distance; 
                CostPerKm = costPerKm; 
                NumberOfPassengers = numberOfPassengers; 
            }
            
            public override void ShowInfo() 
            {
                WriteLine($"Самолет {Name}, пройденное расстояние {Distance} км, стоимость (км) - {CostPerKm}, пассажиров - {NumberOfPassengers}"); 
            }
            
            public override double CalculateCost() 
            { 
                return Distance * CostPerKm * NumberOfPassengers; 
            } 
        }
        
        public class Ship : Transport 
        { 
            private string Name { get; } 
            private double Distance { get; } 
            private double CostPerKm { get; } 
            private int NumberOfPassengers { get; }
            
            public Ship(string name, double distance, double costPerKm, int numberOfPassengers) 
            { 
                Name = name; 
                Distance = distance; 
                CostPerKm = costPerKm; 
                NumberOfPassengers = numberOfPassengers; 
            }
            
            public override void ShowInfo() 
            { 
                WriteLine($"Корабль {Name}, пройденное расстояние {Distance} км, стоимость (км) - {CostPerKm}, пассажиров - {NumberOfPassengers}"); 
            }
            
            public override double CalculateCost() 
            {
                return Distance * CostPerKm * NumberOfPassengers; 
            } 
        }
    }
}