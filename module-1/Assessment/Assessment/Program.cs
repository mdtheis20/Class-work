using Assessment.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace Assessment
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO: Create instances of your object here and call methods.
            HotelReservation reservation = new HotelReservation("Matt Theis", 5);

            decimal total = reservation.FinalTotal(true, true, 5);

            Console.WriteLine($"");


            
                
                Console.ReadLine();
        }
    }
}
