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
     public class CustomerBillRepository : IBillRepository
    {
        public CustomerBill createBill(CustomerBill bill)
        {
            using (var applicationDbContext = new ApplicationDbContext())
            {
                applicationDbContext.Bills.Add(bill);
                applicationDbContext.SaveChanges();
                return bill;
            }
        }

        public void deleteBill(int id)
        {
            using (var applicationDbContext = new ApplicationDbContext())
            {
                var deletedBill = getBill(id);
                applicationDbContext.Bills.Remove(deletedBill);
                applicationDbContext.SaveChanges();
            }
        }

        public List<CustomerBill> getAllBills()
        {
            using (var applicationDbContext = new ApplicationDbContext())
            {
                return applicationDbContext.Bills.ToList();
            }
        }

        public CustomerBill getBill(int id)
        {
            using (var applicationDbContext = new ApplicationDbContext())
            {
                return applicationDbContext.Bills.Find(id);
            }
        }

        public CustomerBill updateBill(CustomerBill bill)
        {
            using (var applicationDbContext = new ApplicationDbContext())
            {
                applicationDbContext.Bills.Update(bill);
                applicationDbContext.SaveChanges();
                return bill;
            }
        }

      
    }
}
