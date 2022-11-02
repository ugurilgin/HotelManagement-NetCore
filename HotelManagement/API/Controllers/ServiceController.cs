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
    [Route("api/services")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        IServicesService _servicesService;
        public ServicesController(IServicesService servicesService)
        {
            _servicesService = servicesService;
        }

        [HttpGet]

        public IActionResult getAllServices()
        {
            var services = _servicesService.getAllServices();
            return Ok(services);
        }

        [HttpGet("{id}")]
        //  [Route("[action]/{id}")]
        public IActionResult getService(int id)
        {
            try { 
            var services = _servicesService.getService(id);
            if (services != null)
            {
                return Ok(services);
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
        public IActionResult createService([FromBody] Services services)
        {
            try { 
            var createdService = _servicesService.createService(services);
            return CreatedAtAction("GET", new { createdService.id }, createdService);
        }
            catch (Exception e) { return StatusCode(404, ErrorManage.Show(e.Message));
    }
}

        [HttpPut("{id}")]
        public IActionResult updateService(int id,[FromBody] Services extras )
        {
            try { 
            var updatedService = _servicesService.updateService(id, extras);
            if (_servicesService.getService(id) != null)
            {
                return Ok(updatedService);
            }
            else return StatusCode(404, ErrorManage.Show("No records found"));
        }
            catch (Exception e) { return StatusCode(404, ErrorManage.Show(e.Message));
    }
}

        [HttpDelete("{id}")]
        public IActionResult deleteService(int id)
        {
            try { 
            if (_servicesService.getService(id) != null)
            {
                _servicesService.deleteService(id);
                return Ok();
            }
            else return StatusCode(404, ErrorManage.Show("No records found"));
        }
            catch (Exception e) { return StatusCode(404, ErrorManage.Show(e.Message));
    }
}
    }
}
