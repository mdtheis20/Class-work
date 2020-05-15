using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises
{
    public partial class Exercises
    {
        /*
         When squirrels get together for a party, they like to have cigars. A squirrel party is successful
         when the number of cigars is between 40 and 60, inclusive. Unless it is the weekend, in which case
         there is no upper bound on the number of cigars. Return true if the party with the given values is
         successful, or false otherwise.
         CigarParty(30, false) → false
         CigarParty(50, false) → true
         CigarParty(70, true) → true
         */
        public bool CigarParty(int cigars, bool isWeekend)
        {
            if (isWeekend == true)
            {
                if ( cigars >= 40)
                {
                    return true;
                }
            }
            else
            {
                if ( cigars >= 40 && cigars <= 60)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

    }
}



   //if ((speed >= 81 && isBirthday == false) || (speed >= 86 && isBirthday == true))
   //         {
   //             return 2;
   //         }
   //         if ((speed >= 61 && speed <= 80 && isBirthday == false) || (speed >= 66 && speed <= 85 && isBirthday == true))
   //         {
   //             return 1;
   //         }
   //         if ((speed <= 60 && isBirthday == false) || (speed <= 65 && isBirthday == true))
   //         {
   //             return 0;
   //         }
   //         return 0;
            //if (isBirthday == true)
            //{
            //    if (speed >= 86)
            //    {
            //        return 2;
            //    }
            //    if (speed >= 66 && speed <= 85)
            //    {
            //        return 1;

            //    }
            //    if (speed <= 65)
            //    {
            //        return 0;
            //    }
            //}
            //else
            //{
            //    if (speed >= 81)
            //    {
            //        return 2;
            //    }
            //    if (speed >= 61 && speed <= 80)
            //    {
            //        return 1;
            //    }
            //}if (speed <= 60)
            //{
            //    return 0;
            //}

            //    return 0;