public class Activity : UserClass
{
    // Variables for activity name, description of the activity, and the duration of the activity
    protected string _name;
    protected string _description;
    protected int _duration;

    // Entries for enhancement
    // List(s) containing the session info for the activities the user is doing
    protected List<string> activity = new List<string> { };
    protected List<string> activityPrompts = new List<string> { };
    protected List<string> activityQuestions = new List<string> { };
    protected List<string> activityUserEntries = new List<string> { };
    // -----------------------------------------------------------------

    // Getters and setters
    public void setDuration(int duration)
    {
        _duration = duration;
    }

    public int getDuration()
    {
        return _duration;
    }

    public List<string> getActivity()
    {
        return activity;
    }

    public List<string> getActivityPrompts()
    {
        return activityPrompts;
    }

    public List<string> getActivityQuestions()
    {
        return activityQuestions;
    }

    public List<string> getActivityUserEntries()
    {
        return activityUserEntries;
    }

    // Activity constructor
    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    // Method to display the starting message within the other classes
    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Welcome to the {_name} Activity.\n\n");
        Console.WriteLine($"{_description}\n");
    }

    // Method to display the ending message within the other classes
    public void DisplayEndingMessage()
    {
        Console.WriteLine($"You have completed {_duration} seconds of the {_name} Activity.\n\n");
    }

    // Method for showing the animated spinner
    public void ShowSpinner(int spinTime)
    {
        // I don't mind saying the curor was buggin me badly. I had to find a way to hide it.
        Console.CursorVisible = false;

        // Create a new date time and ending time so it knows when to stop
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(spinTime);

        // I use a list for the spinner to iterate
        List<string> characters = new List<string> { "|", "/", "-", "\\" };

        int i = 0;
        // Loop for the time it should spin
        while (DateTime.Now < endTime)
        {
            // Iterate through the characters
            string currentChar = characters[i];
            Console.Write(currentChar);
            Thread.Sleep(75);
            // Clears the previous charachter and returns to the proper location
            Console.Write("\b \b");

            i++;

            // This will reset i if the spinner runs through (iterates) all characters
            if (i >= characters.Count)
            {
                i = 0;
            }
        }

        // Returs the cursor to visible
        Console.CursorVisible = true;
    }

    // Method for counting down
    public void ShowCountDown(int countTime)
    {
        // Create a new list then add numbers to the list (backwards) from the number in countTime
        List<string> numbers = new List<string>();
        for (int i = countTime; i >= 1; i--)
        {
            numbers.Add(i.ToString());
        }

        // Make the console cursor disapear
        Console.CursorVisible = false;

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(countTime);

        // Used j so it doesn't conflict with i above
        int j = 0;
        while (DateTime.Now < endTime)
        {
            // Iterate the list of numbers
            string currentNum = numbers[j];
            Console.Write(currentNum);
            Thread.Sleep(1000);
            Console.Write("\b \b");

            j++;

            // Resest if you run out of numbers. This should never happen, but I left it for other uses in the future. I don't know what they are yet :)
            if (j >= numbers.Count)
            {
                j = 0;
            }
        }

        // Make the cusor show again
        Console.CursorVisible = true;
    }
}