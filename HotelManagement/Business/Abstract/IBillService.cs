using DataAccess.DTO.Request;
using DataAccess.DTO.Response;
using Entities;
using HotelManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IBillService
    {
        List<CustomerBill> getAllBills();
        CustomerBillResponseDTO getBill(int id);
        CustomerBill createBill(CustomerBillRequestDTO bill);
        CustomerBill updateBill(int id, CustomerBillRequestDTO bill);
        void deleteBill(int id);
    }
}
