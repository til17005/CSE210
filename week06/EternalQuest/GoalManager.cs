using System.IO.Enumeration;
using System.Text;
using System.Text.Json;
public class GoalManager
{
    // Setup for database (List(s)) - I created one list for each type fo goal
    private List<SimpleGoal> _simpleGoal;
    private List<EternalGoal> _eternalGoal;
    private List<ChecklistGoal> _checklistGoal;

    private int _score;

    // Used for ListGoalNames and RecordEvent
    private List<(int, string)> goalNumber = new List<(int, string)>();

    public GoalManager()
    {
        _simpleGoal = new List<SimpleGoal>();
        _eternalGoal = new List<EternalGoal>();
        _checklistGoal = new List<ChecklistGoal>();
    }

    static int ReturnTryParseInt(string userChoice)
    {
        // I chose to use TryParse as it has built in protection agaist exceptions
        bool parseUserChoice = int.TryParse(userChoice, out int choice);
        return choice;
    }

    static bool ReturnTryParseBool(string userChoice)
    {
        // I chose to use TryParse as it has built in protection agaist exceptions
        bool parseUserChoice = int.TryParse(userChoice, out int choice);
        return parseUserChoice;
    }

    public void Start()
    {
        DisplayPlayerInfo();

        bool exit = false;
        while (!exit)
        {
            // Display points and main menu
            Console.WriteLine($"\nYou have {_score} points!\n");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("\t1: Create New Goal");
            Console.WriteLine("\t2: List Goals");
            Console.WriteLine("\t3: Save Goals");
            Console.WriteLine("\t4: Load Goals");
            Console.WriteLine("\t5: Record Event");
            Console.WriteLine("\t6: Quit");
            Console.Write("\nSelect a chouce from the menu: ");
            string userChoice = Console.ReadLine();
            int choice = ReturnTryParseInt(userChoice);

            // Check that users choice is a valid entry if not return to the menu
            if (ReturnTryParseBool(userChoice) && choice < 7)
            {

            }
            else
            {
                Console.WriteLine("\n*****   Entry invalid: Please try again!   *****");
            }

            switch (choice)
            {
                // Option 1 - User has selected to create a new goal
                case 1:
                    CreateGoal();
                    break;
                // Option 2 - User has selected to list all currecnt goals
                case 2:
                    ListGoalDetails();
                    break;
                // Option 3 - User has selected to save all current goals
                case 3:
                    Console.Write("\nPlease enter the filename:");
                    string saveFilename = Console.ReadLine();
                    SaveGoals(saveFilename);
                    break;
                // Option 4 - User has selected to load goals from a file
                case 4:
                    Console.Write("\nPlease enter the filename:");
                    string loadFilename = Console.ReadLine();
                    LoadGoals(loadFilename);
                    break;
                // Option 5 - User has slected to record a goal event
                case 5:
                    RecordEvent();
                    break;
                // Option 6 - User has chosen to quit the program
                case 6:
                    exit = true;
                    break;
                default:
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        foreach (var goal in _simpleGoal)
        {
            if (goal.IsComplete())
            {
                _score += goal.Points;
            }
        }

        foreach (var goal in _eternalGoal)
        {
            if (goal.IsComplete())
            {
                _score += goal.Points;
            }
        }

        foreach (var goal in _checklistGoal)
        {
            if (goal.IsComplete())
            {
                _score += goal.Points;
            }
        }
    }

    public void ListGoalNames()
    {
        int i = 1;

        Console.WriteLine("");
        foreach (var goal in _simpleGoal)
        {
            Console.WriteLine($"{i}: {goal.Name}");
            goalNumber.Add((i, goal.Name));

            i++;
        }

        foreach (var goal in _eternalGoal)
        {
            Console.WriteLine($"{i}: {goal.Name}");
            goalNumber.Add((i, goal.Name));

            i++;
        }

        foreach (var goal in _checklistGoal)
        {
            Console.WriteLine($"{i}: {goal.Name}");
            goalNumber.Add((i, goal.Name));

            i++;
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("");
        foreach (var goal in _simpleGoal)
        {
            var buildSimpleGoal = new StringBuilder();
            buildSimpleGoal.AppendLine($"Type: {goal.Type}");
            buildSimpleGoal.AppendLine($"Name: {goal.Name}");
            buildSimpleGoal.AppendLine($"Description: {goal.Description}");
            buildSimpleGoal.AppendLine($"Points: {goal.Points}");
            buildSimpleGoal.AppendLine($"Status: {goal.Status}");
            if (goal.IsComplete())
            {
                buildSimpleGoal.AppendLine($"Completed: [X]");
            }
            else
            {
                buildSimpleGoal.AppendLine($"Completed: [ ]");
            }

            string printGoals = buildSimpleGoal.ToString();
            Console.WriteLine(printGoals);
        }

        foreach (var goal in _eternalGoal)
        {
            var buildSimpleGoal = new StringBuilder();
            buildSimpleGoal.AppendLine($"Type: {goal.Type}");
            buildSimpleGoal.AppendLine($"Name: {goal.Name}");
            buildSimpleGoal.AppendLine($"Description: {goal.Description}");
            buildSimpleGoal.AppendLine($"Points: {goal.Points}");
            buildSimpleGoal.AppendLine($"Status: {goal.Status} - {goal.TimesComplete}");
            if (goal.IsComplete())
            {
                buildSimpleGoal.AppendLine($"Completed: [X]");
            }
            else
            {
                buildSimpleGoal.AppendLine($"Completed: [ ]");
            }


            string printGoals = buildSimpleGoal.ToString();
            Console.WriteLine(printGoals);
        }

        foreach (var goal in _checklistGoal)
        {
            var buildSimpleGoal = new StringBuilder();
            buildSimpleGoal.AppendLine($"Type: {goal.Type}");
            buildSimpleGoal.AppendLine($"Name: {goal.Name}");
            buildSimpleGoal.AppendLine($"Description: {goal.Description}");
            buildSimpleGoal.AppendLine($"Points: {goal.Points}");
            buildSimpleGoal.AppendLine($"Bonus: {goal.Bonus}");
            buildSimpleGoal.AppendLine($"Status: {goal.Status} - {goal.AmountComplete}/{goal.Target}");
            if (goal.IsComplete())
            {
                buildSimpleGoal.AppendLine($"Completed: [X]");
            }
            else
            {
                buildSimpleGoal.AppendLine($"Completed: [ ]");
            }

            string printGoals = buildSimpleGoal.ToString();
            Console.WriteLine(printGoals);
        }
    }

    public void CreateGoal()
    {
        int choice;
        bool exit = false;
        while (!exit)
        {
            // Create Goal submenu
            Console.WriteLine("\nThe types of goals are:");
            Console.WriteLine("\t1: Simple Goal");
            Console.WriteLine("\t2: Enternal Goal");
            Console.WriteLine("\t3: Checklist Goal");
            Console.WriteLine("\t4: Return to Main Menu");
            Console.Write("\nWhich type of goal would you like to create? ");
            string userGoalChoice = Console.ReadLine();
            choice = ReturnTryParseInt(userGoalChoice);

            // Check that users choice is a valid entry if not return to the menu
            if (ReturnTryParseBool(userGoalChoice) && choice < 5)
            {
                string type;
                string name;
                string description;
                string stringPoints;
                int points;
                string stringTarget;
                int target;
                string stringBonus;
                int bonus;
                string status = "New Goal";
                int amountComplete = 0;

                switch (choice)
                {
                    // User has chosen to add a simple goal
                    case 1:
                        type = "Simple Goal";

                        Console.Write("\nWhat is the name of your goal? ");
                        name = Console.ReadLine();

                        Console.Write("\nWhat is a short description of your goal? ");
                        description = Console.ReadLine();

                        Console.Write("\n How many points would you like to associate with this goal? ");
                        stringPoints = Console.ReadLine();
                        points = ReturnTryParseInt(stringPoints);

                        var simpleGoal = new SimpleGoal(type, name, description, points, status);
                        _simpleGoal.Add(simpleGoal);
                        break;
                    // User has chosen to add an eternal goal
                    case 2:
                        type = "Eternal Goal";

                        int timesComplete = 0;

                        Console.Write("\nWhat is the name of your goal? ");
                        name = Console.ReadLine();

                        Console.Write("\nWhat is a short description of your goal? ");
                        description = Console.ReadLine();

                        Console.Write("\n How many points would you like to associate with this goal? ");
                        stringPoints = Console.ReadLine();
                        points = ReturnTryParseInt(stringPoints);

                        var eternalGoal = new EternalGoal(type, name, description, points, status, timesComplete);
                        _eternalGoal.Add(eternalGoal);
                        break;
                    // User has chosen to add an eternal goal
                    case 3:
                        type = "Checklist Goal";

                        Console.Write("\nWhat is the name of your goal? ");
                        name = Console.ReadLine();

                        Console.Write("\nWhat is a short description of your goal? ");
                        description = Console.ReadLine();

                        Console.Write("\n How many points would you like to associate with this goal? ");
                        stringPoints = Console.ReadLine();
                        points = ReturnTryParseInt(stringPoints);

                        Console.Write("\nHow many times does this goal need to be accomplished for a bonus? ");
                        stringTarget = Console.ReadLine();
                        target = ReturnTryParseInt(stringTarget);

                        Console.Write("\nWhat is the bonus for accomplishing this goal that many times? ");
                        stringBonus = Console.ReadLine();
                        bonus = ReturnTryParseInt(stringBonus);

                        var checklistGoal = new ChecklistGoal(type, name, description, points, status, amountComplete, target, bonus);
                        _checklistGoal.Add(checklistGoal);
                        break;
                    case 4:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("*****   Your seletion was invalid. Please try again!   *****");
                        break;
                }
            }
            else
            {
                Console.WriteLine("\n*****   Entry invalid: Please try again!   *****");
            }
        }


    }

    public void RecordEvent()
    {
        ListGoalNames();

        Console.Write("\nWhich goal did you accoumplish? ");
        string selectedGoal = Console.ReadLine();
        int selection = ReturnTryParseInt(selectedGoal);

        // Check user entery agaist goalNumber list
        if (selection < 1 || selection > goalNumber.Count)
        {
            Console.WriteLine("That selection is invalid: Please try again!");
            return;
        }

        // Get the name of the goal for searching the 3 lists(simple, eternal, and checklist)
        string targetName = goalNumber[selection - 1].Item2;

        // Loops searching for goal with targetName
        foreach (var goal in _simpleGoal)
        {
            if (goal.Name == targetName)
            {
                goal.Status = "Complete";
                _score += goal.Points;
                Console.WriteLine($"Congratulations you have earned {goal.Points} points");
                return;
            }
        }

        foreach (var goal in _eternalGoal)
        {
            if (goal.Name == targetName)
            {
                goal.Status = "Eternal";
                goal.TimesComplete++;
                _score += goal.Points;
                Console.WriteLine($"Congratulations you have earned {goal.Points} points");
                return;
            }
        }

        foreach (var goal in _checklistGoal)
        {
            if (goal.Name == targetName)
            {
                goal.AmountComplete++;
                _score += goal.Points;

                Console.WriteLine($"Congratulations you have earned {goal.Points} points\n");

                if (goal.AmountComplete == goal.Target)
                {
                    goal.Status = "Complete";
                    Console.WriteLine($"Wow, ULTRA CONGRATULATIONS!!! You have completed this goal and earned a bonus of {goal.Bonus} points!");
                    _score += goal.Bonus;
                }
                else
                {
                    goal.Status = "In Progress";
                }
                return;
            }
        }
    }

    public void AddPoints()
    {
        // Reset points
        _score = 0;

        foreach (var goal in _simpleGoal)
        {
            if (goal.Status == "Complete")
            {
                _score += goal.Points;
            }
        }

        foreach (var goal in _eternalGoal)
        {
            if (goal.TimesComplete > 0)
            {
                int eternalScore = goal.TimesComplete * goal.Points;
                _score += eternalScore;
            }
        }

        foreach (var goal in _checklistGoal)
        {
            if (goal.AmountComplete > 0)
            {
                int checklistScore = goal.AmountComplete * goal.Points;
                _score += checklistScore;
            }

            if (goal.Status == "Complete")
            {
                _score += goal.Bonus;
            }
        }
    }

    // Getters & Setters
    public List<SimpleGoal> SimpleGoals
    {
        get { return _simpleGoal; }
        set { _simpleGoal = value; }
    }

    public List<EternalGoal> EternalGoals
    {
        get { return _eternalGoal; }
        set { _eternalGoal = value; }
    }

    public List<ChecklistGoal> ChecklistGoals
    {
        get { return _checklistGoal; }
        set { _checklistGoal = value; }
    }

    // This uses StreamReader to load the GoalsDatabase
    public void LoadGoals(string filename)
    {
        // Check if the database file exists
        if (File.Exists(filename))
        {
            // Open StreamReader to read the database
            StreamReader streamReader = new StreamReader(filename);

            // Read to the end of the JSON file
            string goalsFromDatabase = streamReader.ReadToEnd();

            // Close StreamReader
            streamReader.Close();

            // Set container for goal data
            GoalManager goalContainer = JsonSerializer.Deserialize<GoalManager>(goalsFromDatabase);

            // Set each List with the proper goal data
            _simpleGoal = goalContainer.SimpleGoals;
            _eternalGoal = goalContainer.EternalGoals;
            _checklistGoal = goalContainer.ChecklistGoals;
        }
        else
        {
            Console.WriteLine("You have not set any goals yet!");
        }
        
        ListGoalDetails();
        AddPoints();
    }

    // Overwritting goals database with whatever was loaded from it and added to each list after the load
    public void SaveGoals(string filename)
    {
        // Create my database container to hold my goal information
        GoalManager goalManager = new GoalManager();

        // Set each list to be copied into the database
        goalManager.SimpleGoals = this._simpleGoal;
        goalManager.EternalGoals = this._eternalGoal;
        goalManager.ChecklistGoals = this._checklistGoal;

        // Serialize goalDatabase
        string databaseToJSON = JsonSerializer.Serialize(goalManager);

        // Set the filename to write to using StreamWrite and overwrite everything
        StreamWriter streamWriter = new StreamWriter(filename, false);
        streamWriter.Write(databaseToJSON);

        // Close StreamWriter
        streamWriter.Close();
    }
}