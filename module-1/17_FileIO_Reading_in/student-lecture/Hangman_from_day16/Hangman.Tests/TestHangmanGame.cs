using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hangman.Tests
{
    [TestClass]
    public class TestHangmanGame
    {
        [TestMethod]
        public void TestWordToSolve()
        {
            // Arrange
            HangmanGame game = new HangmanGame("pizza");

            // Act
            string wordToSolve = game.WordToSolve;

            // Assert
            Assert.AreEqual("pizza", wordToSolve);
        }
        [TestMethod]
        public void TestWordToSolve_NeedsTrimmed()
        {
            // Arrange
            HangmanGame game = new HangmanGame("pizza  ");

            // Act
            string wordToSolve = game.WordToSolve;

            // Assert
            Assert.AreEqual("pizza", wordToSolve);
        }

        [DataTestMethod]
        [DataRow("pizza", "-----")]
        [DataRow("cheese", "------")]
        [DataRow("tomatoes", "--------")]
        public void TestClue(string wordToSolve, string expectedClue)
        {
            // Arrange
            HangmanGame game = new HangmanGame(wordToSolve);

            // Act
            string clue = game.Clue;

            // Assert
            Assert.AreEqual(expectedClue, clue);
        }

        [DataTestMethod]
        [DataRow("pizza", 'a', 1)]
        [DataRow("pizza", 'q', 0)]
        [DataRow("pizza", 'z', 2)]
        public void TestGuessResponse(string word, char guess, int expectedFound)
        {
            // Arrange
            HangmanGame game = new HangmanGame(word);

            // Act
            int numberFound = game.Guess(guess);

            // Assert
            Assert.AreEqual(expectedFound, numberFound);
        }


        [DataTestMethod]
        [DataRow("pizza", 'a', "----a")]
        [DataRow("pizza", 'q', "-----")]
        [DataRow("pizza", 'z', "--zz-")]
        public void TestClueUpdatesAfterGuess(string word, char guess, string expectedClue)
        {
            // Arrange
            HangmanGame game = new HangmanGame(word);

            // Act
            int numberFound = game.Guess(guess);

            // Assert
            Assert.AreEqual(expectedClue, game.Clue);

        }

        [DataTestMethod]
        [DataRow("pizza", 'a')]
        [DataRow("pizza", 'q')]
        [DataRow("pizza", 'z')]
        public void TestRemainingGuessesUpdatesAfterGuess(string word, char guess)
        {
            // Arrange
            HangmanGame game = new HangmanGame(word);
            int expectedRemainingGuesses = HangmanGame.STARTING_NUMBER_GUESSES;

            int numberFound = game.Guess(guess);
            expectedRemainingGuesses--;

            // Assert
            Assert.AreEqual(expectedRemainingGuesses, game.RemainingGuesses);

        }

        [DataTestMethod]
        [DataRow("pizza", new char[] { 'a' })]
        [DataRow("pizza", new char[] { 'q', 'a' })]
        [DataRow("pizza", new char[] { 'q', 'z', 'a' })]
        public void TestGuessesAfterMultipleGuesses(string word, char[] guesses)
        {
            // Arrange
            HangmanGame game = new HangmanGame(word);

            // Act
            foreach (char c in guesses)
            {
                game.Guess(c);
            }

            // Assert
            CollectionAssert.AreEqual(guesses, game.Guessed);
        }


        [DataTestMethod]
        [DataRow("pizza", new char[]{'a'}, "----a")]
        [DataRow("pizza", new char[] {'q', 'a'}, "----a")]
        [DataRow("pizza", new char[] {'q', 'z', 'a'}, "--zza")]
        public void TestGameAfterMultipleGuesses(string word, char[] guesses, string expectedClue)
        {
            // Arrange
            HangmanGame game = new HangmanGame(word);
            int expectedRemainingGuesses = HangmanGame.STARTING_NUMBER_GUESSES - guesses.Length;

            // Act
            foreach(char c in guesses)
            {
                game.Guess(c);
            }

            // Assert
            Assert.AreEqual(expectedRemainingGuesses, game.RemainingGuesses);
            Assert.AreEqual(expectedClue, game.Clue);
        }

        //[DataTestMethod]
        //[DataRow("pizza", new char[] { 'a' }, false, false)]
        //[DataRow("pizza", new char[] { 'a', 'z', 'i', 'p' }, true, false)]
        //[DataRow("pizza", new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j' }, false, true)]
        //[DataRow("pizza", new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'z', 'i', 'p' }, true, false)]
        //public void TestGameStatus(string word, char[] guesses, bool expectedHasWon, bool expectedHasLost)
        //{
        // Arrange
    //    HangmanGame game = new HangmanGame(word);
    //    int expectedRemainingGuesses = HangmanGame.STARTING_NUMBER_GUESSES - guesses.Length;

    //        // Act
    //        foreach (char c in guesses)
    //        {
    //            game.Guess(c);
    //        }

    //  // Assert
    //      Assert.AreEqual(expectedHasWon, game.HasWon);
    //      Assert.AreEqual(expectedHasLost, game.HasLost);
        //}

        [DataTestMethod]
        [DataRow("pizza", new char[] { 'a' }, GameStatus.InProgress)]
        [DataRow("pizza", new char[] { 'a', 'z', 'i', 'p' }, GameStatus.HasWon)]
        [DataRow("pizza", new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j' }, GameStatus.HasLost)]
        [DataRow("pizza", new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i' }, GameStatus.InProgress)]
        [DataRow("pizza", new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'z', 'i', 'p' }, GameStatus.HasWon)]
        public void TestGameStatus(string word, char[] guesses, GameStatus expectedStatus)
        {
            // Arrange
            HangmanGame game = new HangmanGame(word);
            int expectedRemainingGuesses = HangmanGame.STARTING_NUMBER_GUESSES - guesses.Length;

            // Act
            foreach (char c in guesses)
            {
                game.Guess(c);
            }

            // Assert
            Assert.AreEqual(expectedStatus, game.Status);
        }

    }
}
