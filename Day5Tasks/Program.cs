using System;
using System.Collections.Generic;
using Day5Tasks.Tasks;

namespace Day5Tasks
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Выберите номер задания: ");
            int task = int.Parse(Console.ReadLine() ?? string.Empty);

            switch (task)
            {
                case 1:
                {
                    int[] myArray = new int[10];
                    
                    for (int i = 0; i < 10; i++) myArray[i] = i * i;
                    for (int i = 0; i < 10; i++) Console.Write(myArray[i]+" ");

                    break;
                }
                case 2:
                {
                    int n = int.Parse(Console.ReadLine() ?? string.Empty);
                    int[] myArray = new int[n];
                    for (int i = 0; i < n; i++)
                        Console.Write(" "+myArray[i]);
                    
                    Console.WriteLine("\nНовый массив: ");
                    myArray = new int[n];
                    for (int i = 0; i < n; i++) 
                        Console.Write(" " + myArray[i]);

                    break;
                }
                case 3:
                {
                    int[] myArray=Day5Class.Task3_input(); 
                    int max= Day5Class.Task3_max(myArray); 
                    int kol=0;
                    foreach (var t in myArray)
                        if (t==max)
                            ++kol;

                    Console.WriteLine("Количество максимальных элементов = "+kol);

                    break;
                }
                case 4:
                {
                    int[] myArray=Day5Class.Task3_input();
                    Day5Class.Task4(myArray);
                    
                    break;
                }
                case 5:
                {
                    int[] myArray=Day5Class.Task3_input();
                    Console.WriteLine(Day5Class.Task5(myArray));
                    break;
                }
                case 6:
                {
                    int[] a = { 5, 8, 2, 5, 7, 1, 9, 8, 3, 6 };
                    int maxIndex = 0;
                    
                    for (int i = 1; i < a.Length; i++)
                    {
                        if (a[i] > a[maxIndex])
                        {
                            maxIndex = i;
                        }
                    }
                    List<int> b = new List<int>();
                    
                    for (int i = maxIndex + 1; i < a.Length; i++)
                    {
                        if (a[i] != a[maxIndex] && !b.Contains(a[i]))
                        {
                            b.Add(a[i]);
                        }
                    }
                    
                    Console.WriteLine("Массив B:");
                    foreach (int num in b)
                    {
                        Console.Write(num + " ");
                    }
                    break;
                }
            }
        }
    }
}