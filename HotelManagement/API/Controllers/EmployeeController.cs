using Business.Abstract;
using Business.Concrete;
using DataAccess.Error;
using HotelManagement.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Policy;

namespace API.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]

        public IActionResult getAllEmployees()
        {
            var employee = _employeeService.getAllEmployees();
            return Ok(employee);
        }

        [HttpGet("{id}")]
        //  [Route("[action]/{id}")]
        public IActionResult getEmployee(int id)
        {
            try { 
            var employee = _employeeService.getEmployee(id);
            if (employee != null)
            {
                return Ok(employee);
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
        public IActionResult createEmployee([FromBody] Employee employee)
        {
            try { 
            var createdEmployee = _employeeService.createEmployee(employee);
            return CreatedAtAction("GET", new { createdEmployee.id }, createdEmployee);
                }
            catch (Exception e) { return StatusCode(404, ErrorManage.Show(e.Message));
                }
        }

        [HttpPut("{id}")]
        public IActionResult updateEmployee( int id,[FromBody] Employee employee)
        {
            try { 
            var updatedEmployee = _employeeService.updateEmployee(employee, id);
            if (_employeeService.getEmployee(id) != null)
            {
                return Ok(updatedEmployee);
            }
            else return StatusCode(404, ErrorManage.Show("No records found"));
            }
            catch (Exception e) { return StatusCode(404, ErrorManage.Show(e.Message));
            }
        }

        [HttpDelete("{id}")]
        public IActionResult deleteEmployee(int id)
        {
            try { 
            if (_employeeService.getEmployee(id) != null)
            {
                _employeeService.deleteEmployee(id);
                return Ok();
            }
            else return StatusCode(404, ErrorManage.Show("No records found"));
        }
            catch (Exception e) { return StatusCode(404, ErrorManage.Show(e.Message));
            }
        }
       }
}
