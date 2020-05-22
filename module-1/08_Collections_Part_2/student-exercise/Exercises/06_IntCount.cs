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
         * Given an array of int values, return a Dictionary<int, int> with a key for each int, with the value the
         * number of times that int appears in the array.
         *
         * ** The lesser known cousin of the the classic WordCount **
         *
         * IntCount([1, 99, 63, 1, 55, 77, 63, 99, 63, 44]) → {1: 2, 44: 1, 55: 1, 63: 3, 77: 1, 99:2}
         * IntCount([107, 33, 107, 33, 33, 33, 106, 107]) → {33: 4, 106: 1, 107: 3}
         * IntCount([]) → {}
         *
         */
        public Dictionary<int, int> IntCount(int[] ints)
        {
            Dictionary<int, int> result = new Dictionary<int, int>();

            foreach(int number in ints)
            {

                if (result.ContainsKey(number))
                {
                    result[number]++;
                }
                else
                {
                    result.Add(number, 1);
                }
            }
            return result;
        }
    }
}


//// Create new dictionary to store these results.
//Dictionary<string, int> result = new Dictionary<string, int>();
//            // Loop through the array of words.
//            foreach(string word in words)
//            {
//                // Does the dictionary already contain this word
//                if (result.ContainsKey(word))
//                {
//                    // If it does then increment the count
//                    result[word] = result[word] + 1;
//                    //shortcut = result[word]++;
//                    //translates to result[word] = result[word] + 1
//                }
//                else
//                {
//                    // Else, add the word to the dictionary with a count of 1
//                    result.Add(word, 1);
//                }  //shortcut = result[word] = //1 this for adds an entry if it doesnt exist and overwrites if it does
//                // Else, add the word to the dictionary with a count of 1
//            }
           

//            return result;
//        }