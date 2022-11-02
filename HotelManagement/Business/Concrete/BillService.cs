using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.DTO.Request;
using DataAccess.DTO.Response;
using Entities;
using HotelManagement.Entities;
using HotelManagement.Entities.EntityBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Business.Concrete
{
    public class BillService : IBillService
    {
        private IBillRepository _biilRepository;
        private ICustomerRepository _customerRepository;
        private IRoomRepository _roomRepository;
        public BillService(IBillRepository billRepository, ICustomerRepository customerRepository, IRoomRepository roomRepository)
        {
            _biilRepository = billRepository;
            _customerRepository = customerRepository;
            _roomRepository = roomRepository;   
        }

        public int CompareDates(DateTime startDate, DateTime finishDate)
        {
           
            int year = finishDate.Year - startDate.Year;
            if (startDate > finishDate.AddYears(-year))
                year--;

            return year;
        }

        public CustomerBill createBill(CustomerBillRequestDTO bill)
        {
            var year = CompareDates(bill.entryDate,bill.exitDate);
            var customer = _customerRepository.getCustomer(bill.customerId);
            var room = _roomRepository.getRoom(bill.roomId);

            if (year < 0)
            {
                throw new Exception("Exit Date can not be earlier than Entry Date");
            }
            else if(customer==null)
            {
                throw new Exception("Customer not found");
            }
            else if (room == null)
            {
                throw new Exception("Room not found");
            }
            else
            {
                var customerBill = new CustomerBill 
                { customerId = bill.customerId, 
                  customer=customer,
                  roomId=bill.roomId,
                  room=room,
                  entryDate=bill.entryDate,
                  exitDate=bill.exitDate,
                  count=bill.count,
                
                };
                   

                    
                   

                return _biilRepository.createBill(customerBill); 
            }
        }


        public void deleteBill(int id)
        {
            if (id > 0)
            {
                var bill =_biilRepository.getBill(id);  
                if(bill!=null)
                {
                    _biilRepository.deleteBill(id);
                }
            }
            else
                throw new Exception("Id can not be less than 1");
        }

        public List<CustomerBill> getAllBills()
        {
            return _biilRepository.getAllBills();   
        }

        public CustomerBillResponseDTO getBill(int id)
        {
            var bill = _biilRepository.getBill(id);
            if (id > 0)
            {
                var customerBill = new CustomerBillResponseDTO(id,bill.count,bill.entryDate,bill.exitDate,bill.customerId,bill.roomId,bill.room.price,bill.room.type,bill.room.roomNumber,bill.customer.name,bill.customer.surname,bill.customer.email,bill.customer.phone,bill.customer.gender);
            
                return customerBill;
            }
            else
                throw new Exception("Id can not be less than 1");
        }

        public CustomerBill updateBill(int id , CustomerBillRequestDTO bill)
        {
            var year = CompareDates(bill.entryDate, bill.exitDate);
            var customer = _customerRepository.getCustomer(bill.customerId);
            var room = _roomRepository.getRoom(bill.roomId);
            if (id > 0)
            {
                if (year < 0)
                {
                    throw new Exception("Exit Date can not be earlier than Entry Date");
                }
                else if (customer == null)
                {
                    throw new Exception("Customer not found");
                }
                else if (room == null)
                {
                    throw new Exception("Room not found");
                }
                else
                {
                    var customerBill = new CustomerBill
                    {   id=id,
                        customerId = bill.customerId,
                        customer = customer,
                        roomId = bill.roomId,
                        room = room,
                        entryDate = bill.entryDate,
                        exitDate = bill.exitDate,
                        count = bill.count,

                    };

                    return _biilRepository.updateBill(customerBill); }
            }
            else
                throw new Exception("Id can not be less than 1");
        }

     
    }
}
