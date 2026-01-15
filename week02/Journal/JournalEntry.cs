public class JournalEntry
{
    // Set up my JournalEntry properties
    public string _date;
    public string _prompt;
    public string _entry;

    // Method or function to display my journal entry
    public void DisplayEntry()
    {
        Console.WriteLine($"{_date} - {_prompt}\n{_entry}\n");
    }
}