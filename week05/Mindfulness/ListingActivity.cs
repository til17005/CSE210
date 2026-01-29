public class ListingActivity : Activity
{
    // Variable for count
    private int _count;

    // Create prompts list
    private List<string> _prompts = new List<string>()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    // ListingActivity costructor
    public ListingActivity(string name, string description) : base(name, description)
    {
        _name = name;
        _description = description;
    }

    // Method for getting a random prompt
    public void GetRandomPrompt()
    {
        // Generate a random index to select a random prompt from my _prompts list
        int randomIndex = new Random().Next(_prompts.Count);
        // Send the random prompt with the randomly generated index to the console
        Console.WriteLine($"--- {_prompts[randomIndex]} ---");

        // Entry for enhancement
        activityPrompts.Add(_prompts[randomIndex]);
        // -----------------------------------------
    }

    /* 
    public List<string> GetListFromUser()
    {
        return activityUserEntries;
    }
    */

    // Method for running the listing activity
    public void Run()
    {
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
        ShowCountDown(5);
        Console.Clear();

        DisplayStartingMessage();
        // Console.WriteLine($"Welcome to the {_name}.\n\n{_description}\n\n"); // for testing

        Console.Write("How long, in seconds, would you like for your session? ");
        string sessionDuration = Console.ReadLine();
        int duration = int.Parse(sessionDuration);
        setDuration(duration);

        Console.Clear();
        Console.WriteLine("Get Ready...");
        ShowSpinner(3);

        Console.WriteLine("List as many responses as you can to the following prompt:\n");
        GetRandomPrompt();

        Console.Write("\nYou may begin in:");
        ShowCountDown(4);
        Console.WriteLine();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        _count = 0;
        while (DateTime.Now < endTime)
        {
            string userInput = Console.ReadLine();

            // Entry for enhancement
            activityUserEntries.Add(userInput);
            // ---------------------------------

            _count++;
        }

        // Entries for enhancement
        string dateStamp = startTime.ToString();
        activity.Add(dateStamp);
        activity.Add(_name);
        activity.Add(_description);
        activity.Add(sessionDuration);
        //-----------------------------

        Console.WriteLine($"You listed {_count} items!\n\nWell done!!\n");
        ShowSpinner(4);
        DisplayEndingMessage();
        // Console.WriteLine($"\nYou have completed another {_duration} seconds of {_name}."); // for testing
        ShowSpinner(4);
        Console.Clear();
    }
}