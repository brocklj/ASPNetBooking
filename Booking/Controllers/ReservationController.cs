using Booking.Entity;
using Booking.Models;
using Booking.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Booking.Controllers
{
    public class ReservationController : Controller
    {
        private IRoomRepository _roomRepository;

        private IReservationRepository _reservationRepository;

        public ReservationController(IRoomRepository roomRepository, IReservationRepository reservationRepository)
        {
            _roomRepository = roomRepository;
            _reservationRepository = reservationRepository;
        }
        public IActionResult Index(int id)
        {
           return View(_roomRepository.GetById(id));           
        }
        public IActionResult Create()
        {
            if (TempData["Date"] == null || TempData["Hours"] == null || TempData["RoomName"] == null)
            {
                return RedirectToAction("Index", "Room");
            }     
           return View(new Reservation());
        }
        [HttpPost]
        public IActionResult Create(Reservation reservation, string Date, int RoomId, string Hours)
        {
            try { 
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }    
                reservation.RoomId = RoomId;

                Room Room = _roomRepository.GetById(RoomId);

                string[] HourValues = Hours.Split(" - ");

                int HourFrom = Int32.Parse(HourValues[0].Split(":")[0]);
                int HourTo = Int32.Parse(HourValues[1].Split(":")[0]);

                RoomModel RoomModel = new RoomModel(Room);

                if(! RoomModel.CheckAvailability(Date, HourFrom, HourTo))
                {
                    return BadRequest("Room is not available");
                }

                reservation.Start = DateTime.Parse(Date).AddHours(HourFrom);
                reservation.End = DateTime.Parse(Date).AddHours(HourTo);
                _reservationRepository.Save(reservation);

                return RedirectToAction("Index", "Room");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}