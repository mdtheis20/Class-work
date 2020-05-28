namespace BankTellerExercise.Classes
{
    public class SavingsAccount : BankAccount
    {
        public decimal ServiceFee = 2.00M;
        public SavingsAccount(string accountHolderName, string accountNumber, decimal balance) : base(accountHolderName, accountNumber, balance)
        {
            
        }


        public override decimal Withdraw(decimal amountToWithdraw)
        {
            decimal newBalance = Balance - amountToWithdraw;
            decimal extraWithdraw = amountToWithdraw + ServiceFee;

            if (amountToWithdraw >= Balance)
            {
                
                return Balance;
            }
            if (Balance < 152.00M)
            {
                Balance = Balance - extraWithdraw;
                return Balance;
            } 
            if (Balance > 150M && Balance > amountToWithdraw)
            {
                Balance = newBalance;
            }
          
           
            return Balance;
        }
    }
}
