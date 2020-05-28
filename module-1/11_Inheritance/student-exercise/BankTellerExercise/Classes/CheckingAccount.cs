namespace BankTellerExercise.Classes
{
    public class CheckingAccount : BankAccount
    {
        //override withdraw methods from bank account class
        public decimal OverDraftFee = 10.00M;

        public CheckingAccount(string accountHolderName, string accountNumber, decimal balance) : base(accountHolderName, accountNumber, balance)
        {

        }



        public override decimal Withdraw(decimal amountToWithdraw)
        {
            decimal newBalance = Balance - amountToWithdraw;
            decimal overAmountToWithdraw = amountToWithdraw + OverDraftFee;




            if (newBalance >= 0M)
            {

                Balance = newBalance;
                return Balance;
            }
            if (newBalance < 0M && newBalance >= -90.00M)
            {
                newBalance = newBalance - OverDraftFee;
                Balance = newBalance;
                return Balance;
            }
            if (Balance - amountToWithdraw < -100.00M || Balance - overAmountToWithdraw < -100.00M)
            {
                
                return Balance;
            }

            return Balance;
        }
        





    }
}
