using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankTellerExercise.Tests
{
    [TestClass]
    public class SavingsAccountTests
    {
        [TestMethod]
        public void Constructor_twoParameters()
        {

            //Arrange
            string testAccountHolder = "Matt";
            string testAccountNumber = "123";
            int testInitialBalance = 500;

            //Act
            SavingsAccount savings = new SavingsAccount("Matt", "123");


            //Assert  (verify)
            Assert.AreEqual("Matt", savings.AccountHolderName);
            Assert.AreEqual("123", savings.AccountNumber);
            Assert.AreEqual(0, savings.Balance);
            
        }

        [TestMethod]
        public void Constructor_threeParameters()
        {
            //Arrange
            string testAccountHolder = "Matt";
            string testAccountNumber = "123";
            int testInitialBalance = 500;

            //Act
            SavingsAccount savings = new SavingsAccount(testAccountHolder, testAccountNumber, testInitialBalance);


            //Assert  (verify)
            Assert.AreEqual(testAccountHolder, savings.AccountHolderName);
            Assert.AreEqual(testAccountNumber, savings.AccountNumber);
            Assert.AreEqual(testInitialBalance, savings.Balance);
        }


        [TestMethod]
        public void Constructor_threeParametersWithNegativeBalance()
        {
            //Arrange
            string testAccountHolder = "Matt";
            string testAccountNumber = "123";
            int testInitialBalance = -100;

            //Act
            SavingsAccount savings = new SavingsAccount(testAccountHolder, testAccountNumber, testInitialBalance);


            //Assert  (verify)
            Assert.AreEqual(testAccountHolder, savings.AccountHolderName);
            Assert.AreEqual(testAccountNumber, savings.AccountNumber);
            Assert.AreEqual(testInitialBalance, savings.Balance);
        }
    }
}

