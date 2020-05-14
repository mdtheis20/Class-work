using System;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            i = i + 1;
            i += 1;
            i++;



            //1. Creating an array of integers
            int[] quizScores = new int[4];
            quizScores[0] = 100;
            quizScores[1] = 80;
            quizScores[2] = 85;
            quizScores[3] = 90;

            Console.WriteLine($"The length of the array is {quizScores.Length}");

            //2. Creating an array of strings
            string[] names = new string[] { "Max", "Jason", "Jordann", "Kevin" };

            //3. Create an array of characters that hold "Tech Elevator"        
            char[] letters = {'M', 'i', 'k', 'e' };

            //4. Print out the first item in each array
            Console.WriteLine($"First score: {quizScores[0]}");
            Console.WriteLine($"First name: {names[0]}");
            Console.WriteLine($"First letter: {letters[0]}");

            string name = "Seth";
            Console.WriteLine($"First letter of name: {name[0]}");

            //5. Print out the final item in each array
            Console.WriteLine($"Final element of scores: {quizScores[ quizScores.Length - 1 ]}");
            Console.WriteLine($"Final name is {names[names.Length - 1]}");
            //6. Get the length of each array

            //7. Get the last index 

            //8. Update the last item in each array
            quizScores[quizScores.Length - 1] += 5;
            names[names.Length - 1] = "Hey his name's !Kevin";

            Console.ReadLine();
        }

        static public int[] GimmeAnArray(int lengthOfArray)
        {
            int[] result = new int[lengthOfArray];
            return result;
        }
    }
}
