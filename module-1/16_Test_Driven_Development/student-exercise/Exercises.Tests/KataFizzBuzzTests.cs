using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises.Tests
{
    [TestClass()]
    public class KataFizzBuzzTests
    {
        [TestMethod]
        public void ReturnFizzIfDivisibleBy3()
        {
            //arrange
            KataFizzBuzz fb = new KataFizzBuzz();

            string result = fb.FizzBuzz(3);

            Assert.AreEqual("Fizz", result);
        }
        [TestMethod]
        public void ReturnFizzIfDivisibleBy5()
        {
            //arrange
            KataFizzBuzz fb = new KataFizzBuzz();

            string result = fb.FizzBuzz(5);

            Assert.AreEqual("Buzz", result);
        }
        [TestMethod]
        public void ReturnFizzIfDivisibleBy3And5()
        {
            //arrange
            KataFizzBuzz fb = new KataFizzBuzz();

            string result = fb.FizzBuzz(15);

            Assert.AreEqual("FizzBuzz", result);
        }

        [TestMethod]
        public void ReturnStringIfBetween1And100AndNotDivisibleBy3Or5()
        {
            //arrange
            KataFizzBuzz fb = new KataFizzBuzz();

            string result = fb.FizzBuzz(22);

            Assert.AreEqual("22", result);
        }

        [TestMethod]
        public void ReturnEmptyifNotBetween1and100()
        {
            //arrange
            KataFizzBuzz fb = new KataFizzBuzz();

            string result = fb.FizzBuzz(107);

            Assert.AreEqual("22", result);
        }

    }
}
