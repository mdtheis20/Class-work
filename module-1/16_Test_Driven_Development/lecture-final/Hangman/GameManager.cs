using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman
{
    class GameManager
    {
        #region Hard-coded word list (to be replaced by HangmanDictionary)

        private string FetchWord()
        {
            List<string> dictionary = new List<string>()
            {
                "short",
                "pitcher",
                "umpire",
                "third",
                "outfield"
            };

            Random rand = new Random();
            int index = rand.Next(0, dictionary.Count);
            return dictionary[index];
        }
        #endregion

        /// <summary>
        /// Creates a loop inside which creates a new HangmanGame and runs it to completion. Games continue until the user stops.
        /// </summary>
        public void Run()
        {
            // TODO: When we have a dictionary...
            //HangmanDictionary dictionary = new HangmanDictionary();

            // Run until the user chooses to quit
            while (true)
            {
                // TODO: When we have a dictionary...
                //HangmanGame game = new HangmanGame(dictionary.FetchWord());
                HangmanGame game = new HangmanGame(FetchWord());

                // This is the guessing loop of a single game.
                while (game.Status == GameStatus.InProgress)
                {
                    // Print the current status
                    Console.Clear();
                    Console.WriteLine($"Guesses remaining: {game.RemainingGuesses}.  Guessed: {string.Join(" ", game.Guessed)}");

                    // Ask for a guess
                    Console.WriteLine($"Clue: {game.Clue}");
                    Console.Write("Please enter a character: ");
                    string input = Console.ReadLine().Trim().ToLower();
                    if (input.Length == 0)
                    {
                        continue;
                    }

                    // Provide the user's guess to the game
                    int numFound = game.Guess(input[0]);
                    Console.WriteLine($"'{input[0]}' was found {numFound} times. Press Enter to continue.");
                    Console.ReadLine();
                }

                // Inner loop exited, so Check for Won or Lost
                switch (game.Status)
                {
                    case GameStatus.HasWon:
                        Console.WriteLine($"Congratulations! You won in {HangmanGame.STARTING_NUMBER_GUESSES - game.RemainingGuesses} guesses! The word was '{game.WordToSolve}'");
                        Console.ReadLine();
                        break;
                    case GameStatus.HasLost:
                        Console.WriteLine($"Sorry, you lost!  The word was '{game.WordToSolve}'");
                        Console.ReadLine();
                        break;
                }

                // Allow the user to continue or break the outer loop (multiple games)
                Console.Clear();
                Console.Write("Press Enter to Continue, Q to Quit: ");
                string s = Console.ReadLine();
                if (s.Length > 0 && s.ToLower()[0] == 'q')
                {
                    break;
                }
            }
        }
    }
}
