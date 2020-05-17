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


        static void TalkToUser()
            {
                Console.Write("Hello! What is your name?");
                string name = Console.ReadLine();

                Console.Write($"Hi {name}, how young are you?");

                string ageAsString = Console.ReadLine();
                // Conver the age to an int
                int age = int.Parse(ageAsString);
                Console.WriteLine($"Wow, {name}, you dont't look a day over {age - 10}!");
            }

            static void GetNamesFromUser()
            {
                Console.WriteLine("Enter some names (comma-seperated): ");
                string allNames = Console.ReadLine();

                string[] names = allNames.Split(",");

                Console.WriteLine("Type me a sentence: ");
                string sentence = Console.ReadLine();
                string[] words = sentence.Split(" ");

                Console.WriteLine($"Your sentence has {words.Length} words.");


            }
            static void CalculateAverage()
            {
                Console.WriteLine("Enter numbers seperated by commas: ");
                string numbersString = Console.ReadLine();

                string[] numbers = numbersString.Split(",");
                
                int sum = 0;
                
                for (int i = 0; i < numbers.Length; i++)
                {
                    string theNumberAsString = numbers[i];

                    int theNumber = int.Parse(theNumberAsString);

                    sum += theNumber;
                }
                // Initialize a sum variable

                // Loop through the numbers string array to visit each element

                // Convert the string-number to a number;

                // Add that number to the sum

                //Outside the loop, calculate the average from the sum divided by array length

                double average = sum / (double)numbers.Length;

                Console.WriteLine($"The sum is {sum} and the average is {average}." );
            }



        }
    }
}
