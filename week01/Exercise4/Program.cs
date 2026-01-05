using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise4 Project.");

        Console.Write("Please enter a list of numbers, Type 0 when finished. ");
        List<int> numbers = new List<int>();
        int number = -1;

        while (number != 0)
        {
            Console.Write("Enter a number: ");
            string input = Console.ReadLine();
            number = int.Parse(input);
            if (number != 0)
            {
                numbers.Add(number);
            }
        }

        int sum = numbers.Sum();
        Console.WriteLine($"The sum is {sum}");

        double average = sum / numbers.Count;
        Console.WriteLine($"The average is {average}");

        int largest = numbers.Max();
        Console.WriteLine($"The largest number is {largest}");

        int smallest = numbers.Min();
        Console.WriteLine($"The smallest number is {smallest}");

        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }

    }
}