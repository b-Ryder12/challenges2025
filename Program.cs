using System;
using System.Collections.Generic;
using System.Numerics;

class Program
{
    static void Main()
    {
        Console.Clear();
        
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("");
        Console.WriteLine("══════════════════════════════════════════════");
        Console.WriteLine("   🐺 Welcome to the Super Sigma Console 🐺");
        Console.WriteLine("══════════════════════════════════════════════\n");
        Console.ResetColor();
        
        Console.WriteLine("Select programme:\n");
        
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("  ༺ ~                                    ~ ༻");
        Console.Write("  ꒰");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("1 - 👋 Greetings");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("                       ꒱");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("    2 - ➕ Numbers");
        Console.WriteLine("    3 - ➕ Numbers (mults of 3 & 5)");
        Console.WriteLine("    4 - 📚 Times Table");
        Console.WriteLine("    5 - 🎲 Number Guesser");
        Console.WriteLine("    6 - 🛒 Waitrose Rush");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("  ꒰");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("0 - 🛑 Exit");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("                            ꒱");
        Console.WriteLine("  ༺ ~                                    ~ ༻\n");
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
        Console.WriteLine("╔═══════════════════════════════════════════╗");
        Console.Write("║"); Console.ForegroundColor = ConsoleColor.White;
        Console.Write("            🛒 Waitrose Rush 🛒            ");
        Console.ForegroundColor = ConsoleColor.DarkGreen; Console.WriteLine("║");
        Console.Write("║"); Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("         ✨ Premium Pack & Dash ✨         ");
        Console.ForegroundColor = ConsoleColor.DarkGreen; Console.WriteLine("║");
        Console.WriteLine("╚═══════════════════════════════════════════╝");
        Console.ResetColor();
        
        Console.WriteLine("\nFulfil each customer's order quickly and accurately!");
        Console.WriteLine("⚠️ Beware: cursed RED items lose points!");
        Console.WriteLine("✅ Correct packs give points, streaks give bonuses!");
        Console.WriteLine("\nPress any key to begin...");
        Console.ReadKey(true);
        
        var rnd = new Random();
        
        // Fixed Waitrose-esque brand colours
        var baseColours = new Dictionary<string, ConsoleColor>(StringComparer.OrdinalIgnoreCase)
        {
            { "Sourdough loaf", ConsoleColor.DarkYellow },
            { "Organic full fat milk", ConsoleColor.White },
            { "Scottish smoked salmon", ConsoleColor.DarkRed },
            { "Waitrose No 1 dark chocolate", ConsoleColor.DarkMagenta },
            { "Avocado", ConsoleColor.Green },
            { "British strawberries", ConsoleColor.Magenta },
            { "Artisan butter", ConsoleColor.Yellow },
            { "Alpine cheese wedge", ConsoleColor.DarkCyan },
            { "Extra virgin olive oil", ConsoleColor.DarkGreen },
            { "Mango chunks 250g", ConsoleColor.Yellow },
            { "Miso easy soup packets x6", ConsoleColor.Magenta },
            { "Orangina", ConsoleColor.DarkBlue },
            { "Maltesers share bag", ConsoleColor.DarkRed },
            { "Snowballs", ConsoleColor.White },
            { "Mini eggs", ConsoleColor.DarkYellow },
            { "Extra virgin olive oil hummous", ConsoleColor.Green }
        };
        
        var catalogue = baseColours.Keys.ToList();
        
        int score = 0;
        int streak = 0;
        int rounds = 3;
        
        for (int round = 1; round <= rounds; round++)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"╔═══════════════════════════════════╗");
            Console.WriteLine($"║          🛒 ROUND {round}/{rounds} 🛒          ║");
            Console.WriteLine($"╚═══════════════════════════════════╝");
            Console.ResetColor();
            
            // Pick 4 random items
            var order = catalogue.OrderBy(x => rnd.Next()).Take(4).ToList();
            
            // Randomly curse 1 item red
            string cursedItem = order[rnd.Next(order.Count)];
            
            Console.WriteLine("You have 10 seconds!");
            Console.WriteLine("Customer order (pack in any order):\n");
            
            // Generate 4 random distinct numbers for labelling items
            var numberPool = Enumerable.Range(1, 20).OrderBy(x => rnd.Next()).Take(order.Count).ToList();
            
            // Assign item numbers
            var itemMap = new Dictionary<int, string>();
            for (int i = 0; i < order.Count; i++)
            {
                string item = order[i];
                int num = numberPool[i]; // random number
                ConsoleColor col = (item == cursedItem) ? ConsoleColor.Red : baseColours[item];
                itemMap[num] = item;
                
                // Stylised item row
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("   [");
                Console.ResetColor();
                
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(num.ToString("D2")); // two-digit number
                Console.ResetColor();
                
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("] ");
                Console.ResetColor();
                
                Console.ForegroundColor = col;
                Console.WriteLine(item);
                Console.ResetColor();
                
                Console.WriteLine(); // extra spacing between items
            }
            
