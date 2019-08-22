using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            char guessedLetter;
            string wordStatus = "";
            bool running = true;

            // initialize game variables
            initGame();
            Console.WriteLine(randomWord);

            while (running)
            {
                // ask user input (letter)
                Console.WriteLine("Number of tries left: {0}", triesLeft);
                Console.WriteLine("Try to guess a letter: ");
                guessedLetter = Console.ReadLine()[0];
                lettersHistory.Add(guessedLetter);

                // check if the word contains the letter
                if ( ! randomWord.Contains(guessedLetter))
                {
                    // remove one try if letter is not contained in the random word
                    triesLeft = triesLeft - 1;
                }
                else
                {
                    wordStatus = getWordStatus();
                    Console.WriteLine("Word to find: {0}", wordStatus);
                }


                //running = false;
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
    }
}




