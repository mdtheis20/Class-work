using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercises.Tests
{
    [TestClass]

    public class CigarPartyTests
    {
        [TestMethod]
        public void WasThePartySuccessful()
        {
            CigarParty party = new CigarParty();



            Assert.AreEqual(party.HaveParty(30, false), false);
            Assert.AreEqual(party.HaveParty(50, false), true);
            Assert.AreEqual(party.HaveParty(70, true), true);
            Assert.AreEqual(party.HaveParty(20, true), false);
            Assert.AreEqual(party.HaveParty(80, false), false);
        }
    }
}
