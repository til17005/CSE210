using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Homework Project.\n");

        Assignment assignment = new Assignment("Matthew", "C# Inheritance");
        MathAssignment mathAssignment = new MathAssignment("Roger", "Transformational Geometry", "8.7.23", "1-5");
        WrittingAssignment writtingAssignment = new WrittingAssignment("Katy", "Western Civilization", "War: What it it good for?");

        Console.WriteLine(assignment.GetSummary());
        Console.WriteLine(mathAssignment.GetHomeworkList());
        Console.WriteLine(writtingAssignment.GetWrittingInformation());
    }
}