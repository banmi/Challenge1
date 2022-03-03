using System;

namespace ProgChallengeStart
{
    class Program
    {
        private static int currentGuess;

        static void Main(string[] args)
        {
            // Choose a random number between 0 and 30
            int theNumber = new Random().Next(30);

            // Print the instructions
            Console.WriteLine("I'm thinking of a number between 0 and 30.");
            Console.WriteLine("Enter your guess, or -1 to give up.");

            // Keep track of the number of guesses and the current user guess
            int guessCount = 0;
            bool isValid = true;

            //Check if user type something else than number
            int guessNumber()
            {
                Console.WriteLine("What's your guess?");
                var theGuess = Console.ReadLine();
                int guess;
                try
                {
                    bool result = Int32.TryParse(theGuess, out guess);
                    if (!result)
                    {
                        throw new Exception();
                    }
                    else
                    {
                        return guess;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("That doesn't look like a number. Try again.");
                }
                return 0;
            };

            bool isValidGuess(int numberToValidate)
            {
                if (numberToValidate > 30 || numberToValidate < -1)
                {
                    Console.WriteLine($"Your value {numberToValidate} is out of range!");
                    isValid = false;
                }
                else
                {
                    // Tell lower or higher than the guess
                    Console.WriteLine("Nope, {0} than that.", numberToValidate < theNumber ? "higher" : "lower");
                    isValid = true;
                }

                return isValid;
            }

            void exit()
            {
                if (currentGuess == -1)
                {
                    System.Environment.Exit(0);
                }
            }

            currentGuess = guessNumber();
            while (currentGuess != theNumber)
            {
                exit();
                if (isValidGuess(currentGuess))
                {
                    currentGuess = guessNumber();
                    guessCount++;
                }
                else
                {
                    currentGuess = guessNumber();
                }
                if (currentGuess == theNumber)
                {
                    Console.WriteLine($"You got it in {guessCount} guesses");
                }
            }
        }
    }
}
