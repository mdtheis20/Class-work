using System;
using System.Collections.Generic;
using System.Text;

namespace Accounts.Models
{
    public class CheckingAccount1 : BankAccount
    {
        public decimal TransactionFee { get; }
        private decimal overDraftFees = 0.0M;
        private int numberOfChecksWritten = 0;
        public CheckingAccount1(decimal initialBalance, decimal transactionFee) : base(initialBalance)
        {
            TransactionFee = transactionFee;
        }

        public override decimal Withdraw(decimal amount)
        {
            //Allow over-draft but charge a $5 fee
            if(amount > Balance)
            {
                overDraftFees += 5.00M;
            }
            return base.Withdraw(amount);
        }

        public void WriteCheck(decimal amount)
        {
            numberOfChecksWritten++;
            Withdraw(amount);

        }

        public override string DoMonthlyProcessing()
        {
            decimal totalFees = (numberOfChecksWritten * TransactionFee) + overDraftFees;
            Balance -= totalFees;

            numberOfChecksWritten = 0;

            return $"Checking was charged {totalFees} in transaction / overdraft fees.";

        }

    }
}
