// System.IO is needed for file reading and writing
using System.IO;
using System.Text.Json;

public class Scripture
{
    // Reference object to hold book, chapter, and verse - From Reference.cs
    private Reference _reference;

    // List of words that in the scripture - From Word.cs
    private List<Word> _text;

    // Create a new Random object to help hide words in the scripture
    Random random = new Random();

    // My default constructor for Scripture class
    public Scripture()
    {
        _reference = null;
        _text = new List<Word>();
    }

    // Constructor for Scripture class - input Reference and List of words
    public Scripture(Reference reference, List<Word> text)
    {
        _reference = reference;
        _text = text;
    }

    // Load my JSON file and parse it into my Scripture object - Scripture is returned
    public Scripture LoadFromFile(string filename)
    {
        // Using StreamReader to read the file - same as in my Journal project, but reading JSON instead
        using (StreamReader reader = new StreamReader(filename))
        {
            // This reads the entire contents of the file into a string
            string json = reader.ReadToEnd();

            // Parse JSON to get the book, chapter, and verse(s)
            JsonElement doc = JsonSerializer.Deserialize<JsonElement>(json);

            string book = doc.GetProperty("Book").GetString();
            int chapter = doc.GetProperty("Chapter").GetInt32();
            JsonElement verses = doc.GetProperty("Verses");

            // This will get the start and end verse for the Reference object
            // THis will help determine if the scripture is single or multiple verses
            int startVerse = verses[0].GetProperty("VerseNumber").GetInt32();
            int endVerse = verses[verses.GetArrayLength() - 1].GetProperty("VerseNumber").GetInt32();

            // Create my Reference object - Reference.cs
            Reference reference = new Reference(book, chapter, startVerse, endVerse);

            // Create my List of words for the scripture text - Word.cs
            List<Word> words = new List<Word>();

            // Loop through each verse in the JSON and split it into words
            foreach (JsonElement verse in verses.EnumerateArray())
            {
                string text = verse.GetProperty("Text").GetString();
                string[] tokens = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                foreach (string token in tokens)
                {
                    // Creates a new Word object for each word in the scripture then adds it to my words List - Word.cs
                    words.Add(new Word(token));
                }
            }

            return new Scripture(reference, words);
        }
    }

    // This method will hide a specified number of random words in the scripture
    public void HideRandomWords(int numberOfWordsToHide)
    {
        // I added this next section to check for how many words are left to hide as I kept running into an infinite loop when trying to hide more words than were left to hide
        // Check the number of words left to hide
        int wordsLeftToHide = 0;
        foreach (Word word in _text)
        {
            if (!word.IsHidden())
            {
                wordsLeftToHide++;
            }
        }

        // If fewer words are left to hide than being requested change the number to hide
        if (numberOfWordsToHide > wordsLeftToHide)
        {
            numberOfWordsToHide = wordsLeftToHide;
        }

        // My Counter for how many words have been hidden
        int i = 0;

        // Loop until the specified # of words have been hidden
        while (i < numberOfWordsToHide)
        {
            // Get a random index in my _text List - Word.cs
            int wordIndex = random.Next(_text.Count);
            // Get the Word object at the specified index
            Word word = _text[wordIndex];


            // If the word is not hidden already, then hide it now - Word.cs
            if (!word.IsHidden())
            {
                word.Hide();
                i++;
            }
        }
    }

    // This method will return the scripture text with hidden words as underscores dictated by the Word.cs GetDisplayText method
    public string GetDisplayText()
    {
        string scriptureText = _reference.GetDisplayText() + "\n";
        foreach (Word word in _text)
        {
            scriptureText += word.GetDisplayText() + " ";
        }
        return scriptureText.Trim();
    }

    // This method will check if all the words in the scripture are hidden - I use this to end the program when all words are hidden
    public bool IsCompletelyHidden()
    {
        foreach (Word word in _text)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}