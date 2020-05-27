using System;
using System.Collections.Generic;
using System.Text;

namespace Accounts.Models
{
   public class SavingsAccount: BankAccount
    {
        public double InterestRate { get; set; }
        public SavingsAccount(decimal initialBal) : base(initialBal)
        {
            InterestRate = 0.0025;
        }

        public override decimal Withdraw(decimal amount)
        {
            //Do not allow overdraw
            if(amount > Balance)
            {
                return 0.00m;
            }
            return base.Withdraw(amount);
        }

        public override string DoMonthlyProcessing()
        {

            decimal interestAmount = Balance * (decimal)InterestRate / 12;
            Deposit(interestAmount);
            // could change balance from private set to protected so child classes can make changes. 
            return $"Savings was credited {interestAmount} interest earned. "

        }
    }
}
