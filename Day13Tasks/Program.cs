using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Day13Tasks.Tasks;
using static System.Console;

namespace Day13Tasks
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            List<Computer> computers = new List<Computer>();

            while (true)
            {
                WriteLine("\nChoose an action:");
                WriteLine("1. Create a list of computers with user-defined size and input data");
                WriteLine("2. Print the list of computers");
                WriteLine("3. Save the list to file (serialization)");
                WriteLine("4. Load the list from file (deserialization)");
                WriteLine("5. Sort the list by a field");
                WriteLine("6. Search for computers matching a criterion");
                WriteLine("7. Modify an object (user specifies object number and inputs new data)");
                WriteLine("0. Exit");

                int action = int.Parse(ReadLine() ?? string.Empty);

                switch (action)
                {
                    case 1:
                        WriteLine("Enter the size of the list:");
                        int size = int.Parse(ReadLine() ?? string.Empty);
                        for (int i = 0; i < size; i++)
                        {
                            WriteLine($"Enter data for computer #{i + 1}:");
                            Write("Model: ");
                            string model = ReadLine();
                            Write("RAM (GB): ");
                            int ram = int.Parse(ReadLine() ?? string.Empty);
                            computers.Add(new Computer(model, ram));
                        }

                        break;

                    case 2:
                        foreach (var c in computers)
                        {
                            c.PrintInfo();
                        }

                        break;

                    case 3:
                        using (FileStream fs = new FileStream("computers.bin", FileMode.Create))
                        {
                            BinaryFormatter formatter = new BinaryFormatter();
                            formatter.Serialize(fs, computers);
                        }

                        WriteLine("The list was saved to file.");
                        break;

                    case 4:
                        using (FileStream fs = new FileStream("computers.bin", FileMode.Open))
                        {
                            BinaryFormatter formatter = new BinaryFormatter();
                            computers = (List<Computer>)formatter.Deserialize(fs);
                        }

                        WriteLine("The list was loaded from file.");
                        break;

                    case 5:
                        WriteLine("Choose a field to sort by:");
                        WriteLine("1. Model");
                        WriteLine("2. RAM");
                        int field = int.Parse(ReadLine() ?? string.Empty);
                        switch (field)
                        {
                            case 1:
                                computers.Sort((c1, c2) =>
                                    String.Compare(c1.Model, c2.Model, StringComparison.Ordinal));
                                break;
                            case 2:
                                computers.Sort((c1, c2) => c1.Ram.CompareTo(c2.Ram));
                                break;
                        }

                        WriteLine("The list was sorted.");
                        break;

                    case 6:
                        WriteLine("Enter criterion:");
                        string searchCriteria = ReadLine();
                        List<Computer> searchResults = computers.FindAll(computer => searchCriteria != null && computer.Model.Contains(searchCriteria));
                        WriteLine($"Find ({searchResults.Count} objects):");
                        foreach (Computer computer in searchResults)
                        {
                            computer.PrintInfo();
                        }
                        break;
                    case 7:
                        WriteLine("Enter the number of the object you want to change:");
                        if (!int.TryParse(ReadLine(), out var index) || index < 0 || index > computers.Count)
                        {
                            WriteLine("Error: invalid input.");
                            continue;
                        }
                        WriteLine($"Enter new data for the object {index}:");
                        WriteLine("Model:");
                        string newModel = ReadLine();
                        WriteLine("Ram:");
                        int newRam = int.Parse(ReadLine() ?? string.Empty);
                        computers[index] = new Computer(newModel, newRam);
                        WriteLine("Successful Change");
                        break;
                }
                WriteLine("End of the program...");
            }
            // ReSharper disable once FunctionNeverReturns
        }
    }
}