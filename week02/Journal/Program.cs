using System;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello World! This is the Journal Project.");

        Console.WriteLine("Welcome to your Journal");
        Console.WriteLine("What would you like to do?\n");

        // Initialize choice variable. -1 indicates I have yet to make a choice
        int choice = -1;

        // Create JournalDB object to hold my joural entries
        JournalDB myJournal = new JournalDB();
        // Create a JournalEntry object to hold my new journal entry
        JournalEntry newEntry = new JournalEntry();
        // Create GetPrompts object to get my random prompts
        GetPrompts getPrompts = new GetPrompts();

        // This initializes the _entries list in my JournalDB object. I learnd I have to do this here otherwise it overwrites the list when I add a new entry after loading from a file
        myJournal._entries = new List<JournalEntry>();

        // While loop for my menu system
        while (choice != 5)
        {
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display all entries");
            Console.WriteLine("3. Load Journal from file");
            Console.WriteLine("4. Save Journal to file");
            Console.WriteLine("5. Quit");

            Console.Write("Please enter your choice: ");
            string input = Console.ReadLine();
            choice = int.Parse(input); // Gets the user's choice and converts it from string to int

            // Beginning of my if else statement for the menu choices
            if (choice == 1)
            {
                // Get a random propt from GetPrompts class
                string prompt = getPrompts.GetRandomPrompt();

                Console.WriteLine(prompt);
                Console.Write(">>> :"); // I couldn't think of a better propmt
                string entry = Console.ReadLine();

                // Set the properties of my new journal entry (date, prompt, entry)
                newEntry._date = DateTime.Now.ToString("MM/dd/yyyy");
                newEntry._prompt = prompt;
                newEntry._entry = entry;

                // Add my new entry to the JournalDB
                myJournal._entries.Add(newEntry);

                // Display all my journal entries, mostly to confirm the new entry was added
                myJournal.DisplayJournal();
            }
            else if (choice == 2)
            {
                // Display all my journal entries
                myJournal.DisplayJournal();
            }
            else if (choice == 3)
            {
                // Load journal from file - user enters filename
                Console.Write("Enter the filename to load: ");
                string filename = Console.ReadLine();
                myJournal.LoadFromFile(filename);
            }
            else if (choice == 4)
            {
                // Save journal to file - user enters filename
                Console.Write("Enter the filename to save: ");
                string filename = Console.ReadLine();
                myJournal.SaveToFile(filename);
            }
        }
    }
}