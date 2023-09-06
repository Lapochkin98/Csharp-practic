using System.Linq;
using static System.Console;
using static Day11Tasks.Tasks.Day11Class;

namespace Day11Tasks
{
    delegate void ErrorHandler();

    delegate void Func();

    static class Program
    {
        static void Main()
        {
            //1
            WriteLine("Введите выражение в формате \\число знак число\\");
            string input = ReadLine();
            if (input != null)
            {
                string[] expression = input.Split();
                ErrorHandler errorHandler;
                if (!double.TryParse(expression[0], out var a))
                {
                    errorHandler = NotANumber;
                    errorHandler += Terminate;
                    errorHandler.Invoke();
                    return;
                }
                if (!double.TryParse(expression[2], out var b))
                {
                    errorHandler = NotANumber;
                    errorHandler += Terminate;
                    errorHandler.Invoke();
                    return;
                }
                double result;
                switch (expression[1])
                {
                    case "+":
                        result = a + b;
                        break;
                    case "-":
                        result = a - b;
                        break;
                    case "*":
                        result = a * b;
                        break;
                    case "/":
                        if (b == 0)
                        {
                            errorHandler = DivisionByZero;
                            errorHandler += Terminate;
                            errorHandler.Invoke();
                            return;
                        }
                        result = a / b;
                        break;
                    default:
                        errorHandler = UnknownOperator;
                        errorHandler += Terminate;
                        errorHandler.Invoke();
                        return;
                }
                WriteLine($"Результат: {result}");
                
                
                //2
                double[] array = { 1.0, 2.0, 3.0, 4.0, 5.0 };
                Func function = null;

                while (true)
                {
                    WriteLine("Выберите функцию:");
                    WriteLine("1. Максимальный элемент");
                    WriteLine("2. Минимальный элемент");
                    WriteLine("3. Сумма элементов массива");
                    WriteLine("4. Среднее арифметическое элементов массива");
                    WriteLine("0. Выход");

                    int choice = int.Parse(ReadLine() ?? string.Empty);

                    switch (choice)
                    {
                        case 0:
                            function?.Invoke();
                            return;
                        case 1:
                            function += () => WriteLine($"Максимальный элемент: {array.Max()}");
                            break;
                        case 2:
                            function += () => WriteLine($"Минимальный элемент: {array.Min()}");
                            break;
                        case 3:
                            function += () => WriteLine($"Сумма элементов массива: {array.Sum()}");
                            break;
                        case 4:
                            function += () => WriteLine($"Среднее арифметическое элементов массива: {array.Average()}");
                            break;
                        default:
                            WriteLine("Ошибка: неверный ввод.");
                            break;
                    }
                }
            }
        }
    }
}