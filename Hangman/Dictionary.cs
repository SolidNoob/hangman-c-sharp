using System;

namespace Hangman
{
    class Dictionary
    {
        public string getRandomWord(int length = 7)
        {
            string[] words = {
                "programming",
                "coding",
                "function",
                "method",
                "brackets",
                "php",
                "csharp",
                "python",
                "laravel",
                "javascript",
                "class",
                "framework",
                "collection",
            };
            int randomIndex = getRandomNumber(0, (words.Length - 1));

            return words[randomIndex];
        }

        private int getRandomNumber(int min, int max)
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(min, max + 1);
            return randomNumber;
        }
    }
}