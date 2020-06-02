using System;
using System.Collections.Generic;
using System.Text;

namespace FileAndDirectory.Models
{
    public class FileAndDirDemo
    {
        public void DoFileAndDirDemo()
        {
            // Print out the current working directory
            string path = "???";
            Console.WriteLine(path);

            // List the folders in the folder that holds the solution file (up 3)
            path = "..\\..\\..";

            string[] dirs = null;
            Console.WriteLine("*** *** *** *** *** ***");

            // List them out

            // List the files in that folder
            string[] files = null;
            Console.WriteLine("*** *** *** *** *** ***");

            // List them out

            // Get a DirectoryInfo object for the Files folder

            // Use the Path object to append the Files folder
            path = "???";
            files = null;

            // List the files in that directory
            Console.WriteLine("*** *** *** *** *** ***");

            // List them out

            // Get a FileInfo for the Declaration.txt file
            path = "???";

            Console.WriteLine("*** *** *** *** *** ***");
            // Display file information

        }
    }
}
