using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises.Tests
{
    [TestClass]
   public class Less20Tests
    {
        [TestMethod]
        public void IsOneOrTwoLessThanMultipleOfTwenty()
        {

            Less20 number = new Less20();

            Assert.AreEqual(number.IsLessThanMultipleOf20(18), true);
            Assert.AreEqual(number.IsLessThanMultipleOf20(19), true);
            Assert.AreEqual(number.IsLessThanMultipleOf20(238), true);
            Assert.AreEqual(number.IsLessThanMultipleOf20(17), false);
            Assert.AreEqual(number.IsLessThanMultipleOf20(237), false);

        }
    }
}
