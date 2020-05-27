﻿namespace Individual.Exercises.Classes
{
    public class Airplane
    {
       public string PlaneNumber { get; }
       public int TotalFirstClassSeats { get; }
        
        public int BookedFirstClassSeats { get; private set; }
        public int AvailableFirstClassSeats { get { return TotalFirstClassSeats - BookedFirstClassSeats; } }
        public int TotalCoachSeats { get;  }
        public int BookedCoachSeats { get; private set; }
        public int AvailableCoachSeats { get { return TotalCoachSeats - BookedCoachSeats; } }


        public Airplane(string planeNumber, int totalFirstClassSeats, int totalCoachSeats)
        {
            this.PlaneNumber = planeNumber;
            this.TotalFirstClassSeats = totalFirstClassSeats;
            this.TotalCoachSeats = totalCoachSeats;
            
            
        }

        public bool ReserveSeats(bool forFirstClass, int totalNumberOfSeats)
        {
            if (forFirstClass && totalNumberOfSeats <= AvailableFirstClassSeats)
            {
                BookedFirstClassSeats += totalNumberOfSeats;
                return true;
            }
            if (!forFirstClass && totalNumberOfSeats <= AvailableCoachSeats)
            {
                BookedCoachSeats += totalNumberOfSeats;
                return true;
            }
            return false;
        }
      

    }
}
