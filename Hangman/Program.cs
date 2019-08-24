using System;

using System.Collections.Generic;
using System.Linq;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;

            List<char> userCharsHistory = new List<char>();
            int numberOfErrors = 0, discoveredLetters = 0, lettersToDiscover = 0;
            char userLetter;

            Dictionary dictionary = new Dictionary();
            string randomWord = dictionary.getRandomWord();
            lettersToDiscover = randomWord.Distinct().Count();

            GamePresentation presentationHandler = new GamePresentation();

            while (running)
            {
                presentationHandler.printHeader();
                presentationHandler.printHangman(numberOfErrors);
                presentationHandler.printAlphabet(userCharsHistory);
                presentationHandler.printWordStatus(randomWord, userCharsHistory);
                presentationHandler.printPlayerPrompt();

                userLetter = readLetterFromUser();
                if ( ! randomWord.ToUpper().Contains(userLetter))
                    numberOfErrors++;
                else
                {
                    if ( ! userCharsHistory.Contains(userLetter))
                        discoveredLetters++;
                }
                userCharsHistory.Add(userLetter);

                if (discoveredLetters == lettersToDiscover)
                {
                    Console.WriteLine("Victory! You found the word \"{0}\"", randomWord);
                    running = false;
                }
                else if(numberOfErrors == 7)
                {
                    Console.WriteLine("Game over! The word was \"{0}\"", randomWord);
                    running = false;
                }
                else
                    Console.Clear();

            }
            return;
        }

        private static char readLetterFromUser()
        {
            char guessedLetter;

            do
            {
                string userInput = Console.ReadLine();
                if ( ! String.IsNullOrEmpty(userInput))
                    guessedLetter = userInput[0];
                else
                    guessedLetter = '\0';

            } while ( ! Char.IsLetter(guessedLetter));

            return Char.ToUpper(guessedLetter);
        }

    }
}




