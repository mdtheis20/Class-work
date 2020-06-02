using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises.Tests
{
    [TestClass]
   public class Lucky13Testscs
    {
        [TestMethod]
        public void ContainsNoOnesOrThrees()
        {

            Lucky13 nums = new Lucky13();

            Assert.AreEqual(nums.GetLucky(new int[] { 2, 4, 6 }), true);
            Assert.AreEqual(nums.GetLucky(new int[] { 1, 4, 6 }), false);
            Assert.AreEqual(nums.GetLucky(new int[] { 2, 4, 6, 3 }), false);
            Assert.AreEqual(nums.GetLucky(new int[] { 2, 4, 6, 8, 7,  }), true);
            Assert.AreEqual(nums.GetLucky(new int[] { 2, 4, 6, 9, 2, 4, 3, 5 }), false);
            Assert.AreEqual(nums.GetLucky(new int[] { 1, 2, 3 }), false);
        }
    }
}
