using System;
using System.Collections.Generic;
using System.IO;

namespace Hangman
{
    public class HangmanDictionary
    {
        // Our word source is just a list of words loaded from a text file
        private List<string> words = new List<string>();
        Random random = new Random();
        public HangmanDictionary()
        {
        }

        public bool LoadWords(string fileName)
        {
            // Find and open the file dictionary.txt.  Each line contains one word 
            // read each line and load the list.
            try
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    while (!sr.EndOfStream)
                    {
                        string word = sr.ReadLine();
                        if (word.Length >= 5 && word.Length <= 8)
                        {
                            words.Add(word);
                        }
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public string FetchWord()
        {
            // Get a word
            while (words.Count > 0)
            {
                int index = random.Next(0, words.Count);
                string word = words[index];
                words.RemoveAt(index);
                if (word.Length >= 5 && word.Length <= 8)
                {
                    return word;
                }
            }
            return "";
        }
    }
}