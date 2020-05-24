using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechElevator.Classes
{
    public class Company
    {
        

        public string Name { get; set; }
        public int NumberOfEmployees { get; set; }
        public decimal Revenue { get; set; }
        public decimal Expenses { get; set; }
        //GetCompanySize()	string	Returns "small" if less than 50 employees,
        //"medium" if between 50 and 250 employees,
        //"large" if greater than 250 employees.

        //and
        
        //GetProfit() decimal returns the result of revenue - expenses
        public string GetCompanySize()
        {
            if (NumberOfEmployees < 50)
            {
                return "small";
            }
            if (NumberOfEmployees >= 50 && NumberOfEmployees <= 250)
            {
                return "medium";
            }
            
            
                return "large";
            
        }


        public decimal GetProfit()
        {
            decimal profit = Revenue - Expenses;
            return profit;
        }

       


    }
}
