using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.Models
{
    public class HotelReservation
    {
        public string Name { get; set; }
        
        public int NumberOfNights { get; set; }


        public decimal EstimatedTotal  { get; set; }


        public HotelReservation(string name, int numberOfNights)
        {
            this.Name = name;

            this.NumberOfNights = numberOfNights;

            
        }


        public decimal FinalTotal(bool usedMiniBar, bool requiresCleaning, int numberOfNights)
        {
            EstimatedTotal = numberOfNights * 59.99m;
            if (usedMiniBar)
            {
                EstimatedTotal += 12.99M;
            }
            if (requiresCleaning)
            {
                EstimatedTotal += 34.99M;
            }
            return EstimatedTotal;
        }

        public override string ToString()
        {
            
            
            return $"Reservation - {Name} - {EstimatedTotal}";
        }



    }
}
