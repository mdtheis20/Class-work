using LinqLambda.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqLambda
{
    public class PersonMenu
    {
        private List<Person> People = new List<Person>()
        {
            new Person("Dan", 33, 69),
            new Person("Max", 31, 70),
            new Person("Ed", 48, 72),
            new Person("Amy", 31, 67),
            new Person("Chris", 25, 75),
            new Person("Seth", 23, 69),
            new Person("Kevin", 29, 73),
            new Person("Jordann", 19, 64),
            new Person("Josh", 22, 77),
        };

        public void Run()
        {
            while (true)
            {
                Console.Write(
@"
    1 - Display List RAW
    2 - Sort by Name
    3 - Sort by Height DESC
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
                        listToPrint = People.OrderBy(p => p.Name);
                        PrintList(listToPrint);
                        break;
                    case "3":   // Sort by Height DESC
                        listToPrint = People.OrderByDescending(p => p.Height);
                        PrintList(listToPrint);
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
            return People.Where(p => p.Height > minHeight);
        }

        private IEnumerable<PersonTargetWeight> MapToBMI()
        {
            // TODO: Replace this with a call to Select
           return  People.Select(p =>
           {
               return new PersonTargetWeight(p.Name, GetWeightForHeightAndBMI(p.Height, 18.5), GetWeightForHeightAndBMI(p.Height, 25));
           });
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
            return People.Count(p => p.Height > minHeight);
        }

        private int GetSumOfHeights()
        {
            // TODO: Replace this with a call to Sum
            return People.Sum(p => p.Height);

        }

        private long GetProductOfAges()
        {
            // Get the product of people's ages

            // TODO: Replace this with a call to Aggregate
            return People.Aggregate(1L, (prod, person) =>
            {
                return prod * person.Age;
            });
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
