using System;
using static System.Console;

namespace Day9TasksPart2.Tasks
{
    public class Day9ClassPart2
    {
        
    }

    public class BankAccount
    {
        private string AccountNumber { get; }
        private double AccountBalance { get; set; }

        public BankAccount(string accountNumber, double accountBalance)
        {
            AccountNumber = accountNumber;
            AccountBalance = accountBalance;
        }

        public void ShowBalance()
        {
            WriteLine($"Баланс лицевого счета \\{AccountNumber}\\ состовляет: {AccountBalance}");
        }

        public void AddMoney(double money)
        {
            if (money < 0)
                throw new Exception("Error");
            AccountBalance += money;
        }

        public void TakeMoney(double money)
        {
            AccountBalance -= AccountBalance - money >= 0 ? money : throw new ArgumentException("Недостаточно средств");
        }
            
    }

    public class Vehicle
    {
        private string Name { get; }
        protected double Distance { get; }
        protected double CostPerKm { get; }

        public Vehicle(string name, double distance, double costPerKm)
        {
            Name = name;
            Distance = distance;
            CostPerKm = costPerKm;
        }

        internal Vehicle()
        {
            Name = "";
            Distance = 0;
            CostPerKm = 0;
        }

        public void ShowVehicle()
        {
            if (Name == "" || Distance <= 0)
                WriteLine("Данные недоступны");
            else
                WriteLine($"Транспортное средство //{Name}//, расстояние //{Distance}//, стоимость(км) - //{CostPerKm}//.");
        }

        public virtual double CalculateCost() => CostPerKm*Distance;
    }

    public class Plane:Vehicle
    {
        protected string Name = "Самолёт";
        private readonly double _h;
        private readonly double _v;

        public Plane(double h, double v)
        {
            this._h = h;
            this._v = v;
        }

        public override double CalculateCost() => (CostPerKm * Distance)+(100*_h*_v);
    }

    public class Ship:Vehicle
    {
        protected string Name = "Корабль";
        private readonly int _k;
        private readonly int _n;

        public Ship(int k, int n)
        {
            this._k = k;
            this._n = n;
        }

        public override double CalculateCost()
        {
            if (_n == 3 || _n == 4)
            {
                return (CostPerKm * Distance)*(1+(Math.Pow(_k,2)/100));
            }

            return (CostPerKm * Distance);
        }
    }
    
    public class Matrix
    {
        private readonly double[,] _data;

        public Matrix()
        {
            _data = new double[1, 1];
        }

        public Matrix(int n)
        {
            _data = new double[n, n];
        }

        public Matrix(int rows, int cols)
        {
            _data = new double[rows, cols];
        }

        public Matrix(double[,] data)
        {
            _data = data.Clone() as double[,];
        }

        public double this[int i, int j]
        {
            get => _data[i, j];
            set => _data[i, j] = value;
        }

        private int Rows => _data.GetLength(0);

        private int Cols => _data.GetLength(1);

        public void Input()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    Console.Write($"Enter value for element ({i}, {j}): ");
                    if (!double.TryParse(Console.ReadLine(), out double val))
                    {
                        Console.WriteLine("Invalid input, try again.");
                        j--;
                    }
                    else
                    {
                        _data[i, j] = val;
                    }
                }
            }
        }

        public void Output()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    Console.Write($"{_data[i, j],-10:F2}");
                }
                Console.WriteLine();
            }
        }

        public void Process()
        {
            for (int i = 0; i < Rows; i++)
            {
                double max = 0;
                for (int j = 0; j < Cols; j++)
                {
                    if (_data[i, j] > max)
                    {
                        max = _data[i, j];
                    }
                }
                if (max != 0)
                {
                    for (int j = 0; j < Cols; j++)
                    {
                        _data[i, j] /= max;
                    }
                }
            }
        }
    }
}