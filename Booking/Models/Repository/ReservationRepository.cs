using Booking.Data;
using Booking.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.Models.Repository
{
    public class ReservationRepository : IReservationRepository
    {
        private AppDbContext _dbContext;

        public ReservationRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<Reservation> GetAll()
        {
            return _dbContext.Reservations.ToList();
        }

        public IList<Reservation> GetByRoomId(int RoomId) 
        {
            return _dbContext.Reservations.Where(r => r.RoomId == RoomId).ToList();
        }


        public Reservation GetById(int id)
        {
            return _dbContext.Reservations.FirstOrDefault(r => r.ReservationId == id);
        }

        public Reservation Save(Reservation reservation)
        {
            _dbContext.Reservations.Add(reservation);
            _dbContext.SaveChanges();

            return reservation;
        }
    }
}
