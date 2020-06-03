using Exceptions.Classes;
using System;
using System.IO;

namespace Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            #region DoSomethingDangerous
            /* 
            * try/catch blocks will also catch Exceptions that are 
            * thrown from method called further down the stack 
            */
            try
            {
                Console.WriteLine("Hey guys, watch this!");

                int result = DoSomethingDangerous(10, 0);

                Console.WriteLine($"See, I told you nothing would go wrong! The answer is {result}.");
            }
            catch (FileNotFoundException ex)
            {
                // Report this to the user
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Be a hero, don't divide by ZERO!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Sorry user, something went wrong.  There error was '{ex.Message}'");
            }
            finally
            {
                Console.WriteLine("Finally block ran.");
            }

            #endregion

            #region DoMathFun
            //DoMathFun();
            //Console.ReadLine();
            #endregion

            #region A template for error-handling...
            try
            {
                // Do some work here...
            }
            catch (ArgumentNullException e)
            {
                // catch most specific Exceptions first
            }
            catch (Exception e)
            {
                // (optional) catch more general exceptions later
                // (optional) re-throw the same exception so it can be caught further up the stack
                throw;
            }
            finally
            {
                // (optional) Do work that should execute whether the above succeeded or failed
            }
            #endregion

            Console.ReadKey();
        }

        private static int DoSomethingDangerous(int a, int b)
        {
            int result = 0;
            try
            {
                result = a / b;
            }
            catch(DivideByZeroException ex)
            {
                // Log the error here (write a log file or something)
                throw;
            }
            return result;

        }

        private static void DoMathFun()
        {
            try
            {
                MathFun math = new MathFun();
                Console.WriteLine(math.Average(new int[] { }));
                Console.WriteLine(math.ParseAndAdd("23, 45, 65"));
            }
            catch (Exception exc)
            {
                Console.WriteLine($"ERROR!!! {exc.Message}");
            }
            finally
            {
                Console.WriteLine("Running the final block...");
            }
        }

    }
}
