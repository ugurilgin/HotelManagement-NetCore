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
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult getAllCustomers()
        {
            var customers = _customerService.getAllCustomers();
            return Ok(customers);
        }

        [HttpGet("{id}")]

        public IActionResult getCustomer(int id)
        {
            try { 
            var customer = _customerService.getCustomer(id);
            if (customer != null)
            {
                return Ok(customer);
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
        public IActionResult createCustomer([FromBody] Customers customer)
        {
            try {
                var createdCustomer = _customerService.createCustomer(customer);
                return CreatedAtAction("GET", new { createdCustomer.id }, createdCustomer);
            }
            catch (Exception e) { return StatusCode(404, ErrorManage.Show(e.Message)); }
        }
        [HttpPost]
        [Route("[action]/{id}")]
        public IActionResult addExtra(int id, [FromBody] Extras extra)
        {
            try {
                var addedCustomer = _customerService.addExtra(id, extra);
                return CreatedAtAction("GET", new { addedCustomer.id }, addedCustomer);
            }
            catch (Exception e) { return StatusCode(404, ErrorManage.Show(e.Message));
            }
        }
        [HttpPost]
        [Route("[action]/{id}")]
        public IActionResult addService(int id, [FromBody] Services services)
        {
            try {
                var addedCustomer = _customerService.addService(id, services);
                return CreatedAtAction("GET", new { addedCustomer.id }, addedCustomer);
            }
            catch (Exception e) { return StatusCode(404, ErrorManage.Show(e.Message));
            }
        }
        [HttpPost]
        [Route("[action]/{id}")]
        public IActionResult addMeal(int id, [FromBody] Restaurant meal)
        {
            try {
                var addedCustomer = _customerService.addMeal(id, meal);
                return CreatedAtAction("GET", new { addedCustomer.id }, addedCustomer);
            }
            catch (Exception e) { return StatusCode(404, ErrorManage.Show(e.Message));
            }
        }
        [HttpPut("{id}")]
        public IActionResult updateCustomer(int id, [FromBody] Customers customer)
        {
            try {
                var updatedCustomer = _customerService.updateCustomer(id, customer);
                if (_customerService.getCustomer(id) != null)
                {
                    return Ok(updatedCustomer);
                }
                else return StatusCode(404, ErrorManage.Show("No records found"));
            }
            catch (Exception e) { return StatusCode(404, ErrorManage.Show(e.Message));
            }

        }

        [HttpDelete("{id}")]
        public IActionResult deleteCustomer(int id)
        {
            try {
                if (_customerService.getCustomer(id) != null)
                {
                    _customerService.deleteCustomer(id);
                    return Ok();
                }
                else return StatusCode(404, ErrorManage.Show("No records found"));
            }
            catch (Exception e) { return StatusCode(404, ErrorManage.Show(e.Message));
            }
        }

        [HttpDelete]
        [Route("[action]/{customerId}/{serviceId}")]
        public IActionResult deleteServiceFromCustomer(int customerId, int serviceId)
        {
            try
            {
                if (_customerService.getCustomer(customerId) != null)
                {
                    _customerService.deleteServiceFromCustomer(customerId, serviceId);
                    return Ok();
                }
                else return StatusCode(404, ErrorManage.Show("No records found"));
            }
            catch (Exception e)
            {
                return StatusCode(404, ErrorManage.Show(e.Message));
            }
        }


        [HttpDelete]
        [Route("[action]/{customerId}/{extraId}")]
        public IActionResult deleteExtraFromCustomer(int customerId, int extraId)
        {
            try { 
            if (_customerService.getCustomer(customerId) != null)
            {
                _customerService.deleteExtraFromCustomer(customerId, extraId);
                return Ok();
            }
            else return StatusCode(404, ErrorManage.Show("No records found"));
                }
            catch (Exception e) { return StatusCode(404, ErrorManage.Show(e.Message));
                }
            } 
        [HttpDelete]
        [Route("[action]/{customerId}/{mealId}")]
        public IActionResult deleteMealFromCustomer(int customerId, int mealId)
        {
            try { 
            if (_customerService.getCustomer(customerId) != null)
            {
                _customerService.deleteMealFromCustomer(customerId, mealId);
                return Ok();
            }
            else return StatusCode(404, ErrorManage.Show("No records found"));
                }
            catch (Exception e) { return StatusCode(404, ErrorManage.Show(e.Message));
            }
        }
    }
}
