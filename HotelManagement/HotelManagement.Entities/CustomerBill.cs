using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Entities;

namespace Entities
{
    public class CustomerBill
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public int customerId { get; set; }
        public Customers customer { get; set; }
        [Required(ErrorMessage = "EntryDate can not be null")]
        public DateTime entryDate { get; set; }
        [Required(ErrorMessage = "Exit Date can not be null")]
        public DateTime exitDate { get; set; }
        [Required(ErrorMessage = "Count can not be null")]
        public int count { get; set; }
       
        public int roomId { get; set; }
        public Rooms room { get; set; }
    }
}
