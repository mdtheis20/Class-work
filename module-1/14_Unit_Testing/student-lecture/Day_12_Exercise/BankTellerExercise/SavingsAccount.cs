namespace BankTellerExercise
{
    public class SavingsAccount : BankAccount
    {
        public SavingsAccount(string accountHolder, string accountNumber) : base(accountHolder, accountNumber)
        {

        }

        public SavingsAccount(string accountHolder, string accountNumber, int balance) : base(accountHolder, accountNumber, balance)
        {

        }

        public override int Withdraw(int amountToWithdraw)
        {
            // only perform transaction of positive $ and room for fee
            if (Balance - amountToWithdraw >= 0)  // Was 2, introduced a bug
            {
                base.Withdraw(amountToWithdraw);
                // Assess $2 fee if it goes below $150
                if (Balance <= 150)  // was <, introduced a bug
                {
                    base.Withdraw(2);
                }
            }
            return Balance;
        }
    }
}
