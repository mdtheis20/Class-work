using System;

namespace StringsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Use our custom Person data type (class)
            //CreatePerson();

            string name = "Ada Lovelace";

            // Strings are actually arrays of characters (char). 
            // Those characters can be accessed using [] notation.

            // 1. Write code that prints out the first and last characters
            //      of name.
            // Output: A
            // Output: e
            Console.WriteLine($"First char: {name[0]}, Last char: {name[name.Length-1]}");


            // 2. How do we write code that prints out the first three characters
            // Output: Ada
            Console.WriteLine($"First 3 chars: {  name.Substring(0, 3)   }");

            // 3. Now print out the first three and the last three characters
            // Output: Adaace
            Console.WriteLine($"First 3 + last 3: {name.Substring(0,3)} {name.Substring(name.Length-3, 3)} ");

            // 4. What about the last word?
            // Output: Lovelace
            {
                string[] names = name.Split(" ");
                Console.WriteLine($"Last Word: {names[names.Length - 1]}");
            }

            int spaceIndex = name.LastIndexOf(" ");
            Console.WriteLine($"Last Word: {name.Substring(spaceIndex + 1)}");


            // 5. Does the string contain inside of it "Love"?
            // Output: true


            Console.WriteLine($"Contains \"Love\" = { name.Contains("love")}");

            // 6. Where does the string "lace" show up in name?
            // Output: 8
            int ix = name.IndexOf("Love");

            // Console.WriteLine("Index of \"lace\": ");

            // 7. How many 'a's OR 'A's are in name?
            // Output: 3
            int countOfA = 0;
            for (int i = 0; i < name.Length; i++)
            {
                if (name[i] == 'A' || name[i] == 'a')
                {
                    countOfA++;
                }
            }

            Console.WriteLine($"Number of \"a's\": {countOfA}");

            // 8. Replace "Ada" with "Ada, Countess of Lovelace"
            name = name.Replace("Ada", "Ada, Countess of Lovelace");
            Console.WriteLine(name);

            // 9. Set name equal to null.
            name = null;

            // 10. If name is equal to null or "", print out "All Done".
            if (name == null || name == "")
            {
                Console.WriteLine("All Done.");
            }

            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Really All Done.");
            }

            // Console.ReadLine();
        }

        public static void CreatePerson()
        {
            // Create a new Person object from the Person class
            Person student1;
            student1 = new Person();

            // Set the properties of this object
            student1.FirstName = "Matt";
            student1.LastName = "Theis";
            student1.HeightInches = 70;

            Console.WriteLine($"Student 1 is {student1.FirstName} {student1.LastName}.");

            // Create another person and set its value.
            Person student2 = new Person();
            student2.FirstName = "Seth";
            student2.LastName = "Boyle";
            student2.HeightInches = 70;
            Console.WriteLine($"Student 2 is {student2.FirstName} {student2.LastName}.");

            // Create one more
            Person student3 = new Person()
            {
                FirstName = "Jordann",
                LastName = "Davis"
            };
            student3.HeightInches = 65;

        }
    }

}