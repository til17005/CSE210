using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise2 Project.");

        Console.Write("Please enter you grade percentage (0-100): ");
        string percentage = Console.ReadLine();
        int gradePercent = int.Parse(percentage);

        string letterGrade = "";

        if (gradePercent >= 90)
        {
            letterGrade = "A";
            //Console.WriteLine("Your grade is an A.");
        }
        else if (gradePercent >= 80 && gradePercent < 90)
        {
            letterGrade = "B";
            //Console.WriteLine("Your grade is a B.");
        }
        else if (gradePercent >= 70 && gradePercent < 80)
        {
            letterGrade = "C";
            //Console.WriteLine("Your grade is a C.");
        }
        else if (gradePercent >= 60 && gradePercent < 70)
        {
            letterGrade = "D";
            //Console.WriteLine("Your grade is a D.");
        }
        else
        {
            letterGrade = "F";
            //Console.WriteLine("Your grade is an F.");
        }

        Console.WriteLine($"Your letter grade is {letterGrade}.");

        int lastDigit = Math.Abs(gradePercent % 10);
        string sign = "";

        if (lastDigit >= 7 && gradePercent < 94 && gradePercent > 60)
        {
            sign = "+";
        }
        else if (lastDigit < 3 && gradePercent > 60)
        {
            sign = "-";
        }

        Console.WriteLine($"Your letter grade is {letterGrade}{sign}.");

        if (gradePercent >= 70)
        {
            Console.WriteLine("Congratulations! You have passed the course!");
        }
        else
        {
            Console.WriteLine("I'm sorry, but you have not passed this course. Don't give up. You can do this!");
        }
    }
}