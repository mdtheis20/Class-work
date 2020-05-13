using System;

namespace Lecture
{
    class Program
    {
        /*
 * Create a method called MultiplyBy, which takes two integers and returns the integer product.
 * 
 * A method has:
 *      * An access modifier (public, private, etc.)
 *      * Return type (int, string, etc. or void)
 *      * Name
 *      * A parameter list (in parentheses), each parameter has a type and a name
 */
        static public int MultiplyBy(int multiplicand, int multiplier)
        {
            int product;
            product = multiplicand * multiplier;
            return product;

            // The shorter way
            //int product = multiplicand * multiplier;
            //return product;

            // The shortest way
            //return multiplicand * multiplier;

        }

        static public int DoubleIt(int numberToDouble){
            return numberToDouble * 2;
        }

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
                outerVariable += 10;    // outerVariable = outerVariable + 10;
                Console.WriteLine("From the inner block, outer variable is " + outerVariable);

                // Declare a variable in the block (inner scope)
                int innerVariable = 100;
                // Print out that variable
                Console.WriteLine($"From the inner block, inner variable is {innerVariable}");
                // End the statement block
            }

            // Print out the variable defined in the outer scope
            Console.WriteLine("From the outer block, outer variable is " + outerVariable);

            // Print the the variable declared in the block
            // This is illegal
            //Console.WriteLine($"From the outer block, inner variable is {innerVariable}");






            /*****************************************************************************
            Part 2: Methods
            ******************************************************************************/
            // Call the MultiplyBy method
            int theAnswer = DoubleIt(MultiplyBy(125, 32));
            Console.WriteLine($"The answer is {theAnswer}!");

            // Create and print some boolean expressions


            Console.ReadKey();
        }


    }
}
