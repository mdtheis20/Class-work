using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises.Tests
{
    [TestClass]
   public class MaxEnd3Tests
    {
        [TestMethod]
        public void ReturnNewArray()
        {

            MaxEnd3 newArray = new MaxEnd3();

            CollectionAssert.AreEqual(newArray.MakeArray(new int[] { 1, 2, 3 }), (new int[] { 3, 3, 3 }));
            CollectionAssert.AreEqual(newArray.MakeArray(new int[] { 1, 2, 3, 7 }), (new int[] { 7, 7, 7, 7 }));
            CollectionAssert.AreEqual(newArray.MakeArray(new int[] { 11, 18, 3 }), (new int[] { 11, 11, 11 }));
            CollectionAssert.AreEqual(newArray.MakeArray(new int[] { 4, 2, 3 }), (new int[] { 4, 4, 4 }));
            

        }
    }
}
