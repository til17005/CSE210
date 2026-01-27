public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts = new List<string>()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private List<string> userList = new List<string> { };

    public ListingActivity(string name, string description) : base(name, description)
    {
        _name = name;
        _description = description;
    }

    public void GetRandomPrompt()
    {
        // Generate a random index to select a random prompt from my _prompts list
        int randomIndex = new Random().Next(_prompts.Count);
        // Send the random prompt with the randomly generated index to the console
        Console.WriteLine($"--- {_prompts[randomIndex]} ---");
    }

    public List<string> GetListFromUser()
    {   
        return userList;
    }

    public void Run()
    {
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
        ShowCountDown(5);
        Console.Clear();

        Console.WriteLine($"Welcome to the {_name}.\n\n{_description}\n");

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
            userList.Add(userInput);
            _count++;
        }

        Console.WriteLine($"You listed {_count} items!\n\nWell done!!\n");
        ShowSpinner(4);
        Console.WriteLine($"\nYou have completed another {_duration} seconds of {_name}.");
        ShowSpinner(4);
        Console.Clear();

        /*
        Console.WriteLine("\n\n\n");
        foreach (string listing in userList)
        {
            Console.WriteLine(listing);
        }
        ShowSpinner(10);
        */
    }
}