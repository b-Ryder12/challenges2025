using System;
using System.Collections.Generic;
using System.Numerics; // for BigInteger if needed

class Program
{
    static void Main()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("");
        Console.WriteLine("══════════════════════════════════════════════");
        Console.WriteLine("   🐺 Welcome to the Super Sigma Console 🐺");
        Console.WriteLine("══════════════════════════════════════════════\n");
        Console.ResetColor();
        
        Console.WriteLine("Select programme:\n");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(" 1 - Greet user");
        Console.WriteLine(" 2 - Add numbers");
        Console.WriteLine(" 3 - Add numbers (mults of 3 & 5)");
        Console.WriteLine(" 4 - Times Table");
        Console.WriteLine(" 5 - Nunmber Guesser");
        Console.WriteLine(" 0 - Exit\n");
        Console.ResetColor();
        
        var programme = Console.ReadLine();
        var currentDate = DateTime.Now;
        string output = string.Empty; // shared variable for output
        
        // 1 - greet user #####################################
        if (programme == "1")
        {
            Console.Write("What is your name? ");
            var name = Console.ReadLine();

            if ((name == "Benjamin") || (name == "Mark") || (name == "Evie-May"))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                output = $"✨ Hello, {name}, on {currentDate:d} at {currentDate:t}! ✨";
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                output = $"🤨 Who the heck are you, {name}, on {currentDate:d} at {currentDate:t}?";
            }
        }
        // 2 or 3 - add or multiply numbers ###################
        else if (programme == "2" || programme == "3")
        {
            Console.Write("Pick a number: ");
            if (int.TryParse(Console.ReadLine(), out int number))
            {
                // Build the list of numbers
                List<int> numbers = new List<int>();
                for (int i = 1; i <= number; i++)
                {
                    if (programme == "2" || (i % 3 == 0 || i % 5 == 0))
                    {
                        numbers.Add(i);
                    }
                }

                Console.WriteLine("\nWould you like to:");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" + (A)dd them up");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" × (M)ultiply them");
                Console.ResetColor();

                var choice = Console.ReadLine()?.Trim().ToUpper();

                if (choice == "M")
                {
                    BigInteger product = 1;
                    foreach (var n in numbers)
                    {
                        product *= n;
                    }
                    Console.ForegroundColor = ConsoleColor.Red;
                    output = $"🔥 The product of numbers up to {number}{(programme == "3" ? " (divisible by 3 or 5)" : "")} is {product}, calculated on {currentDate:d} at {currentDate:t}.";
                }
                else
                {
                    int sum = 0;
                    foreach (var n in numbers)
                    {
                        sum += n;
                    }
                    string list = string.Join(" + ", numbers);
                    Console.ForegroundColor = ConsoleColor.Green;
                    output = $"➕ {list} = {sum}\n✨ Calculated on {currentDate:d} at {currentDate:t}.";
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                output = "⚠️ That wasn't a valid number!";
            }
        }
        // 4 - times tables ###################################
        else if (programme == "4")
        {
            Console.Write("Select print:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n 1 - Deatiled list\n 2 - Compact list");
            Console.ResetColor();
            Console.WriteLine("\nYour choice: ");
            var list = Console.ReadLine();

            if (list == "1")
            {
                for (int i = 1; i <= 12; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"\nTimes Table for {i}:");
                    Console.ResetColor();
                    for (int j = 1; j <= 12; j++)
                    {
                        Console.WriteLine($"{i} × {j} = {i * j}");
                    }
                }
            }
            else if (list == "2")
            {
                Console.WriteLine($"\nTimes Tables:");
                for (int i = 1; i <= 12; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.ResetColor();
                    Console.WriteLine("");

                    for (int j = 1; j <= 12; j++)
                    {
                        Console.Write($"|{i * j,3}");
                    }
                }
            }
        }
        // 5 - number guesser ###################################
        else if (programme == "5")
        {
            int rando = new Random().Next(1, 1001);
            int guess = 0;
            int attempts = 0;
            Console.WriteLine("\nI'm thinking of a number between 1 and 1000. Can you guess it?");
            while (guess != rando)
            {
                Console.ResetColor();
                Console.Write("Your guess: ");
                if (int.TryParse(Console.ReadLine(), out guess))
                {
                    attempts++;
                    if (guess < rando)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nToo low! Try again.");
                    }
                    else if (guess > rando)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nToo high! Try again.");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        output = $"🎉 Correct! The number was {rando}. You guessed it in {attempts} attempts on {currentDate:d} at {currentDate:t}.";
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("⚠️ Please enter a valid number.");
                }
            }
        }
        // 0 - exit ###########################################
        else if (programme == "0")
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            output = "👋 Exiting programme. Goodbye!";
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            output = $"❓ Huh? Invalid choice — on {currentDate:d} at {currentDate:t}!";
        }
        
        Console.WriteLine($"\n{output}");
        Console.ResetColor();
        
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write("\nPress Enter ⏎ to restart...");
        Console.ResetColor();
        Console.ReadLine();
        Main(); // restart the programme
    }
}