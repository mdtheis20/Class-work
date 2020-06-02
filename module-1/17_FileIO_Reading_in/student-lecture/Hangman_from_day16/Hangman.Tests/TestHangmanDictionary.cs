using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman.Tests
{
    [TestClass]
    public class TestHangmanDictionary
    {
        [TestMethod]
        public void TestDictionaryReturnsWord()
        {
            // Arrange
            HangmanDictionary dict = new HangmanDictionary();

            // Act
            string word = dict.FetchWord();

            //Assert
            Assert.IsTrue(word.Length >= 5 && word.Length <= 8);

        }
        [TestMethod]
        public void TestDictionaryReturns100UniqueWords()
        {
            // Arrange
            HangmanDictionary dict = new HangmanDictionary();

            // Act & Assert

            HashSet<string> previousWords = new HashSet<string>();
            for (int i = 1; i <= 100; i++)
            {
                string word = dict.FetchWord();
                if (previousWords.Contains(word))
                {
                    Assert.Fail($"Duplicate word returned from FetchWord: {word}");
                }
                else
                {
                    previousWords.Add(word);
                }
            }

            //Assert
            Assert.IsTrue(true, "No duplicate words were found after 100 tries.");

        }
    }
}
