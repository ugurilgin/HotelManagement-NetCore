using HotelManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IEmployeeService
    {
        List<Employee> getAllEmployees();
        Employee getEmployee(int id);
        Employee createEmployee(Employee employee);
        Employee updateEmployee(Employee employee,int id);
        void deleteEmployee(int id);
        public int GetAge(DateTime bornDate);
        public int CompareDates(DateTime startDate,DateTime finishDate);

    }
}
