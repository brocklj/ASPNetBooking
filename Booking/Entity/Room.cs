using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.Entity
{
    public class Room
    {
        public Room()
        {
            this.Reservations = new HashSet<Reservation>();
        }
        public int RoomId { set; get; }
        [Required]
        [MaxLength(50)]
        public string Name { set; get; }
        [Required]
        [MinLength(50)]
        [MaxLength(500)]
        public string Description { set; get; }

        public int OpenFrom { set; get; }

        public int OpenTill { set; get; }

        public ICollection<Reservation> Reservations { set; get; }

    }
}
