using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.Types
{
    public class RoomAvailability
    {
        public int RoomId { set; get; }

        public string Name { set; get; }

        public string OpenFrom { set; get; }

        public string OpenTill { set; get; }

        public IList<RoomDetailTime> TimesAvailable { get; set; }


    }
}
