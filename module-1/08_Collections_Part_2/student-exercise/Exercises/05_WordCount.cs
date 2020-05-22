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
         * Given an array of strings, return a Dictionary<string, int> with a key for each different string, with the value the
         * number of times that string appears in the array.
         *
         * ** A CLASSIC **
         *
         * WordCount(["ba", "ba", "black", "sheep"]) → {"ba" : 2, "black": 1, "sheep": 1 }
         * WordCount(["a", "b", "a", "c", "b"]) → {"b": 2, "c": 1, "a": 2}
         * WordCount([]) → {}
         * WordCount(["c", "b", "a"]) → {"b": 1, "c": 1, "a": 1}
         *
         */
        public Dictionary<string, int> WordCount(string[] words)
        {
            // Create new dictionary to store these results.
            Dictionary<string, int> result = new Dictionary<string, int>();
            // Loop through the array of words.
            foreach(string word in words)
            {
                // Does the dictionary already contain this word
                if (result.ContainsKey(word))
                {
                    // If it does then increment the count
                    result[word] = result[word] + 1;
                    //shortcut = result[word]++;
                    //translates to result[word] = result[word] + 1
                }
                else
                {
                    // Else, add the word to the dictionary with a count of 1
                    result.Add(word, 1);
                }  //shortcut = result[word] = //1 this for adds an entry if it doesnt exist and overwrites if it does
                // Else, add the word to the dictionary with a count of 1
            }
           

            return result;
        }
    }
}
