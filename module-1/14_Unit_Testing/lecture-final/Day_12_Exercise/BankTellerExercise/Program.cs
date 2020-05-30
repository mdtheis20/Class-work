using System;

namespace BankTellerExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            BankCustomer customer = new BankCustomer()
            {
                Name = "Mike",
                Address = "Richfield, OH",
                PhoneNumber = "555-1234"
            };

            SavingsAccount savings = new SavingsAccount("Mike", "123");
            savings.Deposit(20000);
            customer.AddAccount(savings);

            CheckingAccount checking = new CheckingAccount("Mike", "345");
            checking.Deposit(4000);
            customer.AddAccount(checking);

            CreditCardAccount cc = new CreditCardAccount("Mike", "567");
            cc.Charge(2000);
            customer.AddAccount(cc);

            PrintSummary(customer);

            savings.Deposit(1500);
            savings.TransferTo(checking, 2000);
            cc.Pay(1500);

            PrintSummary(customer);

        }

        static void PrintSummary(BankCustomer cust)
        {
            Console.WriteLine("================================================================================");
            Console.WriteLine($"Customer {cust.Name} isVIP: {cust.IsVip}");
            foreach (IAccountable acct in cust.GetAccounts())
            {
                Console.WriteLine($"\tAccount: {acct.GetType(), -40} {acct.Balance, 10:C}");
            }
        }
    }
}
