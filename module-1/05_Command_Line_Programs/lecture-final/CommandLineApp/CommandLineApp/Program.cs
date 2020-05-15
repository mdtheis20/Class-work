using System;

namespace CommandLineApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //TalkToUser();

            //GetNamesFromUser();

            CalculateAverage();
        }

        static void TalkToUser()
        {
            Console.Write("Hello! What is your name? ");
            string name = Console.ReadLine();

            Console.Write($"Hi {name}, how young are you? ");
            string ageAsString = Console.ReadLine();

            // Convert the age to an integer
            int age = int.Parse(ageAsString);

            Console.WriteLine($"Wow, {name}, you don't look a day over {age - 10}!");
        }

        static void GetNamesFromUser()
        {
            Console.Write("Enter some names (comma-separated): ");
            string allNames = Console.ReadLine();

            string[] names = allNames.Split(",");

            Console.WriteLine("Type me a sentence: ");
            string sentence = Console.ReadLine();
            string[] words = sentence.Split(" ");

            Console.WriteLine($"Your sentence has {words.Length} words.");

        }

        static void CalculateAverage()
        {
            Console.Write("Enter numbers separated by commas: ");
            string numbersString = Console.ReadLine();

            string[] numbers = numbersString.Split(",");

            // Initialize a sum variable
            int sum = 0;


            // Loop through the numbers string array to visit each element
            for (int i = 0; i < numbers.Length; i++)
            {
                // Convert the string-number to a number.
                string theNumberAsString = numbers[i];
                int theNumber = int.Parse(theNumberAsString);

                // Add that number to the sum
                sum += theNumber;
            }
            // Outside the loop, calculate the average from the sum diveded by the array length
            double average = sum / (double)numbers.Length;

            Console.WriteLine($"The sum is {sum} and the average is {average}." );

        }
    }
}
