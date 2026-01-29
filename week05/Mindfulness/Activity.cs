public class Activity : UserClass
{
    protected string _name;
    protected string _description;
    protected int _duration;

    // Entries for enhancement
    protected List<string> activity = new List<string> { };
    protected List<string> activityPrompts = new List<string> { };
    protected List<string> activityQuestions = new List<string> { };
    protected List<string> activityUserEntries = new List<string> { };
    // -----------------------------------------------------------------

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

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Welcome to the {_name} Activity.");
        Console.WriteLine($"{_description}\n");
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine($"You have completed {_duration} seconds of the {_name} Activity.\n");
    }

    public void ShowSpinner(int spinTime)
    {
        // I don't mind saying the curor was buggin me badly. I had to find a way to hide it.
        Console.CursorVisible = false;

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(spinTime);

        List<string> characters = new List<string> { "|", "/", "-", "\\" };

        int i = 0;
        while (DateTime.Now < endTime)
        {

            string currentChar = characters[i];
            Console.Write(currentChar);
            Thread.Sleep(75);
            Console.Write("\b \b");

            i++;

            if (i >= characters.Count)
            {
                i = 0;
            }
        }

        Console.CursorVisible = true;
    }

    public void ShowCountDown(int countTime)
    {
        List<string> numbers = new List<string>();
        for (int i = countTime; i >= 1; i--)
        {
            numbers.Add(i.ToString());
        }

        Console.CursorVisible = false;

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(countTime);

        //List<string> numbers = new List<string> { "5", "4", "3", "2", "1" };

        int j = 0;
        while (DateTime.Now < endTime)
        {

            string currentNum = numbers[j];
            Console.Write(currentNum);
            Thread.Sleep(1000);
            Console.Write("\b \b");

            j++;

            if (j >= numbers.Count)
            {
                j = 0;
            }
        }

        Console.CursorVisible = true;
    }
}