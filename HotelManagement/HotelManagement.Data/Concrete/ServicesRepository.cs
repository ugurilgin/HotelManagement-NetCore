using DataAccess.Abstract;
using Entities;
using HotelManagement.Data;
using HotelManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
     public class ServicesRepository : IServicesRepository
    {
        public Services createService(Services service)
        {
            using (var applicationDbContext = new ApplicationDbContext())
            {
                applicationDbContext.Services.Add(service);
                applicationDbContext.SaveChanges();
                return service;
            }
        }

        public void deleteService(int id)
        {
            using (var applicationDbContext = new ApplicationDbContext())
            {
                var deletedService = getService(id);
                applicationDbContext.Services.Remove(deletedService);
                applicationDbContext.SaveChanges();
            }
        }

        public List<Services> getAllServices()
        {
            using (var applicationDbContext = new ApplicationDbContext())
            {
                return applicationDbContext.Services.ToList();
            }
        }

        public Services getService(int id)
        {
            using (var applicationDbContext = new ApplicationDbContext())
            {
                return applicationDbContext.Services.Find(id);
            }
        }

        public Services updateService(Services service)
        {
            using (var applicationDbContext = new ApplicationDbContext())
            {
                applicationDbContext.Services.Update(service);
                applicationDbContext.SaveChanges();
                return service;
            }
        }
    }
}
