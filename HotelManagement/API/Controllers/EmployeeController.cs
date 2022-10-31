using Business.Abstract;
using Business.Concrete;
using DataAccess.Error;
using HotelManagement.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            var employee= _employeeService.getAllEmployees();
            return Ok(employee);
        }

        [HttpGet("{id}")]
      //  [Route("[action]/{id}")]
        public IActionResult getEmployee(int id)
        {   
            var employee= _employeeService.getEmployee(id);
            if (employee!=null)
            {
                return Ok(employee);
            }
            else
            {
                return StatusCode(404, ErrorManage.Show("Id not found"));
            }
             
        }

       [HttpPost]
        IActionResult createEmployee([FromBody] Employee employee)
        {
            var createdEmployee= _employeeService.createEmployee(employee);
            return CreatedAtAction("GET", new { id = createdEmployee.id },createdEmployee);
        }

        [HttpPut("{id}")]
        public IActionResult  updateEmployee([FromBody] Employee employee,int id)
        {   var updatedEmployee= _employeeService.updateEmployee(employee, id);
            if (_employeeService.getEmployee(id) != null)
            {
                return Ok(updatedEmployee);
            }
            else return StatusCode(404, ErrorManage.Show("No records found"));

        }

        [HttpDelete("{id}")]
       public IActionResult  deleteEmployee(int id)
        {
            if (_employeeService.getEmployee(id) != null)
            {
                _employeeService.deleteEmployee(id);
                return Ok();
            }
            else return StatusCode(404, ErrorManage.Show("No records found"));

        }
    }
}
