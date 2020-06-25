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

        public HotelsController(IHotelDao hotelDao, IReservationDao resDao)
        {
            _hotelDao = hotelDao;
            _reservationDao = resDao;
        }

        [HttpGet("hotels")]
        public List<Hotel> ListHotels(string state)
        {
            if (string.IsNullOrEmpty(state))
            {
                List<Hotel> result = _hotelDao.List();
                return result;
            }
            else
            {
                return _hotelDao.ListByState(state);
            }
        }

        // TODO 05: Return 404 if the Id is not found (using NotFound). Change return type to ActionResult<>
        [HttpGet("hotels/{id}")]
        public ActionResult<Hotel> GetHotel(int id)
        {
            Hotel hotel = _hotelDao.Get(id);

            if (hotel == null)
            {
                return NotFound();
            }
            else
            {
                return hotel;   
            }
        }

        [HttpGet("hotels/{hotelId}/reservations")]
        public List<Reservation> GetReservationsByHotel(int hotelId)
        {
            return _reservationDao.FindByHotel(hotelId);
        }

        [HttpGet("reservations")]
        public List<Reservation> GetReservations()
        {
            return _reservationDao.List();
        }


        // TODO 06: Return 404 if the Res Id is not found (using NotFound). Change return type to ActionResult<>
        [HttpGet("reservations/{id}")]
        public ActionResult<Reservation> GetReservation(int id)
        {

            Reservation res = _reservationDao.Get(id);
            if (res == null)
            {
                return NotFound();
            }
            return res;
        }

        // TODO 07: We want to return a status code other than 200, plus content,
        //      so change the result to an ActionResult and call the Created method to return.
        [HttpPost("reservations")]
        public ActionResult<Reservation> AddReservation(Reservation newRes)
        {
            Reservation res  = _reservationDao.Create(newRes);
            string location = $"/reservations/{res.Id}";
            return Created(location, res);
        }

        // TODO 02: Review the Update and Delete reservation controleer actions that I added
        [HttpPut("reservations/{resId}")]
        public Reservation UpdateReservation(int resId, Reservation updRes)
        {
            return _reservationDao.Update(updRes);
        }

        // TODO 08: Return 404 if the Id is not found (using NotFound). Change return type to ActionResult
        //      Also, return status code 500 if the delete fails
        [HttpDelete("reservations/{id}")]
        public void DeleteReservation(int id)
        {
            _reservationDao.Delete(id);
            //return StatusCode(418);
        }

    }
}
