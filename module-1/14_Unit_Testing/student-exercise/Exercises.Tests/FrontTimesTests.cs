using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises.Tests
{
    [TestClass]
   public class FrontTimesTests
    {
        [TestMethod]
        public void ReturnCopiesOfTheFront()
        {
            FrontTimes front = new FrontTimes();


            Assert.AreEqual(front.GenerateString("Chocolate", 2), "ChoCho");
            Assert.AreEqual(front.GenerateString("Chocolate", 3), "ChoChoCho");
            Assert.AreEqual(front.GenerateString("Abc", 3), "AbcAbcAbc");
            Assert.AreEqual(front.GenerateString("Mt", 4), "MtMtMtMt");
            Assert.AreEqual(front.GenerateString("Browns", 2), "BroBro");
        }
    }
}
