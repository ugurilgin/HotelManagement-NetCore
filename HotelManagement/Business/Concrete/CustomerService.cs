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
     public class CustomerService : ICustomerService
    {
        private ICustomerRepository     _customerRepository;
        private IServicesRepository     _servicesRepository;
        private IExtrasRepository       _extrasRepository;
        private IRestaurantRepository   _restaurantRepository;
        public CustomerService(ICustomerRepository customerRepository, IServicesRepository servicesRepository, IExtrasRepository extrasRepository, IRestaurantRepository restaurantRepository)
        {
            _customerRepository   = customerRepository;
            _servicesRepository   = servicesRepository;
            _extrasRepository     = extrasRepository;
            _restaurantRepository = restaurantRepository;
        }
        public Extras addExtra(int customerId, Extras extras)
        {
            var customer = _customerRepository.getCustomer(customerId);
            var extra=_extrasRepository.getExtra(extras.id);
            if (customerId > 0)
            {
                if (customer != null && extra != null)
                    return _customerRepository.addExtra(customerId, extras);
                else throw new Exception("Customer or Extra not found");
            }
            else
                throw new Exception("Id can not be less than 1");
        }

        public Restaurant addMeal(int customerId, Restaurant meals)
        {
            var customer = _customerRepository.getCustomer(customerId);
            var meal = _restaurantRepository.getMeal(meals.id);
            if (customerId > 0)
            {
                if (customer != null && meal !=null )
                    return _customerRepository.addMeal(customerId, meals);
                else throw new Exception("Customer or Meal not found");
            }
            else
                throw new Exception("Id can not be less than 1");
        }

        public Services addService(int customerId, Services services)
        {
            var customer = _customerRepository.getCustomer(customerId);
            var service = _servicesRepository.getService(services.id);
            if (customerId > 0)
            {
                if (customer != null && service !=null)
                    return _customerRepository.addService(customerId, services);
                else throw new Exception("Customer or Service not found");
            }
            else
                throw new Exception("Id can not be less than 1");
        }

        public Customers createCustomer(Customers customers)
        {
            return _customerRepository.createCustomer(customers);
        }


        public void deleteCustomer(int id)
        {
            if (id > 0)
                _customerRepository.deleteCustomer(id);
            else
                throw new Exception("Id can not be less than 1");
        }

        public void deleteExtraFromCustomer(int customerId, int serviceId)
        {
            var customer= _customerRepository.getCustomer(customerId);
            var extra = _extrasRepository.getExtra(serviceId);
            if (customerId > 0 && serviceId > 0)
            { 
            if(customer != null && extra!=null)
                {
                     _customerRepository.deleteExtraFromCustomer(customerId, serviceId);
                }
                else
                    throw new Exception("Customer Or Extra Not Found");
            }
            else
                throw new Exception("Id can not be less than 1");
        }

        public void deleteMealFromCustomer(int customerId, int serviceId)
        {
            var customer = _customerRepository.getCustomer(customerId);
            var meal = _restaurantRepository.getMeal(serviceId);
            if (customerId > 0 && serviceId > 0)
            {
                if (customer != null && meal != null)
                {
                    _customerRepository.deleteMealFromCustomer(customerId, serviceId);
                }
                else
                    throw new Exception("Customer Or Meal Not Found");
            }
            else
                throw new Exception("Id can not be less than 1");
        }

        public void deleteServiceFromCustomer(int customerId, int serviceId)
        {
            var customer = _customerRepository.getCustomer(customerId);
            var service = _servicesRepository.getService(serviceId);
            if (customerId > 0 && serviceId > 0)
            {
                if (customer != null && service != null)
                {
                    _customerRepository.deleteServiceFromCustomer(customerId, serviceId);
                }
                else
                    throw new Exception("Customer Or Service Not Found");
            }
            else
                throw new Exception("Id can not be less than 1");
        }

        public List<Customers> getAllCustomers()
        {
            return _customerRepository.getAllCustomers();
        }

      

        public Customers getCustomer(int id)
        {
            return _customerRepository.getCustomer(id);
        }

        public Customers updateCustomer(int id,Customers customers)
        {
            if (id > 0)
            {
                return _customerRepository.updateCustomer(customers);
            }
            else
                throw new Exception("Id can not be less than 1");
        }
    
  
       

    }

}

