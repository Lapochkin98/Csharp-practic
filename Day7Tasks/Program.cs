using static System.Console;
using static Day7Tasks.Tasks.Day7Class;

namespace Day7Tasks
{
    internal static class Program
    {
        public static void Main(string[] args)
        { 
             //1-1
             WriteLine("Введите вашу строку (подсчёт): ");
             CountCharacters(ReadLine());
            
            
             //2-1
             WriteLine("Введите вашу строку (код символа): ");
             PrintCharCodes(ReadLine());
            
            
             //3-1
             WriteLine("Введите кол-во чисел в массиве: ");
             int []arr = new[] { 1048,2,3,4,5};
             PrintCharCodes(arr);
            
            
             //4-1
             WriteLine("Введите вашу строку (прописные): ");
             GetOnlyCyrillicUppercase(ReadLine());
            
            
             //5-1
             WriteLine("Введите вашу строку (различные символы): ");
             CountDistinctCharacters(ReadLine());
            
            
             //1-2
             WriteLine("Введите строку, потом подстроку: ");
             WriteLine(CountSubstringOccurrences(ReadLine(), ReadLine()));
            
            
             //2-2
             WriteLine("Введите вашу строку (короткое и длинное слова): ");
             FindShortestAndLongestWords(ReadLine());
            
            
             //3-2
             WriteLine("Введите вашу строку (средняя буква)");
             WriteLine(RemoveMiddleChars(ReadLine()));
            
            
             //4-2
             WriteLine("Введите ваше строку (до двоеточия): ");
             WriteLine(FindCharsBeforeColon(ReadLine()));
            
            
             //5-2
             Write("Введите фамилию, имя и отчество: ");
             WriteLine(ConvertInitials(ReadLine()));
            
            
             //6-2
             WriteLine("Введите вашу строку (идентификатор): ");
             WriteLine(IsIdentifier(ReadLine()));
            
            
             //7-2
            string str = "da99ta 48 call 9 read13 blank0a78";
            int[] numbers = ExtractNumbersFromString(ref str);
            WriteLine("Числа: " + string.Join(", ", numbers));
            WriteLine("Строка без чисел: " + str);
            
            
            //8-2
            WriteLine("Введите вашу строку (формула): ");
            WriteLine(CheckBrackets(ReadLine()));
            
            
            //9-2
            WriteLine("Введите вашу строку: ");
            WriteLine(CountDistinctCharacters(ReadLine()));
            
            
            //10-2
            WriteLine(RemoveSingleLetterWords(ReadLine()));
        }
    }
}