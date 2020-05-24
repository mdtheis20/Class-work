using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechElevator.Classes
{
    public class Person
    {
        //Class Code Goes Here
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }



        public string GetFullName()
        {
            string fullName = FirstName + " " +  LastName;
            return fullName;
        }

        public bool IsAdult()
        {
            if (Age >= 18)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}



//public string Name { get; set; }
//public int NumberOfEmployees { get; set; }
//public decimal Revenue { get; set; }
//public decimal Expenses { get; set; }