using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using static System.Console;

namespace Day8Tasks.Tasks
{
    public static class Day8Class
    {
        public static string[] ModernSplit(string s, string userSplit)
        {
            string m = $"{userSplit}";
            return Regex.Split(s, m);
        }
        
        public static bool CorrectLogin(string str)
        {
            if (str.Length < 2 || str.Length > 10)
                return false;
            if (!char.IsLetter(str[0]))
                return false;
            var regex = new Regex(@"^[a-zA-Z0-9]+$");
            if (!regex.IsMatch(str))
                return false;
            return true;
        }

        public static string ReplaceBadWords(string str)
        {
            string[] badWords = { "мат", "матерный", "матерное", "матерных", "матерными", "МАТ", "Мат" };
            string pattern = string.Join("|", badWords);
            return Regex.Replace(str, pattern, "цензура", RegexOptions.IgnoreCase);
        }

        public static string ReplaceNumbers(string str)
        {
            return Regex.Replace(str, @"\d", "*");
        }

        public static string ReplaceNumbersOnce(string str)
        {
            return Regex.Replace(str, @"\d+", "*");
        }

        public static string[] ShowPhoneNumbers(string s)
        {
            var regex = new Regex(@"\b\d{3}-\d{2}-\d{2}\b");
            var matches = regex.Matches(s);
            
            string[] phoneNumbers = new string[matches.Count];
            for (int i = 0; i < matches.Count; i++)
                phoneNumbers[i] = matches[i].Value;
            return phoneNumbers;
        }
        
        public static List<string> GetDates(string str)
        {
            List<string> dates = new List<string>();
            Regex regex = new Regex(@"\\d{2}\\.\\d{2}\\.\\d{4}");
            MatchCollection matches = regex.Matches(str);

            foreach (Match match in matches)
            {
                if (DateTime.TryParse(match.Value, out DateTime date))
                {
                    dates.Add(date.ToString(CultureInfo.InvariantCulture));
                }
            }
            return dates;
        }
        
        public static Dictionary<string, string> ExtractNumbersWithNames(string str)
        {
            Dictionary<string, string> numbersWithNames = new Dictionary<string, string>();
            Regex regex = new Regex(@"(?<number>[0-9]{4} [А-Яa-zA-Z]{2}-[1-7]{1}) (?<name>[А-Я][а-я]+\\s[А-Я]\\.\\s[А-Я]\\.)");
            MatchCollection matches = regex.Matches(str);
            WriteLine(matches.Count);
            foreach (Match match in matches)
            {
                string number = match.Groups["number"].Value;
                string name = match.Groups["name"].Value;
                numbersWithNames.Add(number, name);
            }

            return numbersWithNames;
        }
    }
}