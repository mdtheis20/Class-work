using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer
{
    public class Car
    {
        public string VIN { get; set; }

        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        // Speed is publicly gettable, but not publicly settable (caller must call Accellerate)
        public int Speed { get; private set; } = 0;

        // Create a derived property.  Age depends on (is derived from) the car's Year property.
        public int Age
        {
            get
            {
                int currentYear = DateTime.Now.Year;
                // Age is the current year minus the Year of the car
                return currentYear - Year;
            }
        }

        // Backed property for Gear
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

    }
}
