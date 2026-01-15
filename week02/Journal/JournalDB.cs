// System.IO is needed for file reading and writing
using System.IO;
public class JournalDB
{

    // List to hold my journal entries
    public List<JournalEntry> _entries;

    // Method to add a new journal entry to mu _entries list
    public void AddEntry(JournalEntry entry)
    {
        _entries.Add(entry);
    }

    // Method or function to display all my journal entries
    public void DisplayJournal()
    {
        foreach (JournalEntry journal in _entries)
        {
            journal.DisplayEntry();
        }
    }

    // Method to save my journal to a file
    public void SaveToFile(string filename)
    {
        // Using StreamWriter to write to a file - This will allow me to write to a text file or a csv file
        using (StreamWriter toFile = new StreamWriter(filename))
        {
            foreach (JournalEntry journal in _entries)
            {
                // I used a pipe to separate the fields so I don't have to worry about commas in my entries
                toFile.WriteLine(journal._date + "|" + journal._prompt + "|" + journal._entry);
            }
        }

    }

    public void LoadFromFile(string filename)
    {
        // Using StreamReader to read from a file
        using (StreamReader fromFile = new StreamReader(filename))
        {
            // Read each line from my file and split it into three parts: date, prompt, and entry
            string line;
            _entries = new List<JournalEntry>();
            while ((line = fromFile.ReadLine()) != null)
            {
                // This will split my entry into its three parts
                string[] part = line.Split("|");

                // Create a new JournalEntry object
                JournalEntry entry = new JournalEntry();

                // Set the properties of my JournalEntry object
                entry._date = part[0];
                entry._prompt = part[1];
                entry._entry = part[2];

                // Add each journal entry to my _entries list
                _entries.Add(entry);
            }
        }
    }
}