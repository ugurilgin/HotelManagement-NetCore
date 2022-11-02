using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities;
using HotelManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Business.Concrete
{
    public class RoomService : IRoomService
    {
       private IRoomRepository _roomRepository;
        private IEmployeeRepository _employeeRepository;
        public RoomService(IEmployeeRepository employeeRepository, IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
            _employeeRepository = employeeRepository;
        }

        public Rooms createRoom(Rooms room)
        {
            var employee = _employeeRepository.getEmployee(room.employeeId);

             if (employee == null)
            {
                throw new Exception("Employee not found");
            }
             else
            {
                return _roomRepository.createRoom(room);
            }
        }
        public void deleteRoom(int id)
        {
            if (id > 0)
                _roomRepository.deleteRoom(id);
            else
                throw new Exception("Id can not be less than 1");
        }

        public List<Rooms> getAllRooms()
        {
            return _roomRepository.getAllRooms();
        }

        public Rooms getRoom(int id)
        {
            if (id > 0)
                return _roomRepository.getRoom(id);
            else
                throw new Exception("Id can not be less than 1");
        }
        public Rooms updateRoom(int id,Rooms room)
        {
            var employee = _employeeRepository.getEmployee(room.employeeId);
            if (id > 0)
            {
                if(employee!=null)  
                    return _roomRepository.updateRoom(room);
                else throw new Exception("Employee not found");
            }
            else
                throw new Exception("Id can not be less than 1");
        }


    }
}
