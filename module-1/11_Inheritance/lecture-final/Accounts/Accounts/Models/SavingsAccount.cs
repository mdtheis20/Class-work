using System;
using System.Collections.Generic;
using System.Text;

namespace Accounts.Models
{
    public class SavingsAccount : BankAccount
    {
        public double InterestRate { get; set; }
        public SavingsAccount(decimal initialBal) : base(initialBal)
        {
            InterestRate = 0.0025;
        }

        public override decimal Withdraw(decimal amount)
        {
            // Do not allow overdraw
            if (amount > Balance)
            {
                return 0.00M;
            }
            return base.Withdraw(amount);
        }

        public override string DoMonthlyProcessing()
        {
            decimal interestAmount = Balance * (decimal)InterestRate / 12;
            Balance += interestAmount;
            return $"Savings was credited {interestAmount:C} interest earned.";
        }
    }
}
