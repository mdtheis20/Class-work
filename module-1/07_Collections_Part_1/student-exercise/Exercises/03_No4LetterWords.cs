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
         Given an array of Strings, return a List containing the same Strings in the same order
         except for any words that contain exactly 4 characters.
         No4LetterWords( {"Train", "Boat", "Car"} )  ->  ["Train", "Car"]
         No4LetterWords( {"Red", "White", "Blue"} )  ->  ["Red", "White"]
         No4LetterWords( {"Jack", "Jill", "Jane", "John", "Jim"} )  ->  ["Jim"]
         */
        public List<string> No4LetterWords(string[] stringArray)
        {
            
                    List<string> words = new List<string>(stringArray);
                  
                    for (int i = 0; i < words.Count; i++)
                    {
                        if (words[i].Length == 4)
                        {
                            words.RemoveAt(i);
                    i--;
                        }
                    }

                    return words;
                }
            }
        }

    

