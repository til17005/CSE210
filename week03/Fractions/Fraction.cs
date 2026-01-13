public class Fraction
{
    // Private variables to hold the numerator and denominator
    private int _top;
    private int _bottom;

    // Constructor with no parameters to initialize the fraction to 1/1
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    // Constructor with one parameter to initialize the denominator to 1. Ex: 5 = 5/1
    public Fraction(int top)
    {
        _top = top;
        _bottom = 1;
    }

    // Constructor with two parameters to initialize the numerator and demoninator
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    // Getter for numberator
    public int GetNumerator()
    {
        return _top;
    }

    // Getter for denominator
    public int GetDenominator()
    {
        return _bottom;
    }

    // Setter for numerator
    public void SetNumerator(int numerator)
    {
        _top = numerator;
    }

    // Setter for denominator
    public void SetDenominator(int denominator)
    {
        _bottom = denominator;
    }

    // Method to get fraction as a string
    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    // Method to get decimal value of the fraction
    public double GetDecimalValue()
    {
        return (double)_top / _bottom;
    }
}