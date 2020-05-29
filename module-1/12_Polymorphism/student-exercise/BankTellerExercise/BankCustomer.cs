using System;
using System.Collections.Generic;
using System.Text;

namespace BankTellerExercise
{
    class BankCustomer
    {
        private List<IAccountable> accounts = new List<IAccountable>();


        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsVip
        {
            get
            {
                int toalBalance = 0;
                foreach (IAccountable acct in this.accounts )
                {
                    toalBalance += acct.Balance;
                }
                return (toalBalance >= 25000);
            }
        }


        public void AddAccount(IAccountable account)
        {
            accounts.Add(account);
        }

        public IAccountable[] GetAccounts()
        {
            IAccountable[] accts = this.accounts.ToArray();
            if (this.accounts[0] == accts[0])
            {
                Console.WriteLine("Same!");
            }
            return accts;
        }

    }
}
