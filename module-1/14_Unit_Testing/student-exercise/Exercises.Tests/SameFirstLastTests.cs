using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises.Tests
{
    [TestClass]
    public class SameFirstLastTests
    {
        [TestMethod]
        public void AreTheFirstAndLastIntsEqual()
        {
            SameFirstLast intArray = new SameFirstLast();


            Assert.AreEqual(intArray.IsItTheSame(new int[] { 1, 2, 3 }), false);
            Assert.AreEqual(intArray.IsItTheSame(new int[] { 1, 2, 1 }), true);
            Assert.AreEqual(intArray.IsItTheSame(new int[] { 1, 2, 3, 2, 1 }), true);
            Assert.AreEqual(intArray.IsItTheSame(new int[] { 1, 2, 3, 4, 1, 2 }), false);
        }
    }
}
