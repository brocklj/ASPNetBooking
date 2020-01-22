using Booking.Entity;
using System.Collections.Generic;
using Booking.Types;
using System;

namespace Booking.Models
{
    public class RoomModel
    {
        public string Date { get; set; }
        public string RoomId { get; set; }
        public Room Room { get; set; }

        public RoomModel(Room Room)
        {
            this.Room = Room;
        }
        // date 
        public IList<RoomDetailTime> GetTimes(string date)
        {
            List<RoomDetailTime> times = new List<RoomDetailTime>();
            int hour = this.Room.OpenFrom;
            while (this.Room.OpenTill > hour)
            {
                int From = hour;
                int To = hour + 1;
                string TimeRange = $"{From}:00 - {To}:00";
                bool available = this.CheckAvailability(date, From, To);

               RoomDetailTime RoomTime = new RoomDetailTime()
                {            
                    value = TimeRange,
                    available = available
                };

                times.Add(RoomTime);

                ++hour;
            }
            return times;
        }

        public bool CheckAvailability(string Date, int From, int To)
        {

            DateTime TimeFrom = DateTime.Parse(Date).AddHours(From);

            DateTime TimeTo = DateTime.Parse(Date).AddHours(To);

            foreach(Reservation reservation in this.Room.Reservations)
            {
                if(reservation.Start == TimeFrom && reservation.End == TimeTo)
                {
                    return false;
                }
            }

            return true;
        }
    }
}