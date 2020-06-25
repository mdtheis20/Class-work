using System;
using System.ComponentModel.DataAnnotations;

namespace HotelReservations.Models
{
    public class Reservation
    {
        // TODO 03: Use Postman to show how we can enter invalid data
        /*** TODO 04: Add data validation attributes to protect the model data
         *          HotelId, FullName, Checkin, Checkout and Guests are all required
         *          The number of guests should be in the Range of 1 - 5
         *          Full name should be at least 6 characters long
        ***/
        public int? Id { get; set; }
        [Required(ErrorMessage = "What hotel is this reservation for?")]
        public int HotelId { get; set; }
        [StringLength(50, MinimumLength = 6, ErrorMessage ="Name must be between 6 and 50 characters long.")]
        [Required]
        public string FullName { get; set; }
        [Required]
        public string CheckinDate { get; set; }
        [Required]
        public string CheckoutDate { get; set; }
        [Range(1, 5, ErrorMessage = "Please specify 1 to 5 guests")]
        [Required]
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
