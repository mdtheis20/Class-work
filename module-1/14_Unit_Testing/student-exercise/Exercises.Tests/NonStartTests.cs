using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises.Tests
{
    [TestClass]
    public class NonStartTests
    {
        [TestMethod]
        public void ReturnConcatenatedString()
        {
            NonStart startString = new NonStart();


            Assert.AreEqual("ellohere", startString.GetPartialString("Hello", "There"));
        
        }
    }
}
