using Entities;
using HotelManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IRoomService
    {
        List<Rooms> getAllRooms();
        Rooms getRoom(int id);
        Rooms createRoom(Rooms room);
        Rooms updateRoom(int id,Rooms room);
        void deleteRoom(int id);
    }
}
