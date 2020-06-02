using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises.Tests
{
    [TestClass]
   public class StringBitsTests
    {
        [TestMethod]
        public void ReturnStringOfBits()
        {
            StringBits newString = new StringBits();


            Assert.AreEqual(newString.GetBits("Dope"), "Dp");
            Assert.AreEqual(newString.GetBits("Cool"), "Co");
            Assert.AreEqual(newString.GetBits("giraffe"), "grfe");
            Assert.AreEqual(newString.GetBits("Tower"), "Twr");
            Assert.AreEqual(newString.GetBits("Browns"), "Bon");
        }
    }
}
