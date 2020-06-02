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
    }
}
