using System;
using System.IO;

namespace Day5_6Tasks.Tasks
{
    public static class Task1
    {
        public static int[] RandomFilling(int[] userArray)
        {
            Random r = new Random();
            
            for (int i = 0; i < userArray.Length; i++)
            {
                userArray[i] = r.Next(1, 1000);
            }
            return userArray;
        }

        public static int[] HandFilling(int[] userArray)
        {
            for (int i = 0; i < userArray.Length; i++)
                userArray[i] = int.Parse(Console.ReadLine() ?? string.Empty);
            return userArray;
        }

        public static int[] FileFilling(int[] userArray)
        {
            string[] userArrayString = File.ReadAllLines("userArray.txt");
            if (userArray.Length == userArrayString.Length)
                for (int i = 0; i < userArray.Length; i++)
                    userArray[i] = int.Parse(userArrayString[i]);
            else
            {
                Console.WriteLine("Размеры массивов не совпадают(SizeException).");
                Console.WriteLine("Заполнение массива типом по умолчанию: Случайно");
                userArray = RandomFilling(userArray);
            }
            return userArray;
        }

        public static void LineOut(int[] userArray)
        {
            foreach (var el in userArray)
                Console.Write(el+" ");
        }
        
        public static void ColumnOut(int[] userArray)
        {
            foreach (var el in userArray)
                Console.WriteLine(el);
        }

        public static void FileOut(int[] userArray)
        {
            StreamWriter userArrayString = new StreamWriter("userArray.txt");

            foreach (var el in userArray)
                userArrayString.WriteLine(el.ToString());
            userArrayString.Close();
        }

        private static int SumCalculation(int[] userArray)
        {
            int sum = 0;
            foreach (var t in userArray)
                sum += t;
            return sum;
        }

        public static double AvgCalculation(int[] userArray)
        {
            return (double)SumCalculation(userArray)/userArray.Length;
        }
        public static void SwapMinMax(double[] arr)
        {
            int minIndex = 0;
            int maxIndex = 0;

            // Находим индексы минимального и максимального элементов
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < arr[minIndex])
                    minIndex = i;

                if (arr[i] > arr[maxIndex])
                    maxIndex = i;
            }
            // Обмениваем местами минимальный и максимальный элементы
            (arr[minIndex], arr[maxIndex]) = (arr[maxIndex], arr[minIndex]);
        }

        public static int GetElIndex(int[] userArray, int el)
        {
            int index = -1;
            for (int i = 0; i < userArray.Length; i++)
                if (userArray[i] == el)
                    index = i;
            return index;
        }
        
        public static int FindSecondLargest(double[] arr)
        {
            int minIndex = 0;
            int maxIndex = 0;

            // Находим индексы минимального и максимального элементов
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < arr[minIndex])
                    minIndex = i;

                if (arr[i] > arr[maxIndex])
                    maxIndex = i;
            }

            // Находим индекс второго по величине элемента
            int secondLargestIndex = minIndex;

            for (int i = 0; i < arr.Length; i++)
                if (arr[i] > arr[secondLargestIndex] && arr[i] < arr[maxIndex])
                    secondLargestIndex = i;

            return secondLargestIndex;
        }
        
        public static int MaxConsecutiveNumbers(int[] arr)
        {
            int maxCount = 0;
            int currentCount = 1;

            for (int i = 1; i < arr.Length; i++)
            {
                if ((arr[i] >= 0 && arr[i - 1] >= 0) || (arr[i] < 0 && arr[i - 1] < 0))
                    currentCount++;
                else
                {
                    if (currentCount > maxCount)
                        maxCount = currentCount;
                    currentCount = 1;
                }
            }

            if (currentCount > maxCount)
                maxCount = currentCount;
            return maxCount;
        }
        
        public static int SumBetweenNegatives(int[] arr)
        {
            int firstNegIndex = -1;
            int secondNegIndex = -1;
            
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < 0)
                {
                    if (firstNegIndex == -1)
                        firstNegIndex = i;
                    else
                    {
                        secondNegIndex = i;
                        break;
                    }
                }
            }
            
            if (firstNegIndex == -1 || secondNegIndex == -1)
                return 0;

            int sum = 0;
            
            for (int i = firstNegIndex + 1; i < secondNegIndex; i++)
                sum += arr[i];

            return sum;
        }
        
        public static int SumAfterLastZero(int[] arr)
        {
            int lastIndex = -1;
            
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                if (arr[i] == 0)
                {
                    lastIndex = i;
                    break;
                }
            }
            
            if (lastIndex == -1)
                return 0;

            int sum = 0;
            
            for (int i = lastIndex + 1; i < arr.Length; i++)
                sum += arr[i];

            return sum;
        }
    }
}