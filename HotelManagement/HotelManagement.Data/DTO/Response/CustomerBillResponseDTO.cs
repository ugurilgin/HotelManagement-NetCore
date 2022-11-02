using Entities;
using HotelManagement.Entities.EntityBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO.Response
{
    public class CustomerBillResponseDTO
    {
        private int id { get; set; }
        private int count { get; set; }
        private DateTime entryDate { get; set; }
        private DateTime exitDate { get; set; }
        private int customerId { get; set; }
        private int roomId { get; set; }
        private int roomPrice { get; set; }
        private roomTypes roomType { get; set; }
        private int roomNumber { get; set; }
        private string customerName { get; set; }
        private string customerSurname { get; set; }
        private string email { get; set; }
        private string phone { get; set; }
        private Gender gender { get; set; }


        public CustomerBillResponseDTO(int id, int count, DateTime entryDate, DateTime exitDate, int customerId, int roomId, int roomPrice, roomTypes roomType, int roomNumber, string customerName, string customerSurname, string email, string phone, Gender gender)
        {
            this.id = id;
            this.count = count;
            this.entryDate = entryDate;
            this.exitDate = exitDate;
            this.customerId = customerId;
            this.roomId = roomId;
            this.roomPrice = roomPrice;
            this.roomType = roomType;
            this.roomNumber = roomNumber;
            this.customerName = customerName;
            this.customerSurname = customerSurname;
            this.email = email;
            this.phone = phone;
            this.gender = gender;
          
        }
    }
}
