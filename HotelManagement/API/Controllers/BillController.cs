using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.DTO.Request;
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
    [Route("api/bill")]
    [ApiController]
    public class BillController : ControllerBase
    {
        IBillService _billService;
        public BillController(IBillService billService)
        {
            _billService = billService;
        }

        [HttpGet]
        public IActionResult getAllBills()
        {
            var employee = _billService.getAllBills();
            return Ok(employee);
        }

        [HttpGet("{id}")]
        //  [Route("[action]/{id}")]
        public IActionResult getBill(int id)
        {
            try { 
            var bill = _billService.getBill(id);
            if (bill != null)
            {
                return Ok(bill);
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
        public IActionResult createBill([FromBody] CustomerBillRequestDTO bill)
        {
            try {
            var createdBill = _billService.createBill(bill);
            return CreatedAtAction("GET", new { createdBill.id }, createdBill);
            }
            catch(Exception e)
            {
                return StatusCode(404, ErrorManage.Show(e.Message));
            }

        }

        [HttpPut("{id}")]
        public IActionResult updateBill(int id,[FromBody] CustomerBillRequestDTO bill )
        {
            try
            {
                var updatedBill = _billService.updateBill(id, bill);
            if (_billService.getBill(id) != null)
            {
                return Ok(updatedBill);
            }
            else return StatusCode(404, ErrorManage.Show("No records found"));
            }
            catch(Exception e)
            {
                return StatusCode(404, ErrorManage.Show(e.Message));
    }
}

        [HttpDelete("{id}")]
        public IActionResult deleteBill(int id)
        {
            try { 
            if (_billService.getBill(id) != null)
            {
                _billService.deleteBill(id);
                return Ok();
            }
            else return StatusCode(404, ErrorManage.Show("No records found"));
        }
            catch (Exception e) { return StatusCode(404, ErrorManage.Show(e.Message));
    }
}
    }
}
