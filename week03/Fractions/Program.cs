using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Fractions Project.");

        Fraction fraction1 = new Fraction();
        Fraction fraction2 = new Fraction(5);
        Fraction fraction3 = new Fraction(3, 4);

        Console.WriteLine($"Fraction 1: {fraction1.GetNumerator()}/{fraction1.GetDenominator()}");
        Console.WriteLine($"Fraction 2: {fraction2.GetNumerator()}/{fraction2.GetDenominator()}");
        Console.WriteLine($"Fraction 3: {fraction3.GetNumerator()}/{fraction3.GetDenominator()}\n");

        Console.WriteLine($"Fraction as a string: {fraction1.GetFractionString()}");
        Console.WriteLine($"Fraction as a decimal: {fraction1.GetDecimalValue()}\n");

        Console.WriteLine($"Fraction as a string: {fraction2.GetFractionString()}");
        Console.WriteLine($"Fraction as a decimal: {fraction2.GetDecimalValue()}\n");

        Console.WriteLine($"Fraction as a string: {fraction3.GetFractionString()}");
        Console.WriteLine($"Fraction as a decimal: {fraction3.GetDecimalValue()}");
    }
}