﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public partial class StringExercises
    {
        /*
         Given a string and a non-negative int n, return a larger string that is n copies of the original string.
         StringTimes("Hi", 2) → "HiHi"
         StringTimes("Hi", 3) → "HiHiHi"
         StringTimes("Hi", 1) → "Hi"
         */
        public string StringTimes(string str, int n)
        {
            string newString = str;
            if (n == 0)
            {
                return "";
            }
            for (int i = 1; i < n; i++)
            {
                newString += str;
            }
            return newString;
        }
    }
}
