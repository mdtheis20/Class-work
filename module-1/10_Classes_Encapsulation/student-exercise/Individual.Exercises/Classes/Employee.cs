namespace Individual.Exercises.Classes
{
    public class Employee
    {
        public int EmployeeId { get; }
        public string FirstName { get; }
        public string LastName { get; set; }
        public string FullName { get;  }

        public string Department { get; set; }  
        public double AnnualSalary { get; private set; }



        public Employee (int employeeID, string firstName, string lastName, double salary)
        {
            this.EmployeeId = employeeID;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.AnnualSalary = salary;
            string fullName = lastName + ", " + firstName;
            this.FullName = fullName;
       

        }


        public void RaiseSalary(double percent)
        {
            double raise = AnnualSalary / 100 * percent;
            AnnualSalary = AnnualSalary + raise;
        }

    }
}
