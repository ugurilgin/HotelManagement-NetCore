using Entities;
using HotelManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IServicesService
    {
        List<Services> getAllServices();
        Services getService(int id);
        Services createService(Services service);
        Services updateService(int id,Services service);
        void deleteService(int id);
    }
}
