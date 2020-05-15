﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public partial class Exercises
    {
        /*
        The squirrels in Palo Alto spend most of the day playing. In particular, they play if the temperature
        is between 60 and 90 (inclusive). Unless it is summer, then the upper limit is 100 instead of 90. Given
        an int temperature and a bool isSummer, return true if the squirrels play and false otherwise.
        SquirrelPlay(70, false) → true
        SquirrelPlay(95, false) → false
        SquirrelPlay(95, true) → true
        */
        public bool SquirrelPlay(int temp, bool isSummer)
        {
            if (isSummer == true)
            {
                if ( temp >= 60 && temp <= 100)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if ( temp >= 60 && temp <= 90)
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
}



 //if (isWeekend == true)    Using these previous problems to help guide me
 //           {
 //               if (cigars >= 40)
 //               {
 //                   return true;
 //               }
 //           }
 //           else
 //           {
 //               if (cigars >= 40 && cigars <= 60)
 //               {
 //                   return true;
 //               }
 //               else
 //               {
 //                   return false;
 //               }
 //           }
 //           return false;