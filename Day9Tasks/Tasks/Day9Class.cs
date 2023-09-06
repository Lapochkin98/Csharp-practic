using System;
using System.IO;
using System.Linq;
using static System.Console;

namespace Day9Tasks.Tasks
{
    public static class Day9Class
    {
        public static void ShowFile(string fileName)
        {
            try
            {
                string text = File.ReadAllText(fileName);
                WriteLine(text);
            }
            catch (FileNotFoundException)
            {
                WriteLine($"Файл с именем {fileName} не найден.");
            }
            catch (Exception ex)
            {
                WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }

        public static void RecFile(int[] numbers, string fileName)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(fileName))
                {
                    foreach (int number in numbers)
                    {
                        sw.WriteLine(number);
                    }
                }

                WriteLine($"Числа успешно записаны в файл {fileName}.");
            }
            catch (Exception ex)
            {
                WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }

        public static void SumFileElements(string fileName)
        {
            try
            {
                int sum = 0;
                using (StreamReader sr = new StreamReader(fileName))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (int.TryParse(line, out int number))
                        {
                            sum += number;
                        }
                    }
                }

                using (StreamWriter sw = File.AppendText(fileName))
                {
                    sw.WriteLine($"Сумма чисел в файле: {sum}");
                }

                WriteLine($"Сумма чисел записана в файл {fileName}.");
            }
            catch (FileNotFoundException)
            {
                WriteLine($"Файл с именем {fileName} не найден.");
            }
            catch (Exception ex)
            {
                WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }

        public static void CountNumbers(string inputFileName, string evenFileName, string oddFileName)
        {
            try
            {
                using (StreamReader sr = new StreamReader(inputFileName))
                using (StreamWriter evenSw = new StreamWriter(evenFileName))
                using (StreamWriter oddSw = new StreamWriter(oddFileName))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (int.TryParse(line, out int number))
                        {
                            if (number % 2 == 0)
                            {
                                evenSw.WriteLine(number);
                            }
                            else
                            {
                                oddSw.WriteLine(number);
                            }
                        }
                    }
                }

                WriteLine($"Четные числа записаны в файл {evenFileName}, а нечетные числа записаны в файл {oddFileName}.");
            }
            catch (FileNotFoundException)
            {
                WriteLine($"Файл с именем {inputFileName} не найден.");
            }
            catch (Exception ex)
            {
                WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }

        public static void ShortFileLine(string fileName)
        {
            try
            {
                string shortestLine = null;
                using (StreamReader sr = new StreamReader(fileName))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (shortestLine == null || line.Length < shortestLine.Length)
                        {
                            shortestLine = line;
                        }
                    }
                }

                WriteLine($"Самая короткая строка в файле: {shortestLine}");
            }
            catch (FileNotFoundException)
            {
                WriteLine($"Файл с именем {fileName} не найден.");
            }
            catch (Exception ex)
            {
                WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }

        public static void DeleteLastLine(string fileName)
        {
            try
            {
                string[] lines = File.ReadAllLines(fileName);
                if (lines.Length == 0)
                {
                    WriteLine("Файл пуст.");
                    return;
                }

                Array.Resize(ref lines, lines.Length - 1);

                File.WriteAllLines(fileName, lines);

                WriteLine($"Последняя строка файла {fileName} успешно удалена.");
            }
            catch (FileNotFoundException)
            {
                WriteLine($"Файл с именем {fileName} не найден.");
            }
            catch (Exception ex)
            {
                WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }

        public static void SortFileLines(string fileName)
        {
            try
            {
                string[] lines = File.ReadAllLines(fileName);
                Array.Sort(lines);

                File.WriteAllLines(fileName, lines);

                WriteLine($"Строки в {fileName} были отсортированы по алфавиту.");
            }
            catch (FileNotFoundException)
            {
                WriteLine($"Файл с именем {fileName} не найден.");
            }
            catch (Exception ex)
            {
                WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }

        public static void FindNumberInFile(string fileName, string word)
        {
            try
            {
                int count = 0;
                using (StreamReader sr = new StreamReader(fileName))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        count += line.Split(new[] { ' ', '.', ',', '!', '?', ':', ';'}, StringSplitOptions.RemoveEmptyEntries).Count(w => w.Equals(word, StringComparison.OrdinalIgnoreCase));
                    }
                }

                WriteLine($"Слово \\{word}\\ встречается в файле {count} раз(а).");
            }
            catch (FileNotFoundException)
            {
                WriteLine($"Файл с именем {fileName} не найден.");
            }
            catch (Exception ex)
            {
                WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }

        public static void GiveFileMatrix(string fileName)
        {
            Write("Введите к-во строк: ");
            int rows = int.Parse(ReadLine() ?? string.Empty);

            Write("Введите к-во столбцов: ");
            int columns = int.Parse(ReadLine() ?? string.Empty);

            int[,] matrix = new int[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                WriteLine($"Введите элементы строки {i + 1} (separated by spaces): ");
                string[] input = ReadLine()?.Split(' ');

                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = int.Parse(input?[j] ?? throw new InvalidOperationException());
                }
            }

            using (StreamWriter sw = new StreamWriter(fileName))
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        sw.Write($"{matrix[i, j]} ");
                    }
                    sw.WriteLine();
                }
            }

            WriteLine($"Матрица была записана в файл {fileName}.");
        }

        public static void MostExpensiveItem(string fileName)
        {
            try
            {
                string mostExpensiveProduct = null;
                decimal highestPrice = decimal.MinValue;
                using (StreamReader sr = new StreamReader(fileName))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (parts.Length != 2)
                        {
                            WriteLine($"Неверный формат строки: {line}");
                            continue;
                        }

                        if (decimal.TryParse(parts[1], out decimal price) && price > highestPrice)
                        {
                            highestPrice = price;
                            mostExpensiveProduct = parts[0];
                        }
                    }
                }

                WriteLine(mostExpensiveProduct == null
                    ? "Файл пуст или содержит неверный формат данных."
                    : $"Самый дорогой товар: {mostExpensiveProduct} ({highestPrice:C}).");
            }
            catch (FileNotFoundException)
            {
                WriteLine($"Файл с именем {fileName} не найден.");
            }
            catch (Exception ex)
            {
                WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
    }
}