using HotelManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    internal interface IEmployeeRepository
    {
        List<Employee> getAllEmployees();
        Employee getEmployee(int id);
        Employee createEmployee(Employee employee);
        Employee updateEmployee(Employee employee);
        void deleteEmployee(int id);
    }
}
