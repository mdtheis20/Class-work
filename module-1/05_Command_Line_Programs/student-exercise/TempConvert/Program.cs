using System;

namespace TempConvert
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter the temperature: ");
            string tempString = Console.ReadLine();
            int temp = Int32.Parse(tempString);

            Console.Write("Is the temperature in (C)elsius, or(F)ahrenheit ? ");
            string cOrF = Console.ReadLine();

            if (cOrF == "C")
            {
                Console.Write(temp + "C is " + (temp * 1.8 + 32) + "F");
            }
            else
            {
                Console.Write(temp + "F is " + ((temp - 32) / 1.8) + "C");

            }
        }
    }
}



//if they enter #f need to display #f is #c where #c equals (#f -32) / 1.8
//if they enter #c need to display #c is #f where #f equals #c * 1.8 + 32