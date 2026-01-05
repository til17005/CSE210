using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise5 Project.");
        DisplayWelcome();
        DisplayResult();
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        string number = Console.ReadLine();
        int favoriteNumber = int.Parse(number);
        return favoriteNumber;
    }

    static int SquareNumber(int number)
    {
        int squaredNumber = number * number;
        return squaredNumber;
    }

    static void DisplayResult()
    {
        string name = PromptUserName();
        int number = SquareNumber(PromptUserNumber());

        Console.WriteLine($"{name}, the square of your favorite number is {number}."); 
    }
}