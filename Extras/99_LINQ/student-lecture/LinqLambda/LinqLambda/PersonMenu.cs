using LinqLambda.Models;
using System;
using System.Collections.Generic;

namespace LinqLambda
{
    public class PersonMenu
    {
        private List<Person> People = new List<Person>()
        {
            new Person("Bobby", 27, 71),
            new Person("Tyler", 27, 72),
            new Person("El", 26, 60),
            new Person("Jesse", 29, 78),
            new Person("Chris", 29, 74),
            new Person("Sirrena", 24, 71),
            new Person("John S", 42, 70),
            new Person("Jacob", 23, 70),
        };

        public void Run()
        {
            while (true)
            {
                Console.Write(
@"
    1 - Display List RAW
    2 - Sort by Name
    3 - Sort by Age DESC
    4 - Map Person to Target Weight
    5 - Filter by Height
    6 - Get a Count of tall people
    7 - Get the sum of all Heights
    8 - Get the product of all ages
    9 - Get a concatenation of all namess
    Q - Quit
Please make a selection:
");
                IEnumerable<Object> listToPrint = null;
                string key = Console.ReadLine();
                if (key.Length == 0)
                {
                    continue;
                }
                Console.Clear();
                switch (key.Substring(0, 1).ToUpper())
                {
                    case "Q":
                        return;
                    case "1":
                        PrintList(People);
                        break;
                    case "2":   // Sort by Name
                        Console.WriteLine("NOT YET IMPLEMENTED!!");
                        break;
                    case "3":   // Sort by Age DESC
                        Console.WriteLine("NOT YET IMPLEMENTED!!");
                        break;
                    case "4":   // Select
                        listToPrint = MapToBMI();
                        PrintList(listToPrint);
                        break;
                    case "5":
                        listToPrint = FilterByHeight(PromptForMinHeight());
                        PrintList(listToPrint);
                        break;
                    case "6":
                        int n = PromptForMinHeight();
                        int count = GetCountOfTallPeople(n);
                        Console.WriteLine($"There are {count} people taller than {n} inches.");
                        break;
                    case "7": // add up the heights
                        int totalHeight = GetSumOfHeights();
                        Console.WriteLine($"Total Height is {totalHeight}");
                        break;

                    case "8": // product of ages
                        long product = GetProductOfAges();
                        Console.WriteLine($"Product of ages is {product}");
                        break;

                    case "9": // Concatenate names
                        Console.WriteLine("NOT YET IMPLEMENTED!!");
                        //string longName = People.Aggregate("", (accum, p) => { return accum + ((accum.Length == 0) ? "" : "_") + p.Name; });
                        //Console.WriteLine($"Names aggregated: {longName}");
                        break;
                }
            }
        }

        private IEnumerable<Person> FilterByHeight(int minHeight)
        {
            // TODO: Replace this with a call to Where

            // Filter by height
            List<Person> list = new List<Person>();
            foreach (Person p in People)
            {
                if (p.Height > minHeight)
                {
                    list.Add(p);
                }
            }
            return list;
        }

        private IEnumerable<PersonTargetWeight> MapToBMI()
        {
            // TODO: Replace this with a call to Select
            List<PersonTargetWeight> list = new List<PersonTargetWeight>();
            foreach (Person p in People)
            {
                PersonTargetWeight ptw = new PersonTargetWeight(p.Name, GetWeightForHeightAndBMI(p.Height, 18.5), GetWeightForHeightAndBMI(p.Height, 25));
                list.Add(ptw);
            }
            return list;
        }
        private IEnumerable<string> MapHeightToString()
        {
            List<string> list = new List<string>();
            foreach (Person p in People)
            {
                string s = MapPersonToString(p);
                list.Add(s);
            }
            return list;
        }

        private string MapPersonToString(Person p)
        {
            return $"{p.Name} is {p.Height / 12} feet {p.Height % 12} inches tall.";
        }

        private int GetCountOfTallPeople(int minHeight)
        {
            // TODO: Replace this with a call to Count

            // Get a count of people taller than minHeight
            int count = 0;
            foreach (Person p in People)
            {
                if (p.Height > minHeight)
                {
                    count++;
                }
            }
            return count;
        }

        private int GetSumOfHeights()
        {
            // TODO: Replace this with a call to Sum

            // Get the length of people end-to-end
            int sum = 0;
            foreach (Person p in People)
            {
                sum += p.Height;
            }
            return sum;
        }

        private long GetProductOfAges()
        {
            // Get the product of people's ages
            // TODO: Replace this with a call to Aggregate

            long product = 1;
            foreach (Person p in People)
            {
                product *= p.Age;
            }
            return product;

        }

        #region Utility Functions
        /// <summary>
        /// Utility to loop through a list and print it
        /// </summary>
        /// <param name="list"></param>
        private void PrintList(IEnumerable<Object> list)
        {
            Console.WriteLine();
            Console.WriteLine(Person.Heading());
            foreach (Object obj in list)
            {
                Console.WriteLine(obj);
            }
        }

        private int PromptForMinHeight()
        {
            int minHeight;
            do
            {
                Console.Write("\tTaller than (how many inches)? ");
            } while (!int.TryParse(Console.ReadLine(), out minHeight));
            return minHeight;
        }

        private int GetWeightForHeightAndBMI(int heightInches, double targetBMI)
        {
            return (int)(Math.Round((targetBMI * heightInches * heightInches) / 703.0));
        }
        #endregion

    }
}
