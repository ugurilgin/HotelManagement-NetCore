using DataAccess.Abstract;
using HotelManagement.Data;
using HotelManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    internal class EmployeeRepository : IEmployeeRepository
    {
        public Employee createEmployee(Employee employee)
        {
            using (var applicationDbContext = new ApplicationDbContext())
            {
                applicationDbContext.Employees.Add(employee);
                applicationDbContext.SaveChanges();
                return employee;
            }
        }

        public void deleteEmployee(int id)
        {
            using (var applicationDbContext = new ApplicationDbContext())
            {
               var deletedEmployee=getEmployee(id);
                applicationDbContext.Employees.Remove(deletedEmployee);
                applicationDbContext.SaveChanges();
            }
        }

        public List<Employee> getAllEmployees()
        {
            using (var applicationDbContext = new ApplicationDbContext())
            {
                return applicationDbContext.Employees.ToList();
            }
        }

        public Employee getEmployee(int id)
        {
            using (var applicationDbContext = new ApplicationDbContext())
            {
                return applicationDbContext.Employees.Find(id);
            }
        }

        public Employee updateEmployee(Employee employee)
        {
            using (var applicationDbContext = new ApplicationDbContext())
            {
                 applicationDbContext.Employees.Update(employee);
                applicationDbContext.SaveChanges();
                return employee;
            }
        }
    }
}
