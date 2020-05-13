using System;

namespace Lecture
{
    class Program
    {
        static void Main(string[] args)
        {
            /*****************************************************************************
            Part 1: Variable Scope
            ******************************************************************************/
            // Declare a variable
            int outerVariable = 5;
            Console.WriteLine("outer variable is " + outerVariable);
            // Start a statement block
            {
                Console.WriteLine("From the inner block, outer variable is " + outerVariable);
                outerVariable += 10;
                Console.WriteLine("From the inner block, outer variable is " + outerVariable);
                int innerVariable = 100;
                Console.WriteLine($"From the inner block, inner variable is {innerVariable}");
            }
            // Print out the variable defined in the outer scope
            Console.WriteLine("From the outer block, outer variable is " + outerVariable);

            // Declare a variable in the block (inner scope)

            // Print out that variable

            // End the statement block

            // Print the the variable declared in the block


            /*****************************************************************************
            Part 2: Methods
            ******************************************************************************/
            // Call the MultiplyBy method
            int theAnswer = MultiplyBy(125, 32);

            // Create and print some boolean expressions


            Console.ReadKey();
        }

        /*
         * Create a method called MultiplyBy, which takes two integers and returns the integer product.
         */
         static public int MultiplyBy(int multiplicand, int multiplier)
        {
            int product;
            product = multiplicand * multiplier;
            return product;
        }
    }
}
