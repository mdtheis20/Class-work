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
            if (v % 3 == 0)
            {
                return "Fizz";
            }
            
            if (v % 5 == 0)
            {
                return "Buzz";
            }
            return $"{v}";
        }
    }
}
