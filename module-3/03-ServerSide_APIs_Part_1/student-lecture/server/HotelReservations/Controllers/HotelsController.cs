using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HotelReservations.Models;
using HotelReservations.Dao;

namespace HotelReservations.Controllers
{
    [Route("/")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private IHotelDao _hotelDao;
        private IReservationDao _reservationDao;

        public HotelsController()
        {
            _hotelDao = new HotelDao();
            _reservationDao = new ReservationDao();
        }

        [HttpGet("hotels")]
        public List<Hotel> ListHotels()
        {
            List<Hotel> result =  _hotelDao.List();
            return result;
        }

        [HttpGet("hotels/{id}")]
        public Hotel GetHotel(int id)
        {
            Hotel hotel = _hotelDao.Get(id);

            if (hotel != null)
            {
                return hotel;
            }

            return null;
        }

        [HttpGet("hotels/{hotelId}/reservations")]
        public List<Reservation> GetReservationsByHotel(int hotelId)
        {
           return _reservationDao.FindByHotel(hotelId);

        }

        [HttpPost("reservations")]
        public Reservation AddReservation(Reservation newRes)
        {
            return _reservationDao.Create(newRes);
        }


        //[HttpPut("reservations/{resId}")]
        //public Reservation UpdateReservation(int resId, Reservation res)
        //{
        //    _
        //}




    }
}
