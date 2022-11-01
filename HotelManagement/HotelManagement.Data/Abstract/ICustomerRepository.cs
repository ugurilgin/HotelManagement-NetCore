using Entities;
using HotelManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICustomerRepository
    {
        List<Customers> getAllCustomers();
        Customers getCustomer(int id);
        Customers createCustomer(Customers customers);
        Extras addExtra(int customerId, Extras extras);
        Restaurant addMeal(int customerId,Restaurant meals);
        Services addService(int customerId,Services services);
        Customers updateCustomer(Customers customers);
        void deleteCustomer(int id);
        void deleteServiceFromCustomer(int customerId, int serviceId);
        void deleteExtraFromCustomer(int customerId, int serviceId);
        void deleteMealFromCustomer(int customerId, int serviceId);

        
    }
}
