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
         Given a string, return true if it ends in "ly".
         EndsLy("oddly") → true
         EndsLy("y") → false
         EndsLy("oddy") → false
         */
        public bool EndsLy(string str)
        {
            if (str.Length < 2)
            {
                return false;
            }
            if (str.Substring((str.Length - 2), 2) == "ly")
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
