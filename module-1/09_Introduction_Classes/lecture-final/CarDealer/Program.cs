using System;

namespace CarDealer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new Car object (Create a new object of type Car)
            Car dan = new Car();

            // Set its make and model
            dan.Make = "Ford";
            dan.Model = "Mustang";
            dan.Year = 1965;

            // Display the car property value
            string make = dan.Make;
            string model = dan.Model;
            Console.WriteLine($"The car is a {dan.Year} {make} {model}. This car is {dan.Age} years old!");

            dan.Gear = "D";
            Console.WriteLine($"Gear is {dan.Gear}");
            dan.Gear = "Q";
            Console.WriteLine($"Gear is {dan.Gear}");
            dan.Gear = "R";
            Console.WriteLine($"Gear is {dan.Gear}");

            // Speed up to 60mph
            while (dan.Speed < 60)
            {
                dan.Accelerate();
                Console.WriteLine($"The car is now going {dan.Speed} mph.");
            }
        }
    }
}
