using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities;
using HotelManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Business.Concrete
{
    public class ServicesService : IServicesService
    {
       private IServicesRepository _servicesRepository;
        public ServicesService(IServicesRepository servicesRepository)
        {
            _servicesRepository = servicesRepository;
        }

        public Services createService(Services service)
        {
            return _servicesRepository.createService(service);
        }

        public void deleteService(int id)
        {
            if (id > 0)
                _servicesRepository.deleteService(id);
            else
                throw new Exception("Id can not be less than 1");
            
        }



        public List<Services> getAllServices()
        {
            return _servicesRepository.getAllServices();
        }

        public Services getService(int id)
        {
            if (id > 0)
                return _servicesRepository.getService(id);
            else
                throw new Exception("Id can not be less than 1");
        }


        public Services updateService(int id ,Services service)
        {
            if (id > 0) {
            return _servicesRepository.updateService(service); }
            else
                throw new Exception("Id can not be less than 1");
        }
    }
}
