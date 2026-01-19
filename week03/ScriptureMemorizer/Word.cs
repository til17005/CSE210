public class Word
{
    // private variables to hold the word text and whether it is hidden
    private string _text;
    private bool _isHidden;

    // Constructor to set the word text
    public Word(string text)
    {
        _text = text;
    }

    // Method to hide the word
    public void Hide()
    {
        _isHidden = true;
    }

    // Method to show the word - This is not used in my program but could be useful for future enhancements
    public void Show()
    {
        _isHidden = false;
    }

    // Method to check if the word is hidden (bool: true or false)
    public bool IsHidden()
    {
        return _isHidden;
    }

    // Method to get the display text of the word - either the word or underscores if the word is hidden
    public string GetDisplayText()
    {
        if (_isHidden)
        {
            return new string('_', _text.Length);
        }
        else
        {
            return _text;
        }
    }
}