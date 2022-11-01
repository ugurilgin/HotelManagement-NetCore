using DataAccess.Abstract;
using Entities;
using HotelManagement.Data;
using HotelManagement.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
     public class RoomRepository : IRoomRepository
    {
        public Rooms createRoom(Rooms room)
        {
            using (var applicationDbContext = new ApplicationDbContext())
            {
                applicationDbContext.Rooms.Add(room);
                applicationDbContext.SaveChanges();
                return room;
            }
        }

        public void deleteRoom(int id)
        {
            using (var applicationDbContext = new ApplicationDbContext())
            {
                var deletedRoom = getRoom(id);
                applicationDbContext.Rooms.Remove(deletedRoom);
                applicationDbContext.SaveChanges();
            }
        }

        public List<Rooms> getAllRooms()
        {
            using (var applicationDbContext = new ApplicationDbContext())
            {
                return applicationDbContext.Rooms.ToList();
            }
        }

        public Rooms getRoom(int id)
        {
            using (var applicationDbContext = new ApplicationDbContext())
            {
                return applicationDbContext.Rooms.Find(id);
            }
        }

        public Rooms updateRoom(Rooms room)
        {
            using (var applicationDbContext = new ApplicationDbContext())
            {
                applicationDbContext.Rooms.Update(room);
                applicationDbContext.SaveChanges();
                return room;
            }
        }

    }
}
