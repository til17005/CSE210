using System.IO;
using System.Text.Json;

public class ActivityHistory
{
    // Variable for filename
    private string _filename;

    // Method for setting the filename
    public void SetFilename(string firstName, int userPIN)
    {
        _filename = $"{firstName}{userPIN}.json";
    }

    // Method for getting the filename
    public string GetFilename()
    {
        return _filename;
    }

    // Method for creating a new file. This also records the users first name and PIN within the file
    public void CreateInitialSessionFile(string firstName, int userPIN)
    {
        // Convert PIN from int to string
        string stringPIN = userPIN.ToString();
        // Define the filename to be firstnamePIN.json
        _filename = $"{firstName}{stringPIN}.json";

        // Create dictionary for user first name and PIN strings
        Dictionary<string, object> userClass = new Dictionary<string, object>
        {
            {"UserName", firstName},
            {"UserPIN", userPIN},
        };

        // Use StreamWriter to create the new file and populate it with the contents of the dictionary
        using (StreamWriter streamWriter = new StreamWriter(_filename))
        {
            string jsonLine = JsonSerializer.Serialize(userClass);
            streamWriter.WriteLine(jsonLine);
        }
    }

    // Method for updating the users json file
    public void UpdateSessionFile(string filename, Activity finishedActivity)
    {
        // Again using StreamWriter to append the users file
        using (StreamWriter streamWriter = new StreamWriter(filename, append: true))
        {
            // Get activity list from Activity and save it to users json file
            List<string> activity = finishedActivity.getActivity();
            // I am checking to make sure each list has entries within
            if (activity.Count > 0)
            {
                // Create a new dictionary for the list strings to be placed
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                dictionary.Add("ActivityDetails", activity);

                // Populate the json file with the dictionary objects
                string jsonLine = JsonSerializer.Serialize(dictionary);
                streamWriter.WriteLine(jsonLine);
            }

            // Get activity prompts list from Activity and save it to users json file
            List<string> activityPrompts = finishedActivity.getActivityPrompts();
            if (activityPrompts.Count > 0)
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                dictionary.Add("ActivityPrompts", activityPrompts);

                string jsonLine = JsonSerializer.Serialize(dictionary);
                streamWriter.WriteLine(jsonLine);
            }

            // Get activity questions list from Activity and save it to users json file
            List<string> activityQuestions = finishedActivity.getActivityQuestions();
            if (activityQuestions.Count > 0)
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                dictionary.Add("ActivityQuestions", activityQuestions);

                string jsonLine = JsonSerializer.Serialize(dictionary);
                streamWriter.WriteLine(jsonLine);
            }

            // Get activity user entries list from Activity and save it to users json file
            List<string> activityEntries = finishedActivity.getActivityUserEntries();
            if (activityEntries.Count > 0)
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                dictionary.Add("ActivityUserEntries", activityEntries);

                string jsonLine = JsonSerializer.Serialize(dictionary);
                streamWriter.WriteLine(jsonLine);
            }
        }
    }
}