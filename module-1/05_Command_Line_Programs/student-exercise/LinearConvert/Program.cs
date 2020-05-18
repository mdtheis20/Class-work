using System;

namespace LinearConvert
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter the length: ");
            string currentLength = Console.ReadLine();
            int tempLength = Int32.Parse(currentLength);

            Console.Write("Is the measurement in (m)eter, or (f)eet? ");
            string feetOrMeter = Console.ReadLine();

            if ( feetOrMeter == "m")
            {
                Console.Write(tempLength + "m is " + (tempLength * 3.2808399) + "f");
            }
            else
            {
                Console.Write(tempLength + "f is " + (tempLength * 0.3048) + "m");
            }
        }
    }
}



//if they enter #m I need to display #m is #f where #f equals #m * 3.2808399
//if they enter #f i need to display #f is #m where #m equals #f * 0.3408


