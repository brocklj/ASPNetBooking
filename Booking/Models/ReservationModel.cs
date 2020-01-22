using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.Models
{
    public class ReservationModel
    {
        public string Date { set; get; }
        public string RoomId { set; get; }
        public ReservationModel(string date, string room)
        {
            this.Date = date;
            this.RoomId = room;
        }
    }
}
