using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankTellerExercise.Tests
{
    [TestClass]
    public class SavingsAccountTests
    {
        [TestMethod]
        public void Constructor_twoParameters()
        {
            // Arrange
            string testAccountHolder = "Mike";
            string testAccountNumber = "123";

            // Act
            SavingsAccount savings = new SavingsAccount(testAccountHolder, testAccountNumber);

            // Assert (verify)
            Assert.AreEqual(testAccountHolder, savings.AccountHolderName);
            Assert.AreEqual(testAccountNumber, savings.AccountNumber);
            Assert.AreEqual(0, savings.Balance);
        }

        [TestMethod]
        public void Constructor_threeParameters()
        {
            // Arrange
            string testAccountHolder = "Mike";
            string testAccountNumber = "123";
            int testInitialBalance = 500;

            // Act
            SavingsAccount savings = new SavingsAccount(testAccountHolder, testAccountNumber, testInitialBalance);

            // Assert (verify)
            Assert.AreEqual(testAccountHolder, savings.AccountHolderName);
            Assert.AreEqual(testAccountNumber, savings.AccountNumber);
            Assert.AreEqual(testInitialBalance, savings.Balance);
        }

        [TestMethod]
        public void Constructor_threeParametersWithNegativeBalance()
        {
            // Arrange
            string testAccountHolder = "Mike";
            string testAccountNumber = "123";
            int testInitialBalance = -100;

            // Act
            SavingsAccount savings = new SavingsAccount(testAccountHolder, testAccountNumber, testInitialBalance);

            // Assert (verify)
            Assert.IsNotNull(savings);
            Assert.IsInstanceOfType(savings, typeof(BankAccount));
            Assert.AreEqual(testAccountHolder, savings.AccountHolderName);
            Assert.AreEqual(testAccountNumber, savings.AccountNumber);
            Assert.AreEqual(0, savings.Balance);
        }

        [DataTestMethod]
        [DataRow(500, 500)]
        [DataRow(-100, 0)]
        [DataRow(0, 0)]
        [DataRow(150, 150)]
        public void Constructor_threeParametersData(int testInitialBalance, int expectedBalance)
        {
            // Arrange
            string testAccountHolder = "Mike";
            string testAccountNumber = "123";

            // Act
            SavingsAccount savings = new SavingsAccount(testAccountHolder, testAccountNumber, testInitialBalance);

            // Assert (verify)
            Assert.IsNotNull(savings);
            Assert.IsInstanceOfType(savings, typeof(BankAccount));
            Assert.AreEqual(testAccountHolder, savings.AccountHolderName);
            Assert.AreEqual(testAccountNumber, savings.AccountNumber);
            Assert.AreEqual(expectedBalance, savings.Balance);
        }


    }
}
