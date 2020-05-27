using System;
using System.Collections.Generic;
using System.Text;

namespace Accounts.Models
{
   public class BankAccount
    {
        //Account number, readonly, settable only in the constructor
        public string AccountNumber { get;  }
        public decimal Balance { get; protected set; }

        public BankAccount(decimal balance)
        {
            //TODO assign new account number here
            this.Balance = balance;
        }

        public decimal Deposit(decimal amount)
        {
            Balance += amount;
            return Balance;
        }

        virtual public decimal Withdraw(decimal amount)
        {
            Balance -= amount;
            return amount;
        }

        virtual public string DoMonthlyProcessing()
        {
            return "";
        }
    }
}
