using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises.Tests
{
    [TestClass]
   public class WordCountTests
    {
        [TestMethod]
        public void ReturnANewDictionary()
        {
            WordCount newArray = new WordCount();
            Dictionary<string, int> output = new Dictionary<string, int>();

            CollectionAssert.AreEqual(newArray.GetCount(new string[] { "ba", "ba", "black", "sheep" }),output{ { "ba" , 2},  "black": 1, "sheep": 1 }
        
        }
    }
}
