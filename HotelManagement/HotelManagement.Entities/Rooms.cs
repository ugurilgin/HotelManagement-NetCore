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
    public enum roomTypes
    {
        Single, Twin, Triple, Quad, Junior, Suit, Dubleks, Family, King

    }
    public enum roomStatues
    {
        Unprepared, Prepared, Occupied, Available, Checkout, Reserved, Closing

    }
    public enum roomClean
    {
        Dirty, Clean

    }

    public class Rooms
       
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required(ErrorMessage = "Bed Count can not be null")]
        public int beds { get; set; }
        [Required(ErrorMessage = "Price can not be null")]
        public int price { get; set; }
        [Required(ErrorMessage = "Room Number can not be null")]
        public int roomNumber { get; set; }
        [Required(ErrorMessage = "Room type can not be null")]
        public roomTypes  type { get; set; }
        [Required(ErrorMessage = "Room Statue can not be null")]
        public roomStatues statue { get; set; }
        [Required(ErrorMessage = "Clean statue can not be null")]
        public roomClean clean { get; set; }
        [Required(ErrorMessage = "EmployeeId type can not be null")]
        public int employeeId { get; set; }
        public Employee employee { get; set; }

        public ICollection<CustomerBill> customerBill { get; set; }
    }
}
