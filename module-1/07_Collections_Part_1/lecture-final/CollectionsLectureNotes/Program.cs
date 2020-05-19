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
            Console.WriteLine(numbers);

            // Creating lists of strings
            List<string> words = new List<string>() { "cat", "bat", "Matt", "mat" };
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
                Console.WriteLine("The two are NOT equal");
            }

            /////////////////
            // ADDING ITEMS
            /////////////////

            // Adding items one at a time to each list
            numbers.Add(100);
            numbers.Add(200);

            Console.WriteLine(string.Join(", ", numbers));
            for (int i = 0; i < numbers.Count; i++)
            {
                Console.Write(numbers[i] +  ((i == numbers.Count-1) ? "" : ", "));
            }
            Console.WriteLine();

            /////////////////
            // ADDING MULTIPLE ITEMS
            /////////////////
            int[] someMoreNumbers = new int[] { 90, 80, 70};
            numbers.AddRange(someMoreNumbers);




            Print(numbers);
            Console.WriteLine(string.Join(", ", someMoreNumbers));

            bool contains200 = numbers.Contains(200);
            Console.WriteLine($"List contains 200? {contains200}");

            numbers.RemoveAt(1);
            //Print(numbers);

            contains200 = numbers.Contains(200);
            Console.WriteLine($"List contains 200? {contains200}");

            bool containsBat = words.Contains("Bat");

            Console.WriteLine(numbers[numbers.Count-1]);



            //////////////////
            // ACCESSING BY INDEX
            //////////////////




            ///////////////////
            // ACCESSING WITH FOR-EACH
            ///////////////////
            foreach (string theWord in words)
            {
                Console.WriteLine(theWord);
            }

            // The above is equivalent to this "classic" for
            for (int i = 0; i < words.Count; i++)
            {
                string theWord = words[i];
                Console.WriteLine(theWord);
            }

            ////////////////////
            // ADDITIONAL LIST<T> METHODS
            ////////////////////

            int[] numbersAsArray = numbers.ToArray();

            ////////////////////////
            // SORT and PRINT A LIST
            ////////////////////////
            ///
            words.Reverse();
            Console.WriteLine(string.Join(",", words));
            words.Sort();
            Console.WriteLine(string.Join(",", words));

            numbers.Sort();
            numbers.Reverse();
            Print(numbers);



            // QUEUE <T>
            //
            // Queues are a special type of data structure that follow First-In First-Out (FIFO).
            // With Queues, we Enqueue (add) and Dequeue (remove) items.

            Queue<string> todo = new Queue<string>();
            todo.Enqueue("Wash the dishes");
            todo.Enqueue("Sweep the floor");
            todo.Enqueue("Do the laundry");

            /////////////////////
            // PROCESSING ITEMS IN A QUEUE
            /////////////////////
            while (todo.Count > 0)
            {
                string task = todo.Dequeue();
                Console.WriteLine(task);
            }



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
            browserStack.Push("Dashboard");
            browserStack.Push("Details Page");

            //////////////////////////
            /// Iterate the stack
            /// 
            Console.WriteLine($"Size of the stack is {browserStack.Count}");
            foreach (string page in browserStack)
            {
                Console.WriteLine(page);
            }
            Console.WriteLine($"Size of the stack is {browserStack.Count}");

            ////////////////////
            // POPPING THE STACK
            ////////////////////
            Console.WriteLine("Popping the stack...");
            while(browserStack.Count > 0)
            {
                string prevPage = browserStack.Pop();
                Console.WriteLine(prevPage);
            }
            Console.WriteLine($"Size of the stack is {browserStack.Count}");

            Console.ReadLine();

        }

        static public void Print(List<int> list)
        {
            Console.WriteLine("****");
            Console.WriteLine($"There are {list.Count} elements:" );
            Console.WriteLine(string.Join(", ", list));
            Console.WriteLine("****");
        }
    }
}
