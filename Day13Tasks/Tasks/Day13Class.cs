using System;
using static System.Console;

namespace Day13Tasks.Tasks
{
    public class Day13Class
    {

    }

    [Serializable()]
    class Computer 
    {
        public string Model { get; }
        public int Ram { get; }

        public Computer(string model, int ram)
        {
            Model = model;
            Ram = ram;
        }

        public void PrintInfo()
        {
            WriteLine($"Model: {Model}, RAM: {Ram} GB");
        }

    }
}