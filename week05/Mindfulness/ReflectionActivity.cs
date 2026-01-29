public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity(string name, string description) : base(name, description)
    {
        _name = name;
        _description = description;
    }

    public string GetRandomPrompt()
    {
        // Generate a random index to select a random prompt from my _prompts list
        int randomIndex = new Random().Next(_prompts.Count);
        // Return the random prompt with the randomly generated index
        return _prompts[randomIndex];
    }

    public string GetRandomQuestion()
    {
        // Generate a random index to select a random prompt from my _questions list
        int randomIndex = new Random().Next(_questions.Count);
        // Return the random question with the randomly generated index
        return _questions[randomIndex];
    }

    public void DisplayPrompt()
    {
        string getPrompt = GetRandomPrompt();
        Console.WriteLine($"--- {getPrompt} ---");

        // Entry for enhancement
        activityPrompts.Add(getPrompt);
        // -----------------------------
    }

    public void DisplayQuestion()
    {
        string getQuestion = GetRandomQuestion();
        Console.Write($">>> {getQuestion}  ");
        activityQuestions.Add(getQuestion);
    }

    public void Run()
    {
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
        ShowCountDown(5);
        Console.Clear();

        Console.WriteLine($"Welcome to the {_name}.\n\n{_description}\n\n");

        Console.Write("How long, in seconds, would you like for your session? ");
        string sessionDuration = Console.ReadLine();
        int duration = int.Parse(sessionDuration);
        setDuration(duration);

        // I had the while loop starting here, but I thought the time to reflect on the prompt shouldn't be counted toward the total time.
        Console.WriteLine("Consider the following prompt:\n");
        ShowSpinner(2);
        DisplayPrompt();

        Console.WriteLine("\nWhen you have something in mind, press enter to continue.");
        Console.ReadLine();

        Console.Write("Now ponder on each of the following questions as they related to this experience.\nYou may begin in:");
        ShowCountDown(6);
        Console.Clear();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            DisplayQuestion();
            ShowSpinner(10);
            Console.WriteLine();
        }

        // Entries for enhancement
        string dateStamp = startTime.ToString();
        activity.Add(dateStamp);
        activity.Add(_name);
        activity.Add(_description);
        activity.Add(sessionDuration);
        //-----------------------------

        Console.Clear();
        Console.WriteLine("Well done!!");
        ShowSpinner(4);
        Console.WriteLine($"\nYou have completed another {_duration} seconds of {_name}.");
        ShowSpinner(4);
        Console.Clear();
    }
}