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
         Given a string, return true if the first instance of "x" in the string is immediately followed by another "x".
         DoubleX("axxbb") → true
         DoubleX("axaxax") → false
         DoubleX("xxxxx") → true
         */
        public bool DoubleX(string str)
        {
            int ix = str.IndexOf('x');
            int ixx = str.IndexOf("xx");
            if ( str.Length < 2)
            {
                return false;
            }
            if ( ix < 0)
            {
                return false;
            }
            if ( ix == ixx)
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


//int hailMary = str.IndexOf('x');
//            if (str.Length< 2)
//            {
//                return false;
//            }
//            if (str.Length >= 2)
//            {
//                if (str.Substring(hailMary, 2) == "xx")
//                {
//                    return true;
//                }
//            }
//            else
//            {
//                return false;
//            }

            
//            return false;