public class BreathingActivity : Activity
{
    public BreathingActivity(string name, string description) : base(name, description)
    {
        _name = name;
        _description = description;
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

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        List<string> breath = new List<string> { "Breathe in...", "Breathe out..." };

        int i = 0;
        while (DateTime.Now < endTime)
        {
            // I think doing it this way makes the console cleaner
            string breathing = breath[i];
            Console.Write(breathing);
            Console.Write(" ");
            ShowCountDown(4);
            Console.Clear();

            i++;

            if (i >= breath.Count)
            {
                i = 0;
            }
        }

        // Entries for enhancement
        string dateStamp = startTime.ToString();
        activity.Add(dateStamp);
        activity.Add(_name);
        activity.Add(_description);
        activity.Add(sessionDuration);
        //-----------------------------

        Console.WriteLine("Well done!!");
        ShowSpinner(4);
        Console.WriteLine($"\nYou have completed another {_duration} seconds of {_name}.");
        ShowSpinner(4);
        Console.Clear();
    }
}