using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.Classes
{
    /// <summary>
    /// Represents a person and their vital statistics
    /// </summary>
    public class Person : IComparable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int HeightInches { get; set; }

        public Person(string first, string last, int age, int height)
        {
            FirstName = first;
            LastName = last;
            Age = age;
            HeightInches = height;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}: Age {Age}, Height {HeightInches} inches.";
        }

        public int CompareTo(object obj)
        {
            if (!(obj is Person))
            {
                return 0;
            }

            Person other = (Person)obj;

            if (this.HeightInches > other.HeightInches)
            {
                return -1;
            }
            if (this.HeightInches < other.HeightInches)
            {
                return 1;
            }
            return 0;
        }
    }
}
