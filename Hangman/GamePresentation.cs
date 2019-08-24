using System;
using System.Collections.Generic;

namespace Hangman
{
    class GamePresentation
    {
        private int charactersPerLine = 31;

        public void printLine(char placeHolderChar, string text = "")
        {
            string line = "";
            int textStartPosition = -1, textEndPosition = -1;

            if (!string.IsNullOrEmpty(text))
            {
                textStartPosition = ((charactersPerLine - 2) - text.Length) / 2;
                textEndPosition = textStartPosition + text.Length;
            }

            for (int i = 0; i < charactersPerLine - 2; i++)
            {
                if (i >= textStartPosition && i < textEndPosition)
                {
                    //Console.WriteLine(i - textStartPosition);
                    line += text[i - textStartPosition];
                }
                else
                {
                    line += placeHolderChar;
                }
            }
            Console.WriteLine("+{0}+", line);
        }

        public void printHeader()
        {
            printLine('-');
            printLine(' ', "Hangman");
            printLine('-');
        }

        public void printHangman(int tries)
        {
            if (tries >= 1)
                printLine(' ', "|");

            if (tries >= 2)
                printLine(' ', "O");

            string text = "";
            if (tries >= 3)
            {
                switch (tries)
                {
                    case 3: text = "|"; break;
                    case 4: text = "/| "; break;
                    default: text = "/|\\"; break;
                }
            }
            printLine(' ', text);

            text = "";
            if (tries >= 6)
            {
                switch (tries)
                {
                    case 6: text = "/ "; break;
                    default: text = "/ \\"; break;
                }
            }
            printLine(' ', text);

            printLine(' ');
            printLine('-');
        }

        public void printAlphabet(List<char> userCharsHistory)
        {
            string text = " ";
            for (char c = 'A'; c <= 'Z'; c++)
            {
                if(userCharsHistory.Contains(c))
                    text += " ";
                else
                    text += c;
                text += " ";

                if (c == 'M' || c == 'Z')
                {
                    printLine(' ', text);
                    text = " ";
                }
            }
            printLine('-');
        }

        public void printWordStatus(string wordToGuess, List<char> userCharsHistory)
        {
            string textToDisplay = "";
            foreach (char character in wordToGuess)
            {
                char letterToDisplay = '_';
                foreach (char letter in userCharsHistory)
                {
                    if (Char.ToUpper(character) == Char.ToUpper(letter))
                    {
                        letterToDisplay = letter;
                        break;
                    }
                }
                textToDisplay += Char.ToUpper(letterToDisplay);
            }
            printLine(' ', textToDisplay);
            printLine('-');
        }
        public void printPlayerPrompt()
        {
            Console.WriteLine("Enter a letter: ");
        }
    }
}

/*
    +-----------------------------+
    +           Hangman           +
    +-----------------------------+
    +              |              +
    +              O              +
    +             /|\             +
    +             / \             +
    +                             +
    +-----------------------------+
    +  A B C D E F G H I J K L M  +
    +  N O P Q R S T U V W X Y Z  +
    +-----------------------------+
    + _ _ _ _ _ _ _ _ _ _ _ _ _ _ +
    +-----------------------------+
    Enter a letter:       
    
*/
