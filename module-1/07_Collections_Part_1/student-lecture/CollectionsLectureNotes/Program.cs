using System;
using System.Collections.Generic;

namespace CollectionsLectureNotes
{
    class Program
    {
        static void Main(string[] args)
        {
            // LIST<T>
            //
            // Lists allow us to hold collections of data. They are declared with a type of data that they hold
            // only allowing items of that type to go inside of them.
            //
            // The syntax used for declaring a new list of type T is
            //      List<T> list = new List<T>();
            //
            //

            // Creating lists of integers
            List<int> numbers = new List<int>();


            // Creating lists of strings

            List<string> words = new List<string>() { "cat", "ba", "Matt", "mat" };

            Console.WriteLine(words);
            /////////////////


            //////////////////
            // OBJECT EQUALITY
            //////////////////
            List<int> numbers2 = new List<int>();

            if (numbers == numbers2)
            {
                Console.WriteLine("The two are equal");
            }
            else
            {
                Console.WriteLine("The two are not equal");
            }

            /////////////////
            // ADDING ITEMS
            /////////////////

            // Adding items one at a time to each list
            numbers.Add(100);
            numbers.Add(200);

            Console.WriteLine(string.Join(",", numbers));
            //long way
            for (int i = 0; i < numbers.Count; i++)
            {
                Console.Write(numbers[i] + ", ");
            }
            // COnsole.Write(numbers[i] + ((i == numbers.Count-1) ? "" : ", "));
            /////////////////
            // ADDING MULTIPLE ITEMS
            /////////////////
            int[] someMoreNumbers = new int[] { 90, 80, 70 };

            numbers.AddRange(someMoreNumbers);

            //Console.WriteLine(string.Join(", ", numbers));
            //Console.WriteLine(string.Join(", ", someMoreNumbers));
            Print(numbers);
            numbers.RemoveAt(1);
            Print(numbers);


            //////////////////
            // ACCESSING BY INDEX
            //////////////////




            ///////////////////
            // ACCESSING WITH FOR-EACH
            ///////////////////


            ////////////////////
            // ADDITIONAL LIST<T> METHODS
            ////////////////////
            foreach (string word in words)
            {
                Console.WriteLine(words); 
            }

            ////////////////////////
            // SORT and PRINT A LIST
            ////////////////////////




            // QUEUE <T>
            //
            // Queues are a special type of data structure that follow First-In First-Out (FIFO).
            // With Queues, we Enqueue (add) and Dequeue (remove) items.


            /////////////////////
            // PROCESSING ITEMS IN A QUEUE
            /////////////////////



            // STACK <T>
            //
            // Stacks are another type of data structure that follow Last-In First-Out (LIFO).
            // With Stacks, we Push (add) and Pop (remove) items. 


            ////////////////////
            // PUSHING ITEMS TO THE STACK
            //////////////////// 

            Stack<string> browserStack = new Stack<string>();
            browserStack.Push("Home Page");
            browserStack.Push("Login");

            ////////////////////
            // POPPING THE STACK
            ////////////////////
            

            Console.ReadLine();

        }
        static public void Print(List<int> list)
        {
            Console.WriteLine("****");
            Console.WriteLine($"There are {list.Count} elements: ");
            Console.WriteLine(string.Join(", ", list));
            Console.WriteLine("****");

        }
    }
}
