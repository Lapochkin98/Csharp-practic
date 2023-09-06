using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Day7Tasks.Tasks
{
    public static class Day7Class
    {
        public static void CountCharacters(string str)
        {
            int numUpperCase = 0;
            int numLowerCase = 0;
            int numDigits = 0;
            int numWhiteSpace = 0;
            int numPunctuation = 0;

            foreach (char c in str)
            {
                if (char.IsUpper(c))
                {
                    numUpperCase++;
                }
                else if (char.IsLower(c))
                {
                    numLowerCase++;
                }
                else if (char.IsDigit(c))
                {
                    numDigits++;
                }
                else if (char.IsWhiteSpace(c))
                {
                    numWhiteSpace++;
                }
                else if (char.IsPunctuation(c))
                {
                    numPunctuation++;
                }
            }

            WriteLine($"Number of uppercase letters: {numUpperCase}");
            WriteLine($"Number of lowercase letters: {numLowerCase}");
            WriteLine($"Number of digits: {numDigits}");
            WriteLine($"Number of whitespace characters: {numWhiteSpace}");
            WriteLine($"Number of punctuation characters: {numPunctuation}");
        }
        
        public static void PrintCharCodes(string str)
        {
            foreach (char c in str)
            {
                WriteLine($"Символ: {c}. Код: {(int)c}");
            }
        }
        
        public static void PrintCharCodes(int[] arr)
        {
            foreach (int code in arr)
            {
                char c = (char) code;
                WriteLine($"Символ: {c}. Код: {code}");
            }
        }
        
        public static string GetOnlyCyrillicUppercase(string str)
        {
            string result = "";

            foreach (char c in str)
            {
                if (c >= 'А' && c <= 'Я')
                {
                    result += c;
                }
            }

            return result;
        }
        
        public static int CountDistinctCharacters(string str)
        {
            HashSet<char> distinctChars = new HashSet<char>(str);
            return distinctChars.Count;
        }
        
        public static int CountSubstringOccurrences(string str, string substr)
        {
            int count = 0;
            int index = 0;

            while ((index = str.IndexOf(substr, index, StringComparison.Ordinal)) != -1)
            {
                count++;
                index += substr.Length;
            }

            return count;
        }
        
        public static void FindShortestAndLongestWords(string str)
        {
            string[] words = str.Split(new[] {' ', ',', '.', '!', '?'}, StringSplitOptions.RemoveEmptyEntries);
            string shortest = words[0];
            string longest = words[0];

            foreach (string word in words)
            {
                if (word.Length < shortest.Length)
                {
                    shortest = word;
                }
                else if (word.Length > longest.Length)
                {
                    longest = word;
                }
            }

            Console.WriteLine($"Самое короткое слово: {shortest}");
            Console.WriteLine($"Самое длинное слово: {longest}");
        }
        
        public static string RemoveMiddleChars(string str)
        {
            int length = str.Length;
            int middleIndex = length / 2;

            if (length % 2 == 0)
            {
                return str.Remove(middleIndex - 1, 2);
            }
            else
            {
                return str.Remove(middleIndex, 1);
            }
        }
        
        public static string FindCharsBeforeColon(string str)
        {
            int colonIndex = str.IndexOf(':');
            if (colonIndex == -1)
            {
                return "";
            }
            else
            {
                return str.Substring(0, colonIndex);
            }
        }

        public static string ConvertInitials(string fullname)
        {
            string[] parts = fullname.Split(' ');
            string surname = parts[0];
            string initials = "";

            for (int i = 1; i < parts.Length; i++)
            {
                initials += parts[i][0] + ".";
            }

            string result = $"{surname} {initials}";
            return result;
        }
        
        public static bool IsIdentifier(string str)
        {
            if (!char.IsLetter(str[0]) && str[0] != '_')
            {
                return false;
            }
            
            for (int i = 1; i < str.Length; i++)
            {
                char c = str[i];
                if (!char.IsLetterOrDigit(c) && c != '_')
                {
                    return false;
                }
            }
            return true;
        }
        
        public static int[] ExtractNumbersFromString(ref string str)
        {
            List<int> numbers = new List<int>();
            int i = 0;
            while (i < str.Length)
            {
                if (char.IsDigit(str[i]))
                {
                    string numberString = string.Empty;
                    while (i < str.Length && char.IsDigit(str[i]))
                    {
                        numberString += str[i];
                        i++;
                    }
                    numbers.Add(int.Parse(numberString));
                    str = str.Remove(i - numberString.Length, numberString.Length);
                    i -= numberString.Length;
                }
                else
                {
                    i++;
                }
            }
            return numbers.ToArray();
        }
        
        public static bool CheckBrackets(string formula)
        {
            int count = 0;

            foreach (char c in formula)
            {
                if (c == '(')
                {
                    count++;
                }
                else if (c == ')')
                {
                    count--;
                }

                if (count < 0)
                {
                    return false;
                }
            }
            return count == 0;
        }
        
        public static string RemoveSingleLetterWords(string str)
        {
            string[] words = str.Split(new[] {' ', '\t', '\n', '\r'}, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder result = new StringBuilder();

            foreach (string word in words)
            {
                if (word.Length > 1)
                {
                    result.Append(word + " ");
                }
            }
            return result.ToString().TrimEnd();
        }
    }
}