using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileAndDirectory.Models
{
    public class FileAndDirDemo
    {
        public void DoFileAndDirDemo()
        {
            // Print out the current working directory
            string path = Directory.GetCurrentDirectory();
            Console.WriteLine(path);

            // List the folders in the folder that holds the solution file (up 3)
            path = "..\\..\\..";

            string[] dirs = Directory.GetDirectories(path);
            Console.WriteLine("*** *** *** *** *** ***");

            // List them out
            foreach (string dir in dirs)
            {
                Console.WriteLine($"\tDir; {dir}");
            }
            // List the files in that folder
            string[] files = Directory.GetFiles(path);
            Console.WriteLine("*** *** *** *** *** ***");

            // List them out
            foreach (string f in files)
            {
                Console.WriteLine($"\tFile: {f}");
            }
            // Get a DirectoryInfo object for the Files folder

            // Use the Path object to append the Files folder
            path = Path.Combine(path, "Files");
            files = null;

            // List the files in that directory
            Console.WriteLine("*** *** *** *** *** ***");

            // List them out

            // Get a FileInfo for the Declaration.txt file
            path = Path.Combine(path, "Declaration.txt");

            Console.WriteLine("*** *** *** *** *** ***");
            // Display file information

            FileInfo fi = new FileInfo(path);

            Console.WriteLine($"File: {fi.FullName}, size: {fi.Length} bytes, Created: {fi.CreationTime}");


            //Read the file and display the contents to the user, line-by-line
            using (StreamReader rdr = new StreamReader(path))
            {
                int lineNumber = 1;
                while (!rdr.EndOfStream)
                {
                    string lineOfText = rdr.ReadLine();
                    Console.WriteLine($"{lineNumber}: {lineOfText}");
                    lineNumber++;

                }
            }

        }
    }
}
