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
         Given a string and a non-negative int n, we'll say that the front of the string is the first 3 chars, or
         whatever is there if the string is less than length 3. Return n copies of the front;
         FrontTimes("Chocolate", 2) → "ChoCho"
         FrontTimes("Chocolate", 3) → "ChoChoCho"
         FrontTimes("Abc", 3) → "AbcAbcAbc"
         */
        public string FrontTimes(string str, int n)
        {
            string newString = str;
            if ( n == 0)
            {
                return "";
            }
            if (str.Length >= 3)
            {
                 newString = str.Substring(0, 3);
                for (int i = 1; i < n; i++)
                {
                    newString += str.Substring(0, 3);
                    
                }
            }
            if (str.Length == 2)
            {
                 newString = str.Substring(0, 2);
                for (int i = 1; i < n; i++)
                {
                    newString += str.Substring(0, 2);
                    
                }
            }
            if ( str.Length == 1)
            {
                 
                
                for (int i = 1; i < n; i++)
                {
                    newString += str;
                    
                }
            }
            return newString;
            
          
        }

    }
}
//string newString = str;
//            if (n == 0)
//            {
//                return "";
//            }
//            for (int i = 1; i<n; i++)
//            {
//                newString += str;
//            }
//            return newString;