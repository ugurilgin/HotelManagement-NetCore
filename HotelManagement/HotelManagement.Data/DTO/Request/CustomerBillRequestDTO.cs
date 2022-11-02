using Entities;
using HotelManagement.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO.Request
{
    public class CustomerBillRequestDTO
    {
        [Required(ErrorMessage = "CustomerId can not be null")]
        public int customerId { get; set; }
        [Required(ErrorMessage = "EntryDate can not be null")]
        public DateTime entryDate { get; set; }
        [Required(ErrorMessage = "Exit Date can not be null")]
        public DateTime exitDate { get; set; }
        [Required(ErrorMessage = "Count can not be null")]
        public int count { get; set; }
        [Required(ErrorMessage = "RoomId can not be null")]
        public int roomId { get; set; }
    }
}
