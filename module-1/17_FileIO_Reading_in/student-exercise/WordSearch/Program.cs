using System;
using System.IO;

namespace WordSearch
{
    class Program
    {
        static void Main(string[] args)
        {

            //2. Ask the user for the file path
            //3. Open the file
            //4. Loop through each line in the file
            //5. If the line contains the search string, print it out along with its line number

            Console.WriteLine("What word would you like to search for?");
            string searchWord = Console.ReadLine().ToLower();

            Console.WriteLine("What is the name of the file that should be searched?");
            string fileName = Console.ReadLine();

            string directory = Environment.CurrentDirectory;
            string path = Path.Combine(directory, fileName);


            using (StreamReader sr = new StreamReader(path))
            {
                int lineNumber = 0;
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine().ToLower();
                    lineNumber++;

                    if (line.Contains(searchWord))
                    {
                        Console.WriteLine($"{lineNumber}: {line}");
                    }
                }
            }
        }
    }
}
