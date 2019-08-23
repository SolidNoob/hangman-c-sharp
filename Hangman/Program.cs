using System;

using System.Collections.Generic;
using System.Linq;

namespace Hangman
{
    class Program
    {
        private const int maximumTries = 10;
        private static int triesLeft;
        private static string randomWord;
        private static List<char> lettersHistory;

        static void Main(string[] args)
        {
            string wordToGessStatus = "";
            char guessedLetter;
            bool running = true;

            // initialize game variables
            initGame();
            // Console.WriteLine(randomWord);

            while (running)
            {
                wordToGessStatus = getWordStatus();
                Console.WriteLine("Guess that word: {0}", wordToGessStatus);
                
                // victory
                if ( ! wordToGessStatus.Contains('*'))
                {
                    Console.WriteLine("Yay! You win with {0} tries remaining !", triesLeft);
                    running = false;
                    break;
                }

                // ask user input (letter)
                Console.WriteLine("Number of tries left: {0}", triesLeft);
                Console.WriteLine("Please enter a letter: ");

                guessedLetter = readLetterFromUser();

                lettersHistory.Add(guessedLetter);

                // check if the word contains the letter
                if ( ! randomWord.Contains(guessedLetter))
                {
                    triesLeft = triesLeft - 1;

                    // loss
                    if (triesLeft == 0)
                    {
                        Console.WriteLine("No tries left - GAME OVER");
                        running = false;
                    }
                }
            }
        }

        private static void initGame()
        {
            triesLeft = maximumTries;

            lettersHistory = new List<char>();

            // get a random word from dictionnary
            Dictionary dictionary = new Dictionary();
            randomWord = dictionary.getRandomWord();
        }

        private static string getWordStatus()
        {
            string wordStatus = "";

            foreach (char character in randomWord)
            {
                char tmpLetter = '*'; 
                foreach (char letter in lettersHistory)
                {
                    if (character == letter)
                    {
                        tmpLetter = letter;
                        break;
                    }
                }
                wordStatus += tmpLetter;
            }
            return wordStatus;
        }

        private static char readLetterFromUser()
        {
            char guessedLetter;

            do
            {
                string userInput = Console.ReadLine();
                if (!String.IsNullOrEmpty(userInput))
                    guessedLetter = userInput[0];
                else
                    guessedLetter = '\0';

            } while (!Char.IsLetter(guessedLetter));

            return guessedLetter;
        }
    }
}




