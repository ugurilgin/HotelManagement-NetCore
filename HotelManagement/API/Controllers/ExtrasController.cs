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
    [Route("api/extras")]
    [ApiController]
    public class ExtrasController : ControllerBase
    {
        IExtrasService _extrasService;
        public ExtrasController(IExtrasService extrasService)
        {
            _extrasService = extrasService;
        }

        [HttpGet]

        public IActionResult getAllExtras()
        {
            var extras = _extrasService.getAllExtras();
            return Ok(extras);
        }

        [HttpGet("{id}")]
        //  [Route("[action]/{id}")]
        public IActionResult getExtra(int id)
        {
            try { 
            var extra = _extrasService.getExtra(id);
            if (extra != null)
            {
                return Ok(extra);
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
        public IActionResult createExtra([FromBody] Extras extras)
        {
            try { 
            var createdExtra = _extrasService.createExtra(extras);
            return CreatedAtAction("GET", new { createdExtra.id }, createdExtra);
        }
            catch (Exception e) { return StatusCode(404, ErrorManage.Show(e.Message));
            }
        }

        [HttpPut("{id}")]
        public IActionResult updateExtra(int id,[FromBody] Extras extras)
        {
            try { 
            var updatedEmployee = _extrasService.updateExtra(id, extras);
            if (_extrasService.getExtra(id) != null)
            {
                return Ok(updatedEmployee);
            }
            else return StatusCode(404, ErrorManage.Show("No records found"));
        }
            catch (Exception e) { return StatusCode(404, ErrorManage.Show(e.Message));
            }
        }

        [HttpDelete("{id}")]
        public IActionResult deleteExtra(int id)
        {
            try { 
            if (_extrasService.getExtra(id) != null)
            {
                _extrasService.deleteExtra(id);
                return Ok();
            }
            else return StatusCode(404, ErrorManage.Show("No records found"));
            }
            catch (Exception e) { return StatusCode(404, ErrorManage.Show(e.Message));
                }
            }
        }
}
