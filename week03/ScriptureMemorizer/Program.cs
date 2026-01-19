using System;

class Program
{
    static void Main(string[] args)
    {
        // Clear the console to more easily read the scripture
        Console.Clear();

        // This creates my Scripture object
        Scripture myScripture = new Scripture();
        // Set the scrpture to memorize by loading it from a JSON file
        // This could be set to prompt the user for a file name or have many scripture files and select oce at random
        Scripture scripture = myScripture.LoadFromFile("Scripture.json");

        // Welcome user to the program and give some guidance
        Console.WriteLine("Welcome to Scripture Memorizer!");
        Console.WriteLine("Memorize the scripture by gradually hiding words. Let's get started!");
        Console.WriteLine("Here is your first scripture:\n");

        // Initial display of the scripture loaded from my JSON file
        Console.WriteLine(scripture.GetDisplayText());

        // Set my exit variable to control the quit option in my loop
        string exit = "";

        // My loop to hide words until the user types quit or all of the words are hidden 
        while (!scripture.IsCompletelyHidden())
        {
            Console.WriteLine("\nPress enter to continue or type 'quit' to finish:");
            // Get user response
            string input = Console.ReadLine();
            exit = input.ToLower();

            // If user response is quit, then break
            if (exit == "quit")
            {
                break;
            }

            // Clear the console - this is a bit fake as you can scroll up to see the prior text, but it does make it cleaner
            // I did discover a few ways to truely clear the console:
            // You could also print around 100 new lines that would push the prior text off the screen or 
            // Using ANSI Escape codes: Console.Write("\x1b[2J\x1b[3J\x1b[H"); -- This does work, and works well, but we were taught to use Console.Clear() - so I did
            // 2J clears the screen, 3J clears the scrollback buffer, and H moves the cursor to the home position (top-left corner) - xib is hex for ESC character
            Console.Clear();
            // Hide some words - in this case 5 words at a time will be hidden - you can adjust this as desired
            scripture.HideRandomWords(5);
            // Display the scripture with the hidden words
            Console.WriteLine(scripture.GetDisplayText());
        }

        Console.WriteLine("\nYou have hidden all the words or you quit. Good Bye!");
    }
}