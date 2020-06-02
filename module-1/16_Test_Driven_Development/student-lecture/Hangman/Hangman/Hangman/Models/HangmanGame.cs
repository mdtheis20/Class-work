using System;
using System.Collections.Generic;
using System.Linq;

namespace Hangman
{
    public class HangmanGame
    {
        

        public HangmanGame(string wordToSolve)
        {
            WordToSolve = wordToSolve;
            Clue = new string('-', wordToSolve.Length);
            guessHistory = new List<char>();
        }

        public string WordToSolve { get; }
        public string Clue { get; private set; }

        private List<char> guessHistory;
        public char[] GuessHistory
        {
            get
            {
                return guessHistory.ToArray();
            }
        }

        public int Guess(char guess)
        {

            guessHistory.Add(guess);
           //int count =  return WordToSolve.Count(c => c == guess); Linq shortcut
           // had to comment out anyway becuase next step needed a for  loop
            //Look for the character in the word to solve
            int count = 0;
            string newClue = "";

            //foreach (char c in WordToSolve) (((step one)))
            //{
            //    if (c == guess)
            //    {
            //        count++;
            //    }
            //}

            for (int i = 0; i < WordToSolve.Length; i++)
            {
                if (WordToSolve[i] == guess)
                {
                    count++;
                    newClue += guess;
                }
                else
                {
                    newClue += Clue[i];
                }
            }
            //UPdate CLue to contain the guessed letters
            Clue = newClue;
            return count;
        }
    }
}