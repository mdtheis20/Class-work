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
                return false;
            }
        }


        public void AddAccount(IAccountable account)
        {
            accounts.Add(account);
        }
    }
}
