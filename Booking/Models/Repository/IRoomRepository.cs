using Booking.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.Models.Repository
{
   public interface IRoomRepository
    {
        IList<Room> GetAll();
        Room GetById(int id);
    }
}
