using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public class KataFizzBuzz
    {
        
        public string FizzBuzz(int v)
        {
            string newString = Convert.ToString(v);
            

            if (v % 3 == 0 && v % 5 == 0)
            {
                return "FizzBuzz";
            }

            if (v % 3 == 0 || newString.Contains("3"))
            {
                
                
                return "Fizz";
            }
            
            if (v % 5 == 0 || newString.Contains("5"))
            {
                return "Buzz";
            }

            if (v < 1 || v > 100)
            {
                return "";
            }

            return $"{v}";
        }
    }
}
