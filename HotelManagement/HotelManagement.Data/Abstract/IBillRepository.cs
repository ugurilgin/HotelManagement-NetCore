using Entities;
using HotelManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IBillRepository
    {
        List<CustomerBill> getAllBills();
        CustomerBill getBill(int id);
        CustomerBill createBill(CustomerBill bill);
        CustomerBill updateBill(CustomerBill bill);
        void deleteBill(int id);
    }
}
