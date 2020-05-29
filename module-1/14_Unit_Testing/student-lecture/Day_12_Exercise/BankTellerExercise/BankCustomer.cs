using System.Collections.Generic;

namespace BankTellerExercise
{
    public class BankCustomer
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        private List<IAccountable> accounts = new List<IAccountable>();

        public bool IsVip { 
            get 
            {
                int total = 0;
                foreach (IAccountable account in accounts)
                {
                    total += account.Balance;
                }
                return total >= 25000;
            } 
        }

        public IAccountable[] GetAccounts()
        {
            IAccountable[] accts = new IAccountable[accounts.Count];
            for (int i = 0; i < accts.Length; i++)
            {
                accts[i] = accounts[accts.Length - 1 - i];
            }
            return accts;
        }

        public void AddAccount(IAccountable account)
        {
            accounts.Add(account);
        }
    }
}
