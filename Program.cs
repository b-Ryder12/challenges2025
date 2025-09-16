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
        Console.WriteLine(" 1 - 👋 Greetings");
        Console.WriteLine(" 2 - ➕ Numbers");
        Console.WriteLine(" 3 - ➕ Numbers (mults of 3 & 5)");
        Console.WriteLine(" 4 - 📚 Times Table");
        Console.WriteLine(" 5 - 🎲 Number Guesser");
        Console.WriteLine(" 6 - 🛒 Waitrose Rush");
        Console.WriteLine(" 0 - 🛑 Exit\n");
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
        // 6 - Waitrose Rush ###################################
        else if (programme == "6")
        {
            // Waitrose minigame
            PlayWaitroseRush();
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
    
    static void PlayWaitroseRush()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("=== Waitrose Rush — Premium Pack & Dash ===");
        Console.ResetColor();
        Console.WriteLine("Fulfil each customer's order quickly and accurately!");
        Console.WriteLine("Choose the COLOUR-CODED item number to pack it.");
        Console.WriteLine("Earn points for correct packing, lose points for mistakes.\n");
        Console.WriteLine("Press any key to begin...");
        Console.ReadKey(true);
        
        var rnd = new Random();
        var catalogue = new List<string>
        {
            "Sourdough loaf",
            "Organic full fat milk",
            "Scottish smoked salmon",
            "Waitrose No 1 dark chocolate",
            "Avocado",
            "British strawberries",
            "Artisan butter",
            "Alpine cheese wedge",
            "Extra virgin olive oil",
            "Mango chunks 250g",
            "Miso easy soup packets x6",
            "Orangina",
            "Maltesers share bag",
            "Snowballs",
            "Mini eggs",
            "Extra virgin olive oil hummous"
        };
        
        // Fun colours to pick from
        var colours = new List<ConsoleColor>
        {
            ConsoleColor.Green,
            ConsoleColor.Cyan,
            ConsoleColor.Magenta,
            ConsoleColor.Yellow,
            ConsoleColor.Blue,
            ConsoleColor.DarkRed,
            ConsoleColor.DarkCyan,
            ConsoleColor.DarkYellow
        };
        
        int score = 0;
        int rounds = 3;
        
        for (int round = 1; round <= rounds; round++)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Round {round}/{rounds}");
            Console.ResetColor();
            
            // Pick 4 random items for the order
            var order = catalogue.OrderBy(x => rnd.Next()).Take(4).ToList();
            
            Console.WriteLine("Customer order (pack in ANY order):\n");
            
            // Assign numbers & colours
            var itemColours = new Dictionary<int, (string Item, ConsoleColor Col)>();
            for (int i = 0; i < order.Count; i++)
            {
                var col = colours[rnd.Next(colours.Count)];
                itemColours[i + 1] = (order[i], col);
                
                Console.ForegroundColor = col;
                Console.WriteLine($"[{i + 1}] {order[i]}");
                Console.ResetColor();
            }
            
            var remaining = new HashSet<int>(itemColours.Keys);
            
            while (remaining.Any())
            {
                Console.Write("\nChoose item number to pack: ");
                string input = Console.ReadLine() ?? "";
                
                if (int.TryParse(input, out int choice) && remaining.Contains(choice))
                {
                    var (item, col) = itemColours[choice];
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Packed \"{item}\" ✅ +10 points");
                    Console.ResetColor();
                    score += 10;
                    remaining.Remove(choice);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Invalid choice ❌ -5 points");
                    Console.ResetColor();
                    score -= 5;
                }
            }
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nRound {round} complete! Current score: {score}\n");
            Console.ResetColor();
            Console.WriteLine("Press any key for the next round...");
            Console.ReadKey(true);
        }
        
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("=== Shift Summary ===");
        Console.ResetColor();
        Console.WriteLine($"Final score: {score}");
        
        if (score >= 100)
            Console.WriteLine("A+ — The boutique's favourite packer. Extra biscuits in the break room!");
        else if (score >= 70)
            Console.WriteLine("B — Solid shift, plenty of bonus coupons.");
        else if (score >= 40)
            Console.WriteLine("C — Some mistakes, but the salads survived.");
        else
            Console.WriteLine("D — Oh dear. The salads will remember this.");
            
        Console.WriteLine("\nPress any key to return to the main menu...");
        Console.ReadKey(true);
    }
}