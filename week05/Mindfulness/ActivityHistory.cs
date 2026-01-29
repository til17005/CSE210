using System.IO;
using System.Text.Json;

public class ActivityHistory
{
    private string _filename;

    public void SetFilename(string firstName, int userPIN)
    {
        _filename = $"{firstName}{userPIN}.json";
    }

    public string GetFilename()
    {
        return _filename;
    }

    public void CreateInitialSessionFile(string firstName, int userPIN)
    {
        string stringPIN = userPIN.ToString();
        _filename = $"{firstName}{stringPIN}.json";

        // Create dictionary
        Dictionary<string, object> userClass = new Dictionary<string, object>
        {
            {"UserName", firstName},
            {"UserPIN", userPIN},
        };

        using (StreamWriter streamWriter = new StreamWriter(_filename))
        {
            string jsonLine = JsonSerializer.Serialize(userClass);
            streamWriter.WriteLine(jsonLine);
        }
    }

    public void UpdateSessionFile(string filename, Activity finishedActivity)
    {
        //string stringPIN = userPIN.ToString();
        //_filename = $"{firstName}{stringPIN}.json";
        using (StreamWriter streamWriter = new StreamWriter(filename, append: true))
        {
            // Get activity list from Activity and save it to users json file
            List<string> activity = finishedActivity.getActivity();
            if (activity.Count > 0)
            {
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                dictionary.Add("ActivityDetails", activity);

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