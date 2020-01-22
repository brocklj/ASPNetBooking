using Booking.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.Models.Repository
{
   public interface IReservationRepository
    {
        IList<Reservation> GetAll();
        IList<Reservation> GetByRoomId(int RoomId);
        Reservation GetById(int id);
        Reservation Save(Reservation NewReservation);

    }
}
