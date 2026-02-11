using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("\nHello World! This is the ExerciseTracking Project.\n\n");

        Console.WriteLine("Exercise Tracking Program");
        Console.WriteLine("_________________________\n");

        // Create a new list for my activities
        var activities = new List<Activity>();

        // Parameters(DateTime, Actvity, Minutes, Value(running - distance, cycling - speed, swimming - laps))
        activities.Add(new Running(new DateTime(2026, 2, 9), "Running", 55, 10));
        activities.Add(new Swimming(DateTime.Today, "Swimming", 45, 23));
        activities.Add(new Cycling(DateTime.Today, "Cycling", 120, 18));
        activities.Add(new Swimming(new DateTime(2026, 2, 8), "Swimming", 30, 18));
        activities.Add(new Cycling(new DateTime(2026, 2, 7), "Cycling", 240, 23));
        activities.Add(new Running(DateTime.Today, "Running", 60, 15));

        // Iterate my list of activities and display GetSummary
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }

        Console.WriteLine();
    }
}