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
         Given a List of string, return a new list in reverse order of the original. One obvious solution is to
         simply loop through the original list in reverse order, but see if you can come up with an alternative
         solution. (Hint: Think LIFO (i.e. stack))
         ReverseList( ["purple", "green", "blue", "yellow", "green" ])  -> ["green", "yellow", "blue", "green", "purple" ]
         ReverseList( ["jingle", "bells", "jingle", "bells", "jingle", "all", "the", "way"} )
            -> ["way", "the", "all", "jingle", "bells", "jingle", "bells", "jingle"]
         */
        public List<string> ReverseList(List<string> objectList)
        {
           for (int i = 0; i < objectList.Count / 2; i++)
            {//swap element[i] with element[Count -1 -i]
                //first hold onto the last element
                string temp = objectList[objectList.Count - 1 - i];
                objectList[objectList.Count - 1 - i] = objectList[i];
                objectList[i] = temp;
            }

            return objectList;
        }

    }
}


//object list.reverse 