using System;
using System.IO;

namespace FizzWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory();

            path = @"..\\..\\..\\..\\FizzBuzz.txt";
            string FizzBuzz(int v)
            {
                string newString = Convert.ToString(v);


                if (v % 3 == 0 && v % 5 == 0 || newString.Contains("3") && newString.Contains("5"))
                {
                    return "FizzBuzz";
                }

                if (v % 3 == 0 || newString.Contains("3"))
                {


                    return "Fizz";
                }

                if (v % 5 == 0 || newString.Contains("5"))
                {
                    return "Buzz";
                }



                return $"{v}";

            }

            using (StreamWriter sw = new StreamWriter(path, true))
            {
                for (int i = 0; i <= 300; i++)
                {
                    sw.WriteLine(FizzBuzz(i));

                }
            }
            Console.WriteLine("Hello World!");
        }
    }
}



          