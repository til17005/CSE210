using System;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise3 Project.");

        bool playAgain = true;

        do
        {
            Random random = new Random();
            int magicNumber = random.Next(1, 99);
            Console.WriteLine("Let's play guess the magic number (1-99)!");

            string userGuess = "";
            int guessInt = 0;
            int counter = 0;

            while (guessInt != magicNumber)
            {
                Console.Write("What is your guess? ");
                userGuess = Console.ReadLine();
                guessInt = int.Parse(userGuess);

                if (magicNumber < guessInt)
                {
                    Console.WriteLine("Lower");
                }
                else if (magicNumber > guessInt)
                {
                    Console.WriteLine("Higher");
                }

                counter++;
            }

            if (magicNumber == guessInt)
            {
                Console.WriteLine("Congratulations! You guessed the magic number!");
                Console.WriteLine($"It took you {counter} guesses to guess the magic number: {magicNumber} ");
            }

            Console.Write("would you like to play again? (Y/N): ");
            string playAgainInput = Console.ReadLine();
            if (playAgainInput.ToLower() == "y")
            {
                playAgain = true;
            }
            else
            {
                playAgain = false;
            }

        } while (playAgain == true);
    }
}