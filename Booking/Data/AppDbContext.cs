using Booking.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//add-migration InitialCreate
//Update-Database
namespace Booking.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        { }

        public DbSet<Room> Rooms { set; get; }

        public DbSet<Reservation> Reservations { set; get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Room>().HasData(new Room
            {
                RoomId = 1,
                Name = "Room 1",
                Description = "Room 1 description",
                OpenFrom = 8,
                OpenTill = 16

            });
            modelBuilder.Entity<Room>().HasData(new Room
            {
                RoomId = 2,
                Name = "Room 2",
                Description = "Room 2 description",
                OpenFrom = 9,
                OpenTill = 15
            });
            modelBuilder.Entity<Room>().HasData(new Room
            {
                RoomId = 3,
                Name = "Room 3",
                Description = "Lorem ipsum dolor sit amet, " +
                "consectetur adipiscing elit. Duis dictum ipsum" +
                " sapien, nec dapibus arcu posuere vel. Ut ac " +
                "bibendum velit, a tincidunt erat. Integer " +
                "ut eros ac augue ornare malesuada. Morbi eleifend metus a" +
                "c sollicitudin pretium. Mauris sapien neque, pretium eu bla" +
                "ndit in, placerat vitae mi. Nullam consequat, mi sit amet pelle" +
                "ntesque dictum, metus orci tristique felis, quis scelerisqu",  
                OpenFrom = 7,
                OpenTill = 12
            });
        }

    }
}
