using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hangman
{
    public enum GameStatus : int
    {
        InProgress,
        HasWon,
        HasLost
    }

    public class HangmanGame
    {
        static public int STARTING_NUMBER_GUESSES { get; } = 10;

        public HangmanGame(string wordToSolve)
        {
            this.WordToSolve = wordToSolve.Trim();
            this.Clue = new string('-', wordToSolve.Length);
            RemainingGuesses = STARTING_NUMBER_GUESSES;
            Status = GameStatus.InProgress;
            this.guessedList = new List<char>();
            //HasWon = false;
            //HasLost = false;
        }

        public string WordToSolve { get; set; }
        public string Clue { get; set; }
        public int RemainingGuesses { get; set; }
        //public bool HasWon { get; set; }
        //public bool HasLost { get; set; }
        public GameStatus Status { get; private set; }

        private List<char> guessedList;

        public char[] Guessed
        {
            get
            {
                return guessedList.ToArray();
            }
        }

        public int Guess(char charToGuess)
        {
            if (RemainingGuesses == 0)
            {
                return 0;
            }
            //if (WordToSolve.Contains(charToGuess))
            //{
            //    return 1;
            //}
            //return 0;
            //int numFound = WordToSolve.Count(c => c == charToGuess);

            // Update Clue
            int numFound = 0;
            //string newClue = "";
            //foreach (char c in WordToSolve)
            //{
            //    if (c == charToGuess)
            //    {
            //        newClue += c;
            //        numFound++;
            //    }
            //    else
            //    {
            //        newClue += "-";
            //    }
            //}
            //Clue = newClue;
            StringBuilder newClue = new StringBuilder(WordToSolve.Length);
            for (int i = 0; i < WordToSolve.Length; i++)
            {
                char c = WordToSolve[i];
                if (c == charToGuess)
                {
                    newClue.Append(c);
                    numFound++;
                }
                else
                {
                    newClue.Append(Clue[i]);
                }
            }
            Clue = newClue.ToString();
            RemainingGuesses--;
            guessedList.Add(charToGuess);

            // Test for a win or loss
            if (!Clue.Contains('-'))
            {
                //HasWon = true;
                Status = GameStatus.HasWon;
            }
            else if (RemainingGuesses == 0)
            {
                //HasLost = true;
                Status = GameStatus.HasLost;
            }

            return numFound;
        }
    }
}