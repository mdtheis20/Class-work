using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public partial class StringExercises
    {
        /*
         Given 2 strings, return their concatenation, except omit the first char of each. The strings will
         be at least length 1.
         NonStart("Hello", "There") → "ellohere"
         NonStart("java", "code") → "avaode"
         NonStart("shotl", "java") → "hotlava"
         */
        public string NonStart(string a, string b)
        {
            return a.Substring(1,a.Length - 1) + b.Substring(1,b.Length - 1);
        }
    }
}



//// 3. Now print out the first three and the last three characters
//// Output: Adaace
//Console.WriteLine($"First 3 + last 3: {name.Substring(0,3)} {name.Substring(name.Length -3, 3)} ");