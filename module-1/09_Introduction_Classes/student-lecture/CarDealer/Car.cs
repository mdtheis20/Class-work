using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer
{
    public class Car
    {
        //Create a constructor for Car that accepts a year make and model
        public Car(int year, string make, string model)
        {
            this.Year = year;
            this.Make = make;
            this.Model = model;
        }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }


        //Speed is publicly gettable, but not publicly settable(caller must call accellerate)
        //Use prop tab tab for awesome shortcut!!!!!!!
        public int Speed { get; private set; } = 0;



        //Create a derived property. Age depends on (is derived from) the car's Year property. 


        public int Age
        {
            get
            {
                int currentYear = DateTime.Now.Year;

                //Age is the current year minus the year of the car
                return currentYear - Year;
            }
        }

        private string gear = "P";
        public string Gear
        {
            get
            {
                return this.gear;
            }

            set
            {
                if (value == "P" || value == "D" || value == "N" || value == "R")
                {
                    this.gear = value;
                }
            }
        }

        public void Accelerate()
        {
            this.Speed++;
        }

        public void Accelerate(int mph)
        {
            this.Speed += mph;
        }


    }
}
