using System;

namespace Day10Tasks.Tasks
{
    public class Day10ClassPart2
    {
        
    }
    class Car : IComparable<Car>
    {
        // ReSharper disable once InconsistentNaming
        public string brand;
        // ReSharper disable once InconsistentNaming
        public string owner;
        // ReSharper disable once InconsistentNaming
        public int year;
        // ReSharper disable once InconsistentNaming
        public int mileage;
            

        public int CompareTo(Car other)
        {
            return mileage.CompareTo(other.mileage);
        }
    }
}