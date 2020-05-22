using System;

namespace CarDealer
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a new Car object(create a new object of type Car)
            Car car = new Car(1965, "Ford", "Mustang");

            //Set Make and Model
            //car.Make = "Ford";
            //car.Model = "Mustange";    //the constructor meant we didnt need these anymore. 
            //car.Year = 1965;

            //Display the car property value
            string make = car.Make;
            string model = car.Model;
            int year = car.Year;
            

            Console.WriteLine($"The car is a {year} {make} {model}. This car is {car.Age} years old!");


            car.Gear = "D";
            Console.WriteLine($" Gear is {car.Gear}");



            //Speed up to 60mph
            while (car.Speed < 60)
            {
                car.Accelerate();
                Console.WriteLine($"The car is now going {car.Speed} mph.");
            }


            //Now Let's Brake hard.

            while (car.Speed > 0)
            {
                car.Accelerate(-5);
                Console.WriteLine($"The car is now going {car.Speed} mph.");

                
            }
        }
    }
}
;
