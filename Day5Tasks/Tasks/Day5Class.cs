using System;

namespace Day5Tasks.Tasks
{
    public static class Day5Class
    {
        public static int Task3_max(int[] a)
        {
            int max = a[0];
            for (int i = 1; i < a.Length; ++i)
                if (a[i] > max)
                    max = a[i];
            return max;
        }

        public static int[] Task3_input()
        {
            Console.WriteLine("введите размерность массива");
            int n = int.Parse(Console.ReadLine() ?? string.Empty);
            int[] a = new int[n];
            for (int i = 0; i < n; ++i)
            {
                Console.Write("a[{0}]= ", i);
                a[i] = int.Parse(Console.ReadLine() ?? string.Empty);
            }

            return a;
        }

        public static void Task4(int[] array)
        {
            int maxIndex = 0;
            int minIndex = 0;

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > array[maxIndex])
                {
                    maxIndex = i;
                }

                if (array[i] <= array[minIndex])
                {
                    minIndex = i;
                }
            }

            if (maxIndex > minIndex)
            {
                Console.WriteLine("Максимальный элемент встречается позже минимального.");
                return;
            }

            int startIndex = maxIndex;
            int endIndex = minIndex;

            if (startIndex >= endIndex)
            {
                Console.WriteLine("Нет элементов между первым максимальным и последним минимальными элементами.");
                return;
            }

            int sum = 0;

            for (int i = startIndex; i <= endIndex; i++)
            {
                sum += array[i];
            }

            Console.WriteLine($"Сумма элементов между первым максимальным и последним минимальными элементами: {sum}");
        }

        public static int Task5(int [] a)
        {
            int temp = int.MaxValue;
            foreach (var t in a)
                if (t > 0)
                    if (t < temp)
                        temp = t;

            return temp;
        }
    }
}