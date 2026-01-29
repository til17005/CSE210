using System;
using System.ComponentModel.Design;
using System.IO.Enumeration;
using System.Xml.Serialization;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Mindfulness Project.\n");
        Console.Clear();

        string userFirstName;
        string userPIN;
        int toINT;

        // Check if user would like to record the session
        Console.Write("Would you like to record your session? (Y or N): ");
        string recordSession = Console.ReadLine();
        string recordSessionLower = recordSession.ToLower();

        Activity activity = new Activity("NA", "NA");
        ActivityHistory activityHistory = new ActivityHistory();

        // If user would like to record the session then check for user file or create a new one
        if (recordSessionLower == "y")
        {
            Console.Write("Please enter your first name: ");
            userFirstName = Console.ReadLine();
            Console.Write("\nPlease enter a PIN (4 digits): ");
            userPIN = Console.ReadLine();
            Console.WriteLine("You will need to remember your PIN for future sessions!");
            
            activity.ShowSpinner(5);

            // Switch PIN back to an int
            int.TryParse(userPIN, out toINT);

            // Set filename
            activityHistory.SetFilename(userFirstName, toINT);

            // Check if user file exist and if not create it
            string filename = $"{userFirstName}{userPIN}.json";
            if (!File.Exists(filename))
            {
                activityHistory.CreateInitialSessionFile(userFirstName, toINT);

                activity.ShowSpinner(2);
                Console.Write("Creating user session:");
                activity.ShowSpinner(4);
            }
            else if (File.Exists(filename))
            {
                activity.ShowSpinner(2);
                Console.Write("Starting user session:");
                activity.ShowSpinner(4);
            }
            Console.Clear();
        }

        // Set up user menu
        int choice = 0;
        while (choice != 4)
        {
            Console.Write("Menu Options:\n\t1. Start breathing activity\n\t2. Start reflecting activity\n\t3. Start listing activity\n\t4. Quit\nSelect a choice from the menu: ");
            string input = Console.ReadLine();
            choice = int.Parse(input); // Gets the user's choice and converts it from string to int

            // Breathing Activity
            if (choice == 1)
            {
                // I wasn't positive if I should set the name and description here to show you can pass it through inheritance, or if I should have done them in the BreathingActivity.cs itself. Obviously I chose to do it here for each activity. I hope I was correct to do so.
                string _activityName = "Breathing Activity";
                string _activityDescription = "This activity will help you relax by walking through breathing in and out slowly. Clear your mind and focus on your breathing";

                BreathingActivity breathingActivity = new BreathingActivity(_activityName, _activityDescription);
                breathingActivity.Run();

                if (recordSessionLower == "y")
                {
                    activityHistory.UpdateSessionFile(activityHistory.GetFilename(), breathingActivity);
                }
            }
            // Reflecting Activity
            else if (choice == 2)
            {
                string _activityName = "Reflection Activity";
                string _activityDescription = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of you life.";

                ReflectionActivity reflectionActivity = new ReflectionActivity(_activityName, _activityDescription);
                reflectionActivity.Run();

                if (recordSessionLower == "y")
                {
                    activityHistory.UpdateSessionFile(activityHistory.GetFilename(), reflectionActivity);
                }
            }
            // Listing Activity
            else if (choice == 3)
            {
                string _activityName = "Listing Activity";
                string _activityDescription = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";

                ListingActivity listingActivity = new ListingActivity(_activityName, _activityDescription);
                listingActivity.Run();

                if (recordSessionLower == "y")
                {
                    activityHistory.UpdateSessionFile(activityHistory.GetFilename(), listingActivity);
                }
            }
        }

        Console.Clear();
        Console.WriteLine("The program has ended.\nHave a great day!\n\n");
    }
}