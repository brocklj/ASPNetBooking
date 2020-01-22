using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.Entity
{
    public class Reservation
    {
        public int ReservationId { set; get; }

        [Required]
        public DateTime Start {set; get;}

        [Required]
        public DateTime End { set; get; }

        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string FirstName { set; get; }

        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string LastName { set; get; }

        [Required]
        [EmailAddress]
        public string Email { set; get; }

        [Required]
        [RegularExpression(@"^((\+\d{3})\s(\d{3}\s\d{3}\s\d{3}))$", ErrorMessage = "The Contact Number field is not a valid phone number")]
        public string ContactNumber { set; get; }

        [MaxLength(500)]
        public string Note { set; get; }

        public int RoomId { set; get; }

        public Room Room { set; get; }
    }
}
