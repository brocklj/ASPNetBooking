using Booking.Data;
using Booking.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.Models.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private AppDbContext _dbContext;

        public RoomRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<Room> GetAll()
        {
            return _dbContext.Rooms.ToList();
        }

        public Room GetById(int id)
        {
            return _dbContext.Rooms.FirstOrDefault(r => r.RoomId == id);
        }
    }
}
