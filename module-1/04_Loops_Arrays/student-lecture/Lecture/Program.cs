using System;

namespace Lecture
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Use a for-loop to print "Hello World" 10 times
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"{i}. Hello World");
            }


            // 2. Create an array of quiz scores
            int[] scores = { 90, 100, 56, 78, 92, 67, 89 };
            // 3. Print all the scores to the screen
            Console.WriteLine("The scores are:");
            for (int i = 0; i < scores.Length; i++)
            {
                Console.WriteLine(scores[i]);
            }
            // 4. Grade on a curve...increase all scores by the curve amount
            //int theCurve = 4;
            //Console.WriteLine();
            //Console.WriteLine("The adjusted scores are:");
            //for (int i = 0; i < scores.Length; i++)
            //{
            //    scores[i] += theCurve;
            //    Console.WriteLine(scores[i]);

            //}

            // 5. Calculate and print the average score for the class after the curve.
            int sum = 0;
            for (int i = 0; i < scores.Length; i++)
            {
                sum += scores[i];
            }

            double classAverage = (double)sum / scores.Length;
            Console.WriteLine($"The class average adjusted is {classAverage}");

            //find perfect scores.
            bool hasPerfectScores = false;
            for (int j = 0; j < scores.Length; j++)
            {
                if (scores[j] == 100)
                {
                    hasPerfectScores = true;
                    break;
                }



            }
            Console.WriteLine($"Perfect scores: {hasPerfectScores}.");
        }
    }
}
