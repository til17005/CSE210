public class Reference
{
    // private variables to hold book, chapter, verse, startVerse, and endVerse
    private string _book;
    private int _chapter;
    private int _verse;
    private int _startVerse;
    private int _endVerse;

// Constructor for single verse scripture
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
    }

// Constructor for multiple verse scripture - this is the one used in my program
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    // Method to get the scripture reference as a string - used in Scripture.cs and what is displayed to the user
    public string GetDisplayText()
    {
        if (_endVerse > 0)
        {
            return $"{_book} {_chapter}:{_startVerse}-{_endVerse}\n";
        }
        else
        {
            return $"{_book} {_chapter}:{_verse}\n";
        }
    }
}