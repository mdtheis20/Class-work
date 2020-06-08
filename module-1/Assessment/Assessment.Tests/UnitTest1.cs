using Assessment.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assessment.Tests
{
    [TestClass]
    public class HotelReservationTest
    {
        [TestMethod]
        public void ReturnFinalTotal()
        {

            HotelReservation reservation = new HotelReservation();

            Assert.AreEqual(reservation.FinalTotal(true, true, 5) 360.92M);

        }
    }
}
