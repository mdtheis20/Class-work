using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture
{
    public partial class LectureExample
    {

        /*
        15. Now, do it again with a different bool operation.
        TOPIC: Logical Not
        */
        public string ReturnAdultOrMinorAgain(int number)
        {
            //bool isMinor = true;
            //int day = 1;
            //if (!isMinor || day == 1)
            //{
            //    return "C'mon in";
            //}

            //if (!(number < 18))
            //{
            //    return "Adult";
            //}
            //else
            //{
            //    return "Minor";
            //}

            if (number == 18 || number > 18)
            {
                return "Adult";
            }
            else
            {
                return "Minor";
            }


        }
    }
}
