using System.Collections.Generic;
using static System.Console;
using static Day8Tasks.Tasks.Day8Class;

namespace Day8Tasks
{
    internal abstract class Program
    {
        public static void Main(string[] args)
        {
            
              // //1
              // string []s = ModernSplit("Мама и Маша ели Манную кашу на улице Маяковского", "Ма");
              // foreach (var i in s)
              //     WriteLine(i);
              //
              //
              // //2
              // string login = ReadLine();
              // WriteLine(CorrectLogin(login));
              //
              //
              // //3
              // WriteLine(ReplaceBadWords(ReadLine()));
              //
              //
              // //4
              // WriteLine(ReplaceNumbers(ReadLine()));
              //
              //
              // //5
              // WriteLine(ReplaceNumbersOnce(ReadLine()));
              //
              //
              // //6
              // string[] phones = ShowPhoneNumbers(ReadLine());
              // foreach (var i in phones)
              //     WriteLine(i);
              //
              //
              // //7
              // List<string> dates = GetDates(Console.ReadLine());
              // if (dates.Count != 0)
              //     foreach (var i in dates)
              //         WriteLine(i);
              //
              //
              //8
              Dictionary<string, string> userNumbers = ExtractNumbersWithNames(ReadLine());
              foreach (var i in userNumbers)
                  WriteLine(i.Key + ": " + i.Value);
              
        }
    }
}