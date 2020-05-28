namespace BankTellerExercise.Classes
{
    public class BankAccount
    {
        public string AccountHolderName { get; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; protected set; }

        public BankAccount(string accountHolderName, string accountNumber)
        {
            this.AccountHolderName = accountHolderName;
            this.AccountNumber = accountNumber;
            Balance = 0;
        }

        public BankAccount(string accountHolderName, string accountNumber, decimal balance)
        {
            this.AccountHolderName = accountHolderName;
            this.AccountNumber = accountNumber;
            this.Balance = balance;
        }








        virtual public decimal Deposit(decimal amountToDeposit)
        {
            decimal newBalance = Balance + amountToDeposit;
            Balance = newBalance;
            return Balance;
        }

        virtual public decimal Withdraw(decimal amountToWithdraw)
        {
            decimal newBalance = Balance - amountToWithdraw;
            Balance = newBalance;
            return Balance;
        }
    }
}
