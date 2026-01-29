using System;
using System.ComponentModel.Design;
using System.IO.Enumeration;
using System.Xml.Serialization;

class Program
{
    static void Main(string[] args)
    {
        /*****************************************************************************************************
        Exceeding Requirements: This was a bit bigger than I had initially thought. I added two classes
        1) UserClass
        2) ActivityHistory

        The UserClass class manages the users first name and a PIN they will create if the user would like
        the activity session recorded (documented).

        The ActivityHistory class manages the filename (json), creating the file, and updating the file
        contents.

        I chose to save the file as a json and to update it with each entry. I added a few lists to the 
        Actvity class to help manage the content that gets recorded. I discovered I needed to use
        dictionaries to update the json file. I am sure there is another more simplified way to do it, but
        I stuck with what I could figure out and a dictionary works like a compound list so I went with it.

        When a user runs the program for the first time they are asked for their first name and a PIN. The
        program combines them to create a filename. ex. Matthew1234.json. The file is created and records
        the users first name and PIN within the file.

        When the user finishes an activity the session is recorded to the appropriate json file.

        If a user returns and wants to record the session the user will enter the first name and PIN then
        the program will check for a file with that name and continue on.

        The new portions of code to make this functionality work are commented as seen below within each
        file.

        // Entries for enhancement
        *****************************************************************************************************/

        // I kept this essentially for a title to what this project is
        Console.WriteLine("Hello World! This is the Mindfulness Project.\n");
        // I clear the console to keep the look clean
        Console.Clear();

        // Variables used for the new UserClass I added for exceeding requirements
        string userFirstName;
        string userPIN;
        int toINT;

        // Check if user would like to record the session
        Console.Write("Would you like to record your session? (Y or N): ");
        string recordSession = Console.ReadLine();
        string recordSessionLower = recordSession.ToLower();

        // Create objects for Activity and ActivityHistory
        Activity activity = new Activity("NA", "NA");
        ActivityHistory activityHistory = new ActivityHistory();

        // If user would like to record the session then check for an existing user file or create a new one
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
            // First I check for (not exist) and create it. I also added a message. The message also helps with troubleshooting: depending on what message you get
            if (!File.Exists(filename))
            {
                activityHistory.CreateInitialSessionFile(userFirstName, toINT);

                activity.ShowSpinner(2);
                Console.Write("Creating user session:");
                activity.ShowSpinner(4);
            }
            // I then check for the existing file just to make sure and also to give another (different) message
            // Yes, I am aware I could have just done else
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
        // The while loop will keep the menu going until the user chooses to quit
        // Each section of the if block essentially does the same thing so I will add documentation to only the first one
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

                // Create new BreathingActiity object and run it
                BreathingActivity breathingActivity = new BreathingActivity(_activityName, _activityDescription);
                breathingActivity.Run();

                // Record to file the seesion only if the user chose to do so.
                if (recordSessionLower == "y")
                {
                    // Call the UpdateSessionFile method which will record the appropriate List(s) to file
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

        // I didn't want to just end the program without a positive message
        Console.Clear();
        Console.WriteLine("The program has ended.\nHave a great day!\n\n");
    }
}