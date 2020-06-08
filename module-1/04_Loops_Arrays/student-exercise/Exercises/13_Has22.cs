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
         Given an array of ints, return true if the array contains a 2 next to a 2 somewhere.
         Has22([1, 2, 2]) → true
         Has22([1, 2, 1, 2]) → false
         Has22([2, 1, 2]) → false
         */
        public bool Has22(int[] nums)
        {
            bool has22 = false;
            
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 2)
                {
                    has22 = true;
                }
                if (has22 && nums[i++] == 2)
                {
                    has22 = true;
                }
                if (has22 && nums[i++] != 2)
                {
                    has22 = false;
                }
                
            }
            return has22;


            //for (int i = 0; i < nums.Length; i++)
            //{

            //    if (nums[i] == 2 && nums[i++] == 2)
            //    {
            //        return true;
            //    }
            //    if (nums[nums.Length - 1] == 2 && nums[nums.Length - 2] != 2)
            //    {
            //        return false;
            //    }
            //    else
            //    {
            //        return false;
            //    }

            //}
            //return false;
        }

    }
}
