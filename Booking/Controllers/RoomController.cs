using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Booking;
using Booking.Models.Repository;
using Booking.Entity;
using Booking.Models;
using Booking.Types;

namespace Booking.Controllers
{
    public class RoomController : Controller
    {
        private IRoomRepository _roomRepository;

        private IReservationRepository _resevationRepository;

        public RoomController(IRoomRepository roomRepository, IReservationRepository reservationRepository)
        {
            _roomRepository = roomRepository;
            _resevationRepository = reservationRepository;
        }

        public IActionResult Index()
        {
            return View(_roomRepository.GetAll());
        }

        public IActionResult Detail(int id)
        {
            ReservationTimeSelectModel Model = new ReservationTimeSelectModel();
            _resevationRepository.GetByRoomId(id);
            Model.Room = _roomRepository.GetById(id);

            return View(Model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Times(string Date, int RoomId)
        {
            try
            {

                Room Room = _roomRepository.GetById(RoomId);
                _resevationRepository.GetByRoomId(RoomId);
                RoomModel model = new RoomModel(Room);

                ViewBag.times = model.GetTimes(Date);
                return PartialView("Times");

            } catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        public IActionResult Detail(ReservationTimeSelectModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                TempData["Date"] = model.date;
                TempData["Hours"] = model.hour;
                TempData["RoomId"] = model.room;
                TempData["RoomName"] = _roomRepository.GetById(model.room).Name;
                return RedirectToAction("Create", "Reservation");

            } catch (Exception e)
            {
                return BadRequest(e);
            }

        }

        [HttpGet]
        public IActionResult Available(string Date, int RoomId)
        {
            try {
                //Load All of the Reservations
                _resevationRepository.GetAll();

                string ProcessedDate = Date;
                IList<RoomAvailability> Availability = new List<RoomAvailability>();

                IList<Room> Rooms = _roomRepository.GetAll();
                foreach (Room Room in Rooms)
                {
                    RoomModel model = new RoomModel(Room);

                    RoomAvailability AvailabilityItem = new RoomAvailability();

                    List<RoomDetailTime> TimesAvailable = model.GetTimes(ProcessedDate).Where(t => t.available == true).ToList();

                    AvailabilityItem.RoomId = Room.RoomId;
                    AvailabilityItem.Name = Room.Name;

                    AvailabilityItem.OpenFrom = Room.OpenFrom.ToString() + ":00";
                    AvailabilityItem.OpenTill = Room.OpenTill.ToString() + ":00";

                    AvailabilityItem.TimesAvailable = TimesAvailable;

                    Availability.Add(AvailabilityItem);
                }

                return Json(Availability);

            } catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        
        [HttpGet("room/{id:int}/available")]
        public IActionResult Available(int id, string Date) {
            try
            {
                //Load All of the Reservations
                _resevationRepository.GetAll();

                string ProcessedDate = Date;
                IList<RoomAvailability> Availability = new List<RoomAvailability>();

                Room Room = _roomRepository.GetById(id);
             
                    RoomModel model = new RoomModel(Room);

                    RoomAvailability AvailabilityItem = new RoomAvailability();

                    List<RoomDetailTime> TimesAvailable = model.GetTimes(ProcessedDate).Where(t => t.available == true).ToList();

                    AvailabilityItem.RoomId = Room.RoomId;
                    AvailabilityItem.Name = Room.Name;

                    AvailabilityItem.OpenFrom = Room.OpenFrom.ToString() + ":00";
                    AvailabilityItem.OpenTill = Room.OpenTill.ToString() + ":00";

                    AvailabilityItem.TimesAvailable = TimesAvailable;

                    Availability.Add(AvailabilityItem);
                

                return Json(Availability);

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
