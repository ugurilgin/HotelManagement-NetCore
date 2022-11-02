using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using HotelManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Business.Concrete
{
    public class EmployeeService : IEmployeeService
    {
       private IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public int CompareDates(DateTime startDate, DateTime finishDate)
        {
           
            int year = finishDate.Year - startDate.Year;
            if (startDate > finishDate.AddYears(-year))
                year--;

            return year;
        }

        public Employee createEmployee(Employee employee)
        {
            var age = GetAge(employee.birthDate);
            
            if (age<18)
            {
                throw new Exception("Age can not be less than 18");
            }
            
            else
            { return _employeeRepository.createEmployee(employee); }
            
        }

        public void deleteEmployee(int id)
        {
            if (id > 0)
                _employeeRepository.deleteEmployee(id);
            else
                throw new Exception("Id can not be less than 1");
            
        }

        public int GetAge(DateTime bornDate)
        {
            
                DateTime today = DateTime.Today;
                int age = today.Year - bornDate.Year;
                if (bornDate > today.AddYears(-age))
                    age--;

                return age;
            
        }

        public List<Employee> getAllEmployees()
        {
            return _employeeRepository.getAllEmployees();
        }

        public Employee getEmployee(int id)
        {
            if (id > 0)
                return _employeeRepository.getEmployee(id);
            else
                throw new Exception("Id can not be less than 1");
        }

        public Employee updateEmployee(Employee employee,int id)
        {
            if (id > 0) {
               
            return _employeeRepository.updateEmployee(employee); }
            else
                throw new Exception("Id can not be less than 1");
        }
    }
}
