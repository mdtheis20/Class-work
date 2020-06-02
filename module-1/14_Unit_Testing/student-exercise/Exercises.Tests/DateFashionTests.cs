using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises.Tests
{
    [TestClass]
    public class DateFashionTests
    {
        [TestMethod]
        public void WillTheyGetATable()
        {
            DateFashion style = new DateFashion();


            Assert.AreEqual(style.GetATable(5, 10), 2);
            Assert.AreEqual(style.GetATable(5, 2), 0);
            Assert.AreEqual(style.GetATable(5, 5), 1);
            Assert.AreEqual(style.GetATable(8, 8), 2);
            Assert.AreEqual(style.GetATable(8, 2), 0);
        }
    }
}
