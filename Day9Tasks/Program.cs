using static System.Console;
using static Day9Tasks.Tasks.Day9Class;

namespace Day9Tasks
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            //1
            WriteLine("Введите имя файла для вывода: ");
            ShowFile(ReadLine());
            
            
            //2
            Write("Введите количество чисел: ");
            int n = int.Parse(ReadLine() ?? string.Empty);

            int[] numbers = new int[n];
            for (int i = 0; i < n; i++)
            {
                Write($"Введите число {i + 1}: ");
                numbers[i] = int.Parse(ReadLine() ?? string.Empty);
            }

            Write("Введите имя файла: ");
            string fileName = ReadLine();
            
            RecFile(numbers, fileName);
            
            
            //3
            Write("Введите имя файла: ");
            SumFileElements(ReadLine());
            
            
            //4
            Write("Введите имя исходного файла: ");
            string inputFileName = ReadLine();

            Write("Введите имя файла для записи четных чисел: ");
            string evenFileName = ReadLine();

            Write("Введите имя файла для записи нечетных чисел: ");
            string oddFileName = ReadLine();
            
            CountNumbers(inputFileName, evenFileName, oddFileName);
            
            
            //5
            WriteLine("Введите имя файла: ");
            ShortFileLine(ReadLine());
            
            
            //6
            WriteLine("Введите имя файла (DeleteLastLine): ");
            DeleteLastLine(ReadLine());
            
            
            //7
            WriteLine("Введите имя файла");
            SortFileLines(ReadLine());
            
            
            //8
            WriteLine("Введите имя файла: ");
            string fileName8 = ReadLine();
            WriteLine("Что будем искать: ");
            string word = ReadLine();
            FindNumberInFile(fileName8, word);
            
            
            //9
            WriteLine("Введите имя файла: ");
            GiveFileMatrix(ReadLine());
            
            
            //10
            WriteLine("Введите имя файла: ");
            MostExpensiveItem("products.txt");
        }
    }
}