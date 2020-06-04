using System;
using System.IO;

namespace FileIO_lecture
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamWriter sw = new StreamWriter("output.txt", true))
            {
                for (int i = 9000; i < 10000; i++)
                {
                    sw.Write(i.ToString());    

                }
            }

                Console.WriteLine("Press RETURN");
            Console.ReadKey();
        }
    }
}
