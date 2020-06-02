using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hangman.Tests
{
    [TestClass]
    public class TestHangmanGame
    {
        [TestMethod]
        public void TestCreateGameWordToSolve()
        {
            //Arrange
            HangmanGame game = new HangmanGame("pizza");

            //Act
            string word = game.WordToSolve;

            // Assert
            Assert.AreEqual("pizza", word);
        }

        [DataTestMethod]
        [DataRow("pizza", "-----")]
        [DataRow("cheese", "------")]
        [DataRow("peppers", "-------")]
        public void TestClueWithNoGuesses(string wordToSolve, string expectedClue)
        {
            //Arrange
            HangmanGame game = new HangmanGame(wordToSolve);

            //Act

            string clue = game.Clue;


            //Assert

            Assert.AreEqual(expectedClue, clue);
            


        }

        [DataTestMethod]
        [DataRow("pizza", new char[] { 'p' }, "p----")]
        [DataRow("pizza", new char[] { 'p', 'x' }, "p----")]
        [DataRow("pizza", new char[] { 'x', 'p' }, "p----")]
        [DataRow("pizza", new char[] { 'z', 'p' }, "p-zz-")]
        [DataRow("pizza", new char[] { 'b', 'c' }, "-----")]
        //[DataRow("pizza", 'a', 1, "----a")]
        //[DataRow("pizza", 'o', 0, "-----")]
        //[DataRow("pizza", 'z', 2, "--zz-")]
        public void MultipleGuessesUpdatesClueAndGuessHistory(string wordToSolve, char[] guesses,  string expectedClue)
        {
            //Arrange
            HangmanGame game = new HangmanGame(wordToSolve);

            //Act
            foreach (char guess in guesses)
            {
                game.Guess(guess);
            }

            //Assert

            
            Assert.AreEqual(expectedClue, game.Clue);

            
            CollectionAssert.AreEqual(guesses, game.GuessHistory);
        }
    }
}
