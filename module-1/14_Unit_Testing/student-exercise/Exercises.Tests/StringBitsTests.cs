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
        public void ReturnGroupNameToAnimalName()
        {
            AnimalGroupName animal = new AnimalGroupName();


            Assert.AreEqual(animal.GetHerd("rhino"), "Crash");
            Assert.AreEqual(animal.GetHerd("RHino"), "Crash");
            Assert.AreEqual(animal.GetHerd("giraffe"), "Tower");
            Assert.AreEqual(animal.GetHerd("GIRaffe"), "Tower");
            Assert.AreEqual(animal.GetHerd("crow"), "Murder");
        }
    }
}
