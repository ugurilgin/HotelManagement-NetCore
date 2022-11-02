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
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]

        public IActionResult getAllUsers()
        {
            var users = _userService.getAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        //  [Route("[action]/{id}")]
        public IActionResult getUser(int id)
        {
            try { 
            var users = _userService.getUser(id);
            if (users != null)
            {
                return Ok(users);
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
        public IActionResult createUser([FromBody] User user)
        {
            try { 
            var createdUser = _userService.createUser(user);
            return CreatedAtAction("GET", new { createdUser.id }, createdUser);
        }
            catch (Exception e) { return StatusCode(404, ErrorManage.Show(e.Message));
    }
}

        [HttpPut("{id}")]
        public IActionResult updateUser(int id,[FromBody] User user )
        {
            try { 
            var updatedUser = _userService.updateUser(id, user);
            if (_userService.getUser(id) != null)
            {
                return Ok(updatedUser);
            }
            else return StatusCode(404, ErrorManage.Show("No records found"));
        }
            catch (Exception e) { return StatusCode(404, ErrorManage.Show(e.Message));
    }
}

        [HttpDelete("{id}")]
        public IActionResult deleteUser(int id)
        {
            try { 
            if (_userService.getUser(id) != null)
            {
                _userService.deleteUser(id);
                return Ok();
            }
            else return StatusCode(404, ErrorManage.Show("No records found"));
        }
            catch (Exception e) { return StatusCode(404, ErrorManage.Show(e.Message));
    }
}
    }
}
