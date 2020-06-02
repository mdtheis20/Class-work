using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises.Tests
{
    [TestClass]
    public class AnimalGroupNameTests
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
            Assert.AreEqual(animal.GetHerd("CROW"), "Murder");
            Assert.AreEqual(animal.GetHerd("Flamingo"), "Pat");
            Assert.AreEqual(animal.GetHerd("FLAMINGO"), "Pat");
            Assert.AreEqual(animal.GetHerd("Lion"), "Pride");
        }
    }

}
