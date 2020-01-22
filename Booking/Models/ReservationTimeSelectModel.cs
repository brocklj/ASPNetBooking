using Booking.Entity;
using System.ComponentModel.DataAnnotations;

namespace Booking.Models
{
    public class ReservationTimeSelectModel
    {
        public Room Room { set; get; } 

        [Required]
        public string date { set; get; }

        [Required]
        public int room { set; get; }

        [Required]
        public string hour { set; get; }
    }
}