using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Error;
using Entities;
using HotelManagement.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Policy;

namespace API.Controllers
{
    [Route("api/rooms")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        IRoomService _roomService;
        IEmployeeService _employeeService;
        public RoomController(IRoomService roomService, IEmployeeService employeeService)
        {
            _roomService = roomService;
            _employeeService = employeeService;
        }

        [HttpGet]

        public IActionResult getAllRooms()
        {
            var rooms = _roomService.getAllRooms();
            return Ok(rooms);
        }

        [HttpGet("{id}")]
        //  [Route("[action]/{id}")]
        public IActionResult getRoom(int id)
        {
            try { 
            var rooms = _roomService.getRoom(id);
            if (rooms != null)
            {
                return Ok(rooms);
            }
            else
            {
                return StatusCode(404, ErrorManage.Show("Id not found"));
            }
        }
            catch (Exception e) { return StatusCode(404, ErrorManage.Show(e.Message));
    }
}

        [HttpPost]
        public IActionResult createRoom([FromBody] Rooms room)
        {
            try { 
            var employee = _employeeService.getEmployee(room.employeeId);
            if (employee != null)
            {
                var createdUser = _roomService.createRoom(room);
                return CreatedAtAction("GET", new { createdUser.id }, createdUser);
            }
            return StatusCode(404, ErrorManage.Show("Employee not found"));
        }
            catch (Exception e) { return StatusCode(404, ErrorManage.Show(e.Message));
    }
}

        [HttpPut("{id}")]
        public IActionResult updateRoom(int id,[FromBody] Rooms room )
        {
            try { 
            var employee = _employeeService.getEmployee(room.employeeId);
            var updatedRoom = _roomService.updateRoom(id, room);
            if (_roomService.getRoom(id) != null)
            {
                if (employee != null)
                {
                    return Ok(updatedRoom);
                }
                return StatusCode(404, ErrorManage.Show("Employee not found"));
            }

            else return StatusCode(404, ErrorManage.Show("No records found"));
        }
            catch (Exception e) { return StatusCode(404, ErrorManage.Show(e.Message));
    }
}

        [HttpDelete("{id}")]
        public IActionResult deleteRoom(int id)
        {
            try { 
            if (_roomService.getRoom(id) != null)
            {
                _roomService.deleteRoom(id);
                return Ok();
            }
            else return StatusCode(404, ErrorManage.Show("No records found"));
        }
            catch (Exception e) { return StatusCode(404, ErrorManage.Show(e.Message));
    }
}
    }
}
