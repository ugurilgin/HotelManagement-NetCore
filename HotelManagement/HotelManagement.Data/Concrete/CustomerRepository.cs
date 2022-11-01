using DataAccess.Abstract;
using Entities;
using HotelManagement.Data;
using HotelManagement.Entities;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
     public class CustomerRepository : ICustomerRepository
    {
        public Extras addExtra(int customerId, Extras extras)
        {
            using (var applicationDbContext = new ApplicationDbContext())
            {
               
                customer_extra customerExtra = new customer_extra
                {
                    customer_id = customerId,
                    extras_id = extras.id
                };
                applicationDbContext.Customer_Extras.Add(customerExtra);
                applicationDbContext.SaveChanges();


                return extras;
            }
        }

        public Restaurant addMeal(int customerId, Restaurant meals)
        {
            using (var applicationDbContext = new ApplicationDbContext())
            {

                customer_restaurant customerMeal = new customer_restaurant
                {
                    customer_id = customerId,
                    restaurant_id = meals.id
                };
                applicationDbContext.Customer_Restaurants.Add(customerMeal);
                applicationDbContext.SaveChanges();


                return meals;
            }
        }

        public Services addService(int customerId, Services services)
        {
            using (var applicationDbContext = new ApplicationDbContext())
            {

                customer_service customerService = new customer_service
                {
                    customer_id = customerId,
                    service_id = services.id
                };
                applicationDbContext.Customer_Services.Add(customerService);
                applicationDbContext.SaveChanges();


                return services;
            }
        }

        public Customers createCustomer(Customers customers)
        {
            using (var applicationDbContext = new ApplicationDbContext())
            {
                applicationDbContext.Customers.Add(customers);
                applicationDbContext.SaveChanges();
                return customers;
            }
        }


        public void deleteCustomer(int id)
        {
            using (var applicationDbContext = new ApplicationDbContext())
            {
                var deletedCustomer = getCustomer(id);
                applicationDbContext.Customers.Remove(deletedCustomer);
                applicationDbContext.SaveChanges();
            }
        }

        public void deleteExtraFromCustomer(int customerId, int serviceId)
        {
            using (var applicationDbContext = new ApplicationDbContext())
            {
                customer_extra customerExtra = new customer_extra
                {
                    customer_id = customerId,
                    extras_id = serviceId
                };
                applicationDbContext.Customer_Extras.Remove(customerExtra);
                applicationDbContext.SaveChanges();
            }
        }

        public void deleteMealFromCustomer(int customerId, int serviceId)
        {
            using (var applicationDbContext = new ApplicationDbContext())
            {
                customer_restaurant customerMeal = new customer_restaurant
                {
                    customer_id = customerId,
                    restaurant_id = serviceId
                };
                applicationDbContext.Customer_Restaurants.Remove(customerMeal);
                applicationDbContext.SaveChanges();
            }
        }

        public void deleteServiceFromCustomer(int customerId, int serviceId)
        {
            using (var applicationDbContext = new ApplicationDbContext())
            {
                customer_service customerService = new customer_service
                {
                    customer_id = customerId,
                    service_id = serviceId
                };
                applicationDbContext.Customer_Services.Remove(customerService);
                applicationDbContext.SaveChanges();
            }
        }

        public List<Customers> getAllCustomers()
        {
            using (var applicationDbContext = new ApplicationDbContext())
            {
                return applicationDbContext.Customers.ToList();
            }
        }

      

        public Customers getCustomer(int id)
        {
            using (var applicationDbContext = new ApplicationDbContext())
            {
                return applicationDbContext.Customers.Find(id);
            }
        }

        public Customers updateCustomer(Customers customers)
        {
            using (var applicationDbContext = new ApplicationDbContext())
            {
                applicationDbContext.Customers.Update(customers);
                applicationDbContext.SaveChanges();
                return customers;
            }
        }
    
  
       

    }

}

