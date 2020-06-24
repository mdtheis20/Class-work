using System;

namespace HotelReservations.Models
{
    public class Reservation
    {
        public int? Id { get; set; }
        public int HotelId { get; set; }
        public string FullName { get; set; }
        public string CheckinDate { get; set; }
        public string CheckoutDate { get; set; }
        public int Guests { get; set; }

        public Reservation(int? id, int hotelId, string fullName, string checkinDate, string checkoutDate, int guests)
        {
            // One way
            //if (id == null)
            //{
            //    Id = new Random().Next(100, int.MaxValue);
            //}
            //else
            //{
            //    Id = id;
            //}

            // Another way using ternary
            //Id = (id.HasValue) ? id : new Random().Next(100, int.MaxValue);

            // Another way using null coalesence
            Id = id ?? new Random().Next(100, int.MaxValue);

            HotelId = hotelId;
            FullName = fullName;
            CheckinDate = checkinDate;
            CheckoutDate = checkoutDate;
            Guests = guests;
        }
    }
}
