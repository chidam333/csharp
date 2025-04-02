using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<string> items = new List<string>();
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Choose an option: add (1), remove (2), display (3), exit (4)");
            int command = int.Parse(Console.ReadLine().Trim());
            switch (command)
            {
                case 1:
                    Console.Write("String to be added : ");
                    string newItem = Console.ReadLine().Trim().ToUpper();
                    items.Add(newItem);
                    Console.WriteLine("Added.");
                    break;
                case 2:
                    Console.Write("String to be removed: ");
                    string removeItem = Console.ReadLine().Trim().ToUpper();
                    for (int i = 0; i < items.Count; i++)
                    {
                        if (items[i].Equals(removeItem.ToUpper()))
                        {
                            items.RemoveAt(i);
                            Console.WriteLine("Removed.");
                            break;
                        }
                    }
                    Console.WriteLine("Item not found.");
                    break;
                case 3:
                    Console.WriteLine("Items:");
                    foreach (var item in items)
                    {
                        Console.WriteLine(item.ToUpper()); // process string with a method
                    }
                    break;
                case 4:
                    exit = true;
                    break;
            }
        }
    }
}
