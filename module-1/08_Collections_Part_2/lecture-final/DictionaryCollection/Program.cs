using System;
using System.Collections.Generic;

namespace DictionaryCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            //string stateCode = "AR";
            //string state = LookupState(stateCode);
            //Console.WriteLine($"The state for code '{stateCode}' is '{state}'");

            //string stateCode = "AR";
            //string state = LookupStateWithDictionary(stateCode);
            //Console.WriteLine($"The state for code '{stateCode}' is '{state}'");

            //stateCode = "CO";
            //state = LookupStateWithDictionary(stateCode);
            //Console.WriteLine($"The state for code '{stateCode}' is '{state}'");

            //DoMenuDemonstration();

            //DictionaryDemo();

            //HashSetDemo();

            // Build a name / height database and search it
            RunHeightDatabase();
        }

        private static void DoMenuDemonstration()
        {
            /** Menu Loop demonstration
             *  1. Clear the screen
             *  2. Show the user a selection of choices from a menu.
             *  3. Based on the user's selection, do something.
             *      3a. Quit if the user asked to Quit
             *  4. Loop back and ask the user for their next choice.
             *  
             *  Sample:
             *      1. Get the current time
             *      2. Tell the user's height in ft/inches given their height in inches.
             *
             **/
            Console.Clear();
            Console.WriteLine("Menu goes here...");
            string input = Console.ReadLine();
        }

        static string LookupState(string stateCode)
        {
            List<string> stateCodes = new List<string>() { "AL", "AK", "AR", "AZ", "CA", "CO", "CT", "DE" };
            List<string> stateNames = new List<string>() { "Alabama", "Alaska", "Arkansas", "Arizona", "California", "Colorado",
                "Connecticut", "Deleware" };

            int indexOf = stateCodes.IndexOf(stateCode);

            if (indexOf >= 0)
            {
                return stateNames[indexOf];
            }

            return null;
        }

        static string LookupStateWithDictionary(string stateCode)
        {
            List<string> codes = new List<string>() { "AL", "AK", "AR", "AZ", "CA", "CO", "CT", "DE" };
            List<string> states = new List<string>() { "Alabama", "Alaska", "Arkansas", "Arizona", "California", "Colorado",
                "Connecticut", "Deleware" };

            // Using the initializer
            //Dictionary<string, string> stateCodes = new Dictionary<string, string>()
            //{
            //    {"AL", "Alabama" },
            //    {"AK", "Alaska" },
            //    {"AR", "Arkansas" }
            //};

            Dictionary<string, string> stateCodes = new Dictionary<string, string>();

            for (int i = 0; i < codes.Count; i++)
            {
                string code = codes[i];
                string state = states[i];

                //                stateCodes.Add(code, state);
                stateCodes[code] = state;
            }

            // Iterate the dictionary
            foreach (KeyValuePair<string, string> dictionaryItem in stateCodes)
            {
                Console.WriteLine($"State code: {dictionaryItem.Key}, state name: {dictionaryItem.Value}");
            }

            if (stateCodes.ContainsKey(stateCode))
            {
                string theState = stateCodes[stateCode];
                return stateCodes[stateCode];
            }
            else  // Does not contain key
            {
                return null;
            }
        }

        static void DictionaryDemo()
        {
            // Demonstrate creating and searching a dictionary
        }

        static void HashSetDemo()
        {
            // Demonstrate a few HashSet methods

        }
        static void RunHeightDatabase()
        {
            // Display a greeting and menu

            //// 1. Let's create a new Dictionary that could hold string, ints
            ////      | "Josh"    | 70 |
            ////      | "Bob"     | 72 |
            ////      | "John"    | 75 |
            ////      | "Jack"    | 73 |
            Dictionary<string, int> heightDB = new Dictionary<string, int>();

            string input;
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(@"     _       _        _                    ");
                Console.WriteLine(@"    | |     | |      | |                   ");
                Console.WriteLine(@"  __| | __ _| |_ __ _| |__   __ _ ___  ___ ");
                Console.WriteLine(@" / _` |/ _` | __/ _` | '_ \ / _` / __|/ _ \");
                Console.WriteLine(@"| (_| | (_| | || (_| | |_) | (_| \__ \  __/");
                Console.WriteLine(@" \__,_|\__,_|\__\__,_|_.__/ \__,_|___/\___|");
                Console.WriteLine(@"                                           ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("1) Add / update data");
                Console.WriteLine("2) Search the database");
                Console.WriteLine("3) Print the database");
                Console.WriteLine("4) Get Average Height");
                Console.WriteLine("Q) Quit");
                Console.WriteLine("");
                Console.ResetColor();
                Console.Write("Please enter selection: ");
                input = Console.ReadLine().ToLower();
                if (input.Length > 0)
                {
                    input = input.Substring(0, 1);
                }
                if (input == "q")
                {
                    break;
                }
                else if (input == "1")
                {
                    AddEditDB(heightDB);
                }
                else if (input == "2")
                {
                    SearchDB(heightDB);
                }
                else if (input == "3")
                {
                    PrintDB(heightDB);
                }
                else if (input == "4")
                {
                    ShowAverageHeight(heightDB);
                }
                else
                {
                    continue;
                }
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();

            }

            Console.WriteLine();
            Console.WriteLine("Done...");


        }

        public static void ShowAverageHeight(Dictionary<string, int> heightDB)
        {
            //7. Let's get the average height of the people in the dictionary

            // Initialize a sum variable to 0
            int sum = 0;

            // Loop through all the entries in the db
            foreach(var entry in heightDB)
            {
                // Add the height of this person to the sum
                sum += entry.Value;
            }
            // Divide the sum by the number of entries
            double average = (double)sum / heightDB.Count;
            Console.WriteLine($"The average height is {average:N2} inches");
        }

        public static void PrintDB(Dictionary<string, int> heightDB)
        {
            // Looping through a dictionary involves using a foreach loop
            // to look at each item, which is a key-value pair
            Console.WriteLine("Printing...");
            foreach(KeyValuePair<string, int> entry in heightDB)
            {
                Console.WriteLine($"{entry.Key} is {entry.Value} inches tall.");
            }
        }

        public static void AddEditDB(Dictionary<string, int> db)
        {
            Console.Write("What is the person's name?: ");
            string name = Console.ReadLine();

            Console.Write("What is the person's height (in inches)?: ");
            int height = int.Parse(Console.ReadLine());

            // 2. Check to see if that name is in the dictionary
            //      bool exists = dictionaryVariable.ContainsKey(key)
            bool exists = db.ContainsKey(name);    // <-- change this

            if (!exists)
            {
                Console.WriteLine($"Adding {name} with new value.");
                // 3. Put the name and height into the dictionary
                //      dictionaryVariable[key] = value;
                //      OR dictionaryVariable.Add(key, value);
                db[name] = height;
            }
            else  // name already exists
            {
                Console.WriteLine($"Overwriting {name} with new value.");
                // 4. Overwrite the current key with a new value
                //      dictionaryVariable[key] = value;
                db[name] = height;
            }
        }
        public static void SearchDB(Dictionary<string, int> db)
        {
            Console.Write("Which name are you looking for? ");
            string input = Console.ReadLine();

            //5. Let's get a specific name from the dictionary
            if (db.ContainsKey(input))
            {
                Console.WriteLine($"{input} was found, and is {db[input]} inches tall.");
            }
            else // Did not find this person
            {
                Console.WriteLine($"{input} was not found in the database.");
            }
        }
    }
}
