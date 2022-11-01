using HotelManagement.Entities.EntityBases;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Entities;

namespace HotelManagement.Entities
{
    public class Customers : IPerson
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required(ErrorMessage = "Name can not be null")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Name Size must be between 3 and 25")]
        public string name { get; set; }
        [Required(ErrorMessage = "Surname can not be null")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Surname Size must be between 3 and 25")]
        public string surname { get; set; }
        [Required(ErrorMessage = "BirthDate can not be null")]
        public DateTime birthDate { get; set; }
        [Required(ErrorMessage = "Email can not be null")]
        [EmailAddress]
        public string email { get; set; }
        [Required(ErrorMessage = "Phone can not be null")]
        public string phone { get; set; }
        [Required(ErrorMessage = "Gender can not be null")]
        public Gender gender { get; set; }
        [Required(ErrorMessage = "Blood can not be null")]
        public Blood blood { get ; set; }
        [Required(ErrorMessage = "Adress can not be null")]
        [StringLength(125, MinimumLength = 3, ErrorMessage = "Adress Size must be between 3 and 125")]
        public string adress { get; set; }
        public ICollection<CustomerBill> customerBill { get; set; }
        public ICollection<customer_extra> customer_Extras { get; set; }
        public ICollection<customer_restaurant> customer_Restaurants { get; set; }
        public ICollection<customer_service> customer_Services { get; set; }
    }
}
