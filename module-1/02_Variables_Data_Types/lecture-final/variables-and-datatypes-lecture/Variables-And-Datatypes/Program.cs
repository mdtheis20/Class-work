using System;

namespace Variables_And_Datatypes
{
    class Program
    {
        static void Main(string[] args)
        {
            /* VARIABLES & DATA TYPES */

            /*
		    1. Create a variable to hold an int and call it numberOfExercises.
			Then set it to 26.

            We use camelCasing for variable names.
            We do not use PascalCasing for these variable. 
            */
            int numberOfExercises;
            numberOfExercises = 26;
            Console.WriteLine(numberOfExercises);

            /*
            2. Create a variable to hold a double and call it half.
                Set it to 0.5.
            */
            double half = 0.5;
            Console.WriteLine(half);

            /*
            3. Create a variable to hold a string and call it name.
                Set it to "TechElevator".
            */
            string name;
            name = "TechElevator";
            Console.WriteLine(name);

            /*
            4. Create a variable called seasonsOfFirefly and set it to 1.
            */
            byte seasonsOfFirefly = 1;
            Console.WriteLine(seasonsOfFirefly);

            /*
            5. Create a variable called myFavoriteLanguage and set it to "C#".
            */
            string myFavoriteLanguage = "C#";
            Console.WriteLine(myFavoriteLanguage);

            /*
            6. Create a variable called pi and set it to 3.1416.
            */
            double pi = 3.1416;
            Console.WriteLine(pi);

            /*
            7. Create and set a variable that holds your name.
            */
            string firstName = "Mike";
            string lastName = "Morel";
            string fullName = firstName + " " + lastName;
            Console.WriteLine(fullName);

            /*
            8. Create and set a variable that holds the number of buttons on your mouse.
            */

            /*
            9. Create and set a variable that holds the percentage of battery left on
            your phone.
            */

            /* EXPRESSIONS */

            // Hold the value of the sum of 2 and 2
            int twoPlusTwo = 2 + 2;
            Console.WriteLine(twoPlusTwo);

            /*
            10. Create an int variable that holds the difference between 121 and 27.
            */
            int difference = 121 - 27;
            Console.WriteLine(difference);

            // Now add 10 back to that value
            difference = difference + 10;

            // Now add another 10, but the shortcut way
            difference += 10;

            /*
            11. Create a double that holds the addition of 12.3 and 32.1.
            */
            double sum = 12.3 + 32.1;

            /*
            12. Create a string that holds your full name.
            */
            string myName = "Mike Morel";

            /*
            13. Create a string that holds the word "Hello, " concatenated onto your
            name from above.
            */
            string greeting = "Hello, " + myName;

            /*
            14. Add a " Esquire" onto the end of your full name and save it back to
            the same variable.
            */

            //greeting = greeting + " Esquire";

            greeting += " Esquire";

            Console.WriteLine(greeting);


            int num = 100;
            num -= 25;

            /*
            15. Now do the same as exercise 14, but use the += operator.
            */

            /* DATA TYPE CONVERSIONS */

            long longNum = num;

            num = (int)longNum;


            /*
            16. Create a variable to hold "Saw" and add a 2 onto the end of it.
            */
            string saw = "Saw";
            saw += 2;
            Console.WriteLine(saw);

            // Can I do this the other way around?
            num = 100;
            string addOn = "50";
            Console.WriteLine(num + addOn);

            /*
            17. Add a 0 onto the end of the variable from exercise 16.
            */

            /*
            18. What is 4.4 divided by 2.2?
            */
            Console.WriteLine(4.4 / 2.2);

            /*
            19. What is 5.4 divided by 2?
            */
            Console.WriteLine(5.4 / 2);

            /* CASTING */

            /*
            20. What is 5 divided by 2?
            */
            Console.WriteLine(5 / 2);

            /*
            21. What is 5.0 divided by 2?
            */
            Console.WriteLine(5.0 / 2);
            Console.WriteLine(5 / 2.0);
            Console.WriteLine(5D / 2);

            int a = 5;
            int b = 2;
            Console.WriteLine((double)a / b);

            /*
            22. Create a variable that holds a bank balance with the value of 1234.56.
            */

            /*
            23. If I divide 5 by 2, what's my remainder?
            */
            Console.WriteLine("5 / 2 equals " + (5 / 2) + ", remainder " + (5 % 2) );

            /*
            24. Create two variables: 3 and 1,000,000,000 and multiple them together. 
                What is the result?
            */
            int variable1 = 3;
            long variable2 = 1_000_000_000;
            Console.WriteLine(variable1 * variable2);

            /*
            25. Create a variable that holds a boolean called doneWithExercises and
            set it to false.
            */
            bool doneWithExercises = false;

            /*
            26. Now set doneWithExercise to true.
            */
            doneWithExercises = true;

            Console.ReadLine();
        }
    }
}
