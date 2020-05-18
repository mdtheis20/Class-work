using System;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter the Fibonacci numer: ");
            string fibNumber = Console.ReadLine();
            int limit = Int32.Parse(fibNumber);
            var previous = 0;
            var current = 1;
            Console.Write(previous);
            while (current < limit)
            {
                Console.Write(", " + current);
                var temp = previous + current;
                previous = current;
                current = temp;
            }

        }
    }
}


//Need to display sequence that shows all numbers in fib sequence that are smaller than the number entered. 