            // --- Timer display helper ---
            static void ShowTimer(TimeSpan totalTime, DateTime startTime, int barWidth, int line, CancellationToken token)
            {
                while (!token.IsCancellationRequested)
                {
                    var elapsed = DateTime.Now - startTime;
                    var remaining = totalTime - elapsed;
                    if (remaining < TimeSpan.Zero) remaining = TimeSpan.Zero;
                    
                    double fraction = remaining.TotalSeconds / totalTime.TotalSeconds;
                    int filledBlocks = (int)Math.Round(fraction * barWidth);
                    int emptyBlocks = barWidth - filledBlocks;
                    
                    string bar = "[" + new string('█', filledBlocks) + new string('░', emptyBlocks) + $"] {remaining.Seconds}s ";
                    
                    // overwrite timer line
                    Console.SetCursorPosition(0, line);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(bar.PadRight(barWidth + 20));
                    Console.ResetColor();
                    
                    Thread.Sleep(200);
                }
            }
            
            // remaining non-cursed items
            var remaining = new HashSet<int>(itemMap
                .Where(kvp => kvp.Value != cursedItem)
                .Select(kvp => kvp.Key));
            
            var roundTime = TimeSpan.FromSeconds(10);
            var roundStart = DateTime.Now;
            
            // reserve input line (no prompt text yet)
            int inputLine = Console.CursorTop;
            Console.WriteLine(); // leave blank for input
            int timerLine = Console.CursorTop;
            Console.WriteLine(); // leave blank for timer
            
            // start timer thread
            var cts = new CancellationTokenSource();
            Task.Run(() => ShowTimer(roundTime, roundStart, 20, timerLine, cts.Token));
            
            string lastInput = "";
            
            // packing loop
            while (remaining.Any() && DateTime.Now - roundStart < roundTime)
            {
                // redraw input line
                Console.SetCursorPosition(0, inputLine);
                Console.Write(new string(' ', Console.BufferWidth));
                Console.SetCursorPosition(0, inputLine);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"Choose item number to pack: {lastInput}");
                Console.ResetColor();
                
                // move cursor after the prompt for fresh input
                Console.SetCursorPosition("Choose item number to pack: ".Length + lastInput.Length, inputLine);
                
                string? input = Console.ReadLine();
                Console.WriteLine(); // push messages below timer
                lastInput = input ?? "";
                
                if (int.TryParse(input, out int choice) && itemMap.ContainsKey(choice))
                {
                    string item = itemMap[choice];
                    
                    if (item == cursedItem)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Oh no! The {item} was cursed RED ❌ -10 points");
                        Console.ResetColor();
                        score -= 40;
                        streak = 0;
                        // ❌ Do NOT remove cursed item from remaining
                    }
                    else if (remaining.Contains(choice))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        int bonus = 10 + streak * 2;
                        Console.WriteLine($" 🛍️  Packed {item} ✅ +{bonus} points");
                        Console.ResetColor();
                        score += bonus;
                        streak++;
                        remaining.Remove(choice); // ✅ Only remove safe items
                        
                        if (streak > 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($" 🔥 Streak x{streak}! Bonus active!");
                            Console.ResetColor();
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($" 😬 Already packed {item}!");
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Invalid choice ❌ -5 points");
                    Console.ResetColor();
                    score -= 5;
                }
            }
            
            // stop timer
            cts.Cancel();
            
            // Missed items penalty
            foreach (var miss in remaining)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"⏰ Missed {itemMap[miss]}! -5 points");
                Console.ResetColor();
                score -= 5;
            }
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n🏁 Round {round} complete! Current score: {score}\n");
            Console.ResetColor();
            Console.WriteLine("Press any key to begin next round...");
            Console.ReadKey(true);
        }
        
        Console.Clear();
        
        // build box width and content dynamically
        int boxWidth = 52;
        string title = "🛒 SHIFT SUMMARY 🛒";
        string scoreLine = $"Final score: {score}";
        string rankLine;
        
        // choose rank message & colour
        if (score >= 120)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            rankLine = "🏆 A+ — Boutique’s favourite packer!";
        }
        else if (score >= 80)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            rankLine = "🥈 B — Solid shift, plenty of bonus coupons.";
        }
        else if (score >= 40)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            rankLine = "🥉 C — Some mistakes, but the salads survived.";
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            rankLine = "💩 D — Oh dear. The salads will remember this...";
        }
        
        // top border
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("╔" + new string('═', boxWidth - 2) + "╗");
        
        // title row
        string titlePadded = title.PadLeft((boxWidth - title.Length) / 2 + title.Length).PadRight(boxWidth - 2);
        Console.WriteLine($"║{titlePadded}║");
        
        // separator
        Console.WriteLine("╠" + new string('═', boxWidth - 2) + "╣");
        
        // score row
        Console.ResetColor();
        string scorePadded = scoreLine.PadRight(boxWidth - 3);
        Console.WriteLine($"║ {scorePadded}║");
        
        // rank row
        string rankPadded = rankLine.PadRight(boxWidth - 3); // account for emoji width
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"║ {rankPadded}║");
        
        // bottom border
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("╚" + new string('═', boxWidth - 2) + "╝");
        
        Console.ResetColor();
        Console.WriteLine("\nPress any key to return to the main menu...");
        Console.ReadKey(true);
    }
}