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
        public char[] GuessHistory {
            get
            {
                return guessHistory.ToArray();
            }
        }

        public int Guess(char guess)
        {
            // This is the Linq way to get a count of matches
            //int count = WordToSolve.Count( c => c == guess );

            guessHistory.Add(guess);
            // Look for the character in the word to solve
            int count = 0;
            string newClue = "";
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

            // Update Clue to contain the guessed letters
            Clue = newClue;
            return count;

        }
    }
}