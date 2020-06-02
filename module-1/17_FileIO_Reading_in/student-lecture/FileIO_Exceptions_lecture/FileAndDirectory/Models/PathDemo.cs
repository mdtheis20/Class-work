using System;
using System.Collections.Generic;
using System.Text;

namespace FileAndDirectory.Models
{
    class PathDemo
    {
        public void DoPathDemo()
        {
            string path1 = @"c:\temp\MyTest.txt";
            string path2 = @"c:\temp\MyTest";
            string path3 = @"temp";

            ShowPathInfo(path1);
            ShowPathInfo(path2);
            ShowPathInfo(path3);

            // Get the temp path, get a temp file name, get a random file name...


            /* This code produces output similar to the following:
             * c:\temp\MyTest.txt has an extension.
             * c:\temp\MyTest has no extension.
             * The string temp contains no root information.
             * The full path of temp is D:\Documents and Settings\cliffc\My Documents\Visual Studio 2005\Projects\ConsoleApplication2\ConsoleApplication2\bin\Debug\temp.
             * D:\Documents and Settings\cliffc\Local Settings\Temp\8\ is the location for temporary files.
             * D:\Documents and Settings\cliffc\Local Settings\Temp\8\tmp3D.tmp is a file available for use.
             */
        }

        public void ShowPathInfo(string path)
        {
            // Does this path have an extension?

            // Is this path rooted?

            // Get the current working directory so we can call GetRelativePath

            // Show the absolute and relative path for the path given



            Console.WriteLine("*********************************");

        }

    }
}
