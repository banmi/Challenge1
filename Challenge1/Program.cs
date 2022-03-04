using System;

namespace ProgChallengeStart
{
    class Program
    {
        private static int currentGuess;
        private static int guess;
        public enum classification
                {
                TOO_LOW,
                TOO_HIGH,
                CORRECT,
                OUT_RANGE
                };

        static void Main(string[] args)
        {
            while(true)
            {
                try
                {
                    guess = guessNumber();
                }
                catch
                {
                    Console.WriteLine("That doesn't look like a number. Try again.");
                    continue;
                }

                classification myClassification = classifyGuess(guess);
                if (myClassification == classification.TOO_LOW)
                    {
                    Console.WriteLine("Nope, higher than that.");
                    }
                else if (myClassification == classification.TOO_HIGH)
                    {
                    Console.WriteLine("Nope, lower than that.");
                    }
                else if (myClassification == classification.CORRECT)
                    {
                    Console.WriteLine("$You got it in {guessCount} guesses");
                    }
                else if (myClassification == classification.OUT_RANGE)
                    {
                    Console.WriteLine($"Your value {numberToValidate} is out of range!");
                    }
            }
            



            // Choose a random number between 0 and 30
            int rolledNumber = new Random().Next(30);

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
                //int guess;
                try
                {
                    bool result = Int32.TryParse(theGuess, out guess);
                    if (result)
                    {
                    return guess;
                    }
                    else
                    {
                    Console.WriteLine("That doesn't look like a number. Try again.");
                    }
                return -2;
            };

            void classifyGuess(int numberToValidate)
                {

                if (numberToValidate > 30 || numberToValidate < -1)
                    {
                    myClassification = classification.OUT_RANGE;
                    }
                else
                    {
                    // Tell lower or higher than the guess
                    Console.WriteLine("Nope, {0} than that.", numberToValidate < rolledNumber ? "higher" : "lower");
                    isValid = true;
                    }
                }
            
            

                

            void checkForExit()
            {
                if (currentGuess == -1)
                {
                    System.Environment.Exit(0);
                }
            }

            currentGuess = guessNumber();
            while (currentGuess != rolledNumber)
            {
                checkForExit();
                if (classifyGuess(currentGuess))
                {
                    currentGuess = guessNumber();
                    guessCount++;
                }
                else
                {
                    currentGuess = guessNumber();
                }
                if (currentGuess == rolledNumber)
                {
                    Console.WriteLine($"You got it in {guessCount} guesses");
                }
            }
        }
    }
}

            

            

