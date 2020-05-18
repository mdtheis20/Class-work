using System;

namespace DecimalToBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a series of integer values seperated by spaces: ");
            string userInput = Console.ReadLine();
            string[] strings = userInput.Split(" ");


            for (int i =0; i < strings.Length; i++)
            {

                string s = strings[i];
                int base10Number = int.Parse(s);

                string binary = Base10ToBinary(base10Number);

                Console.WriteLine($"{base10Number} in binary is {binary}");
            }
        }

        static public string Base10ToBinary(int num)
        {
            string binary = "";

            for (; num > 0; num/= 2)
            {
                int lastDigit = num % 2;
                binary = lastDigit + binary;
            }

            return binary == "" ? "0" : binary;
        }
    }


}